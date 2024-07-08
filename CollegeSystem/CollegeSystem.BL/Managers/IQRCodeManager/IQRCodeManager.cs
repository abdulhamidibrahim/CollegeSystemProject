using System.Drawing;
using System.IO;


namespace CollegeSystem.DL;

public interface IQRCodeManager
{
    public byte[] GenerateQRCode(string text);
    bool ValidateQRCode(string qrCode);
}