using System.Drawing.Imaging;
using SkiaSharp;
using SkiaSharp;
using SkiaSharp.QrCode;
using SkiaSharp.QrCode.Models;
using System.IO;

namespace CollegeSystem.DL;

public class QRCodeManager : IQRCodeManager
{
    
    public QRCodeManager()
    {
        
    }
    public byte[] GenerateQRCode(string text)
    {
        var generator = new QRCodeGenerator();

        // Generate the QR code
        var qr = generator.CreateQrCode(text, ECCLevel.H);

        // Define the QR code drawing options
        var info = new SKImageInfo(256, 256);
        using var surface = SKSurface.Create(info);
        var canvas = surface.Canvas;
        canvas.Render(qr, 256, 256);

        // Encode the QR code to a PNG image
        using var image = surface.Snapshot();
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);
        using var stream = new MemoryStream();
        data.SaveTo(stream);
        return stream.ToArray();
    }

    public bool ValidateQRCode(string qrCode)
    {
        
        return true;
    }
}