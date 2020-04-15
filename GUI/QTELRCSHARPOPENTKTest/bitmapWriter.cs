using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.IO;

/*
 * This class contains functions for manipulating bitmaps
 * It is not currently being used
 */
 
namespace QTELR_Interface
{
    static class bitmapWriter
    {
        // Converts a WritableBitmap to a Bitmap
        public static Bitmap BitmapFromWriteableBitmap(WriteableBitmap writeBmp)
        {
            Bitmap bmp;
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create((BitmapSource)writeBmp));
                enc.Save(outStream);
                bmp = new System.Drawing.Bitmap(outStream);
            }
            return bmp;
        }

//        private static async Task SaveWriteableBitmapAsJpeg(WriteableBitmap bmp, string fileName)
//        {
//            // Create file in Pictures library and write jpeg to it
//            var outputFile = await KnownFolders.PicturesLibrary.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
//            using (var writeStream = await outputFile.OpenAsync(FileAccessMode.ReadWrite))
//            {
//                await EncodeWriteableBitmap(bmp, writeStream, BitmapEncoder.JpegEncoderId);
//            }
//            return outputFile;
//        }

//        private static async Task EncodeWriteableBitmap(WriteableBitmap bmp, IRandomAccessStream writeStream, Guid encoderId)
//        {
//            // Copy buffer to pixels
//            byte[] pixels;
//            using (var stream = bmp.PixelBuffer.AsStream())
//            {
//                pixels = new byte[(uint)stream.Length];
//                await stream.ReadAsync(pixels, 0, pixels.Length);
//            }

//            // Encode pixels into stream
//            var encoder = await BitmapEncoder.CreateAsync(encoderId, writeStream);
//            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied,
//               (uint)bmp.PixelWidth, (uint)bmp.PixelHeight,
//               96, 96, pixels);
//            await encoder.FlushAsync();
//        }
    }
}
