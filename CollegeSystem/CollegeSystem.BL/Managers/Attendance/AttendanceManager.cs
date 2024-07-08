using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class AttendanceManager:IAttendanceManager
{
    // private readonly IQRCodeManager _qrCoder;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQRCodeManager _qrCodeManager;

    public AttendanceManager( IUnitOfWork unitOfWork, IQRCodeManager qrCodeManager)
    {
        _unitOfWork = unitOfWork;
        _qrCodeManager = qrCodeManager;
        // _qrCoder = qrCoder;
    }
    
    //generate qr code

    public byte[] GenerateQRCode(long groupId)
    {
        return _qrCodeManager.GenerateQRCode(groupId.ToString());
        
    }
    // check if the scanned qr code is valid

    public bool ValidateQRCode(string qrCode)
    {
        return _qrCodeManager.ValidateQRCode(qrCode);
    }
    public void Add(AttendanceAddDto attendanceAddDto)
    {
        var attendance = new Attendance()
        {
            Status = attendanceAddDto.Status,
            QRCode = attendanceAddDto.QRCode,
            Date = attendanceAddDto.Date,
            StudentId = attendanceAddDto.StudentId,
            GroupId = attendanceAddDto.GroupId,
        };
        _unitOfWork.Attendance.Add(attendance);
        _unitOfWork.CompleteAsync();
    }

    public void Update(AttendanceUpdateDto attendanceUpdateDto)
    {
        var attendance = _unitOfWork.Attendance.GetById(attendanceUpdateDto.Id);
        if (attendance == null) return;
        
        attendance.Status = attendanceUpdateDto.Status;
        attendance.QRCode = attendanceUpdateDto.QRCode;
        attendance.Date = attendanceUpdateDto.Date;
        attendance.StudentId = attendanceUpdateDto.StudentId;
        attendance.GroupId = attendanceUpdateDto.CourseId;
        
        _unitOfWork.Attendance.Update(attendance);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(long id)
    {
        var attendance = _unitOfWork.Attendance.GetById(id);
        if (attendance == null) return;
        _unitOfWork.Attendance.Delete(attendance);
        _unitOfWork.CompleteAsync();
        _unitOfWork.CompleteAsync();
    }

    public AttendanceReadDto? Get(long id)
    {
        var attendance = _unitOfWork.Attendance.GetById(id);
        if (attendance == null) return null;
        return new AttendanceReadDto()
        {
            Id = attendance.Id,
            Status = attendance.Status,
            QRCode = attendance.QRCode,
            Date = attendance.Date,
            StudentId = attendance.StudentId,
            CourseId = attendance.GroupId,
        };
    }

    public List<AttendanceReadDto> GetAll(long groupId,long studentId)
    {
        var attendances = _unitOfWork.Attendance.GetStudentGroupAttendance(groupId,studentId);
        if (attendances != null)
            return attendances.Select(attendance => new AttendanceReadDto()
            {
                Id = attendance.Id,
                Status = attendance.Status,
                QRCode = attendance.QRCode,
                Date = attendance.Date,
                StudentId = attendance.StudentId,
                CourseId = attendance.GroupId,
            }).ToList();

        throw new ArgumentException("No attendances in this group");
    }
   
}