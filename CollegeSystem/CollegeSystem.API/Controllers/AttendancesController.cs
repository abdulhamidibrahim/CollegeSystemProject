using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendancesController : ControllerBase
{
    private readonly IAttendanceManager _attendanceManager;

    public AttendancesController(IAttendanceManager attendanceManager)
    {
        _attendanceManager = attendanceManager;
    }

    // generate qrcode
    [HttpGet("generateQrCode/{groupId}")]
    public ActionResult<string> GenerateQrCode(long groupId)
    {
        var qrCodeImage = _attendanceManager.GenerateQRCode(groupId);
        return File(qrCodeImage, "image/png");
    }

    //validate qrcode
    [HttpPost("validateQrCode")]
    public ActionResult<string> ValidateQrCode([FromBody] string qrCode,long studentId)
    {
        var result = _attendanceManager.ValidateQRCode(qrCode);
        return Ok(result);
    }

[HttpGet("getAllStudentAttendance/{groupId}/{studentId}")]
    public ActionResult<List<AttendanceReadDto>> GetAll(long groupId,long studentId)
    {
        try
        {
            var result =_attendanceManager.GetAll(groupId,studentId);   
            return Ok(result);
        }
        catch (Exception e)
        {
            // Console.WriteLine(e);
            return BadRequest(new { message = e.Message });
        }
    }
    
    [HttpGet("get/{courseId}")]
    public ActionResult<AttendanceReadDto?> Get(long id)
    {
        var attendance = _attendanceManager.Get(id);
        if (attendance == null) return NotFound(new { message = "attendance not found"});
        return attendance;
    }
    
    [HttpPost]
    public ActionResult Add(AttendanceAddDto attendanceAddDto)
    {

        if (attendanceAddDto.QRCode != null)
        {
            _attendanceManager.ValidateQRCode(attendanceAddDto.QRCode);
            _attendanceManager.ValidateQRCode(attendanceAddDto.QRCode);
            return Ok(new { message = "attendance added"});

        }
            
        return BadRequest(new { message = "Scan the QR code first"});
    }
    
    [HttpPut]
    public ActionResult Update(AttendanceUpdateDto attendanceUpdateDto)
    {
        _attendanceManager.Update(attendanceUpdateDto);
        return Ok(new { message = "attendance updated"});
    }
    
    [HttpDelete("{courseId}")]
    public ActionResult Delete(long id)
    {
        _attendanceManager.Delete(id);
        return Ok(new { message = "attendance deleted"});
    }
    
}