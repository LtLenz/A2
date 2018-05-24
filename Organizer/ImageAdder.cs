using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace Organizer
{
    class ImageAdder
    {
        public static byte[] ImageToBytes(BitmapImage image)
        {
            MemoryStream stream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            encoder.Save(stream);
            return stream.ToArray();
        }

        public static BitmapImage BytesToImage(byte[] stream)
        {
            if (stream == null || stream.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(stream))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        
    }
}
