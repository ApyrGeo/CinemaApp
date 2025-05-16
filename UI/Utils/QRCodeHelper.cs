using System;
using System.Drawing;
using IronBarCode;

namespace CinemaApp.UI.Utils;

public static class QRCodeHelper
{
    public static Bitmap EncodeToQRCode(string json)
    {
        var qr = QRCodeWriter.CreateQrCode(json, 400);
        return qr.ToBitmap();
    }

    public static string DecodeQRCode(Bitmap qrCodeImage)
    {
        BarcodeResults results = BarcodeReader.Read(qrCodeImage);

        if (results == null || results.Count == 0)
            throw new InvalidOperationException("QR code could not be decoded.");

        // Just take first decoded barcode's text
        BarcodeResult firstResult = results[0];

        if (string.IsNullOrWhiteSpace(firstResult.Text))
            throw new InvalidOperationException("Decoded text is empty.");

        return firstResult.Text;
    }
}
