using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GestIMG_UI
{
    public class ManipImage
    {
        private static WriteableBitmap filtrerCouleur(BitmapImage origine, byte indice)
        {
            WriteableBitmap wb = new WriteableBitmap(origine);
            uint[] pixel = new uint[wb.PixelWidth * wb.PixelHeight];
            wb.CopyPixels(pixel, 4 * wb.PixelWidth, 0);
            for (uint y = 0; y < wb.PixelHeight; y++)
                for (uint x = 0; x < wb.PixelWidth; x++)
                {
                    byte[] dd = BitConverter.GetBytes(pixel[y * wb.PixelWidth + x]);
                    if (indice != 0) dd[0] = 0;
                    if (indice != 1) dd[1] = 0;
                    if (indice != 2) dd[2] = 0;
                    pixel[y * wb.PixelWidth + x] = BitConverter.ToUInt32(dd, 0);
                }
            wb.WritePixels(new Int32Rect(0, 0, wb.PixelWidth, wb.PixelHeight), pixel, 4 * wb.PixelWidth, 0);
            return wb;
        }
        public static WriteableBitmap filtrerCouleurVert(BitmapImage origine)
        {
            return filtrerCouleur(origine, 1);
        }
        public static WriteableBitmap filtrerCouleurBleu(BitmapImage origine)
        {
            return filtrerCouleur(origine, 0);
        }
        public static WriteableBitmap filtrerCouleurRouge(BitmapImage origine)
        {
            return filtrerCouleur(origine, 2);
        }

        public static TransformedBitmap FlipHorizontal(BitmapImage origine)
        {
            TransformedBitmap tb = new TransformedBitmap();
            tb.BeginInit();
            tb.Source = origine.Clone();
            tb.Transform = new ScaleTransform(-1, 1, 0, 0);
            tb.EndInit();
            return tb;
        }

        public static TransformedBitmap FlipVertical(BitmapImage origine)
        {
            TransformedBitmap tb = new TransformedBitmap();
            tb.BeginInit();
            tb.Source = origine.Clone();
            tb.Transform = new ScaleTransform(1, -1, 0, 0);
            tb.EndInit();
            return tb;
        }

        public static FormatConvertedBitmap convertirGrayscale(BitmapImage origine)
        {
            FormatConvertedBitmap grayBitmapSource = new FormatConvertedBitmap();
            grayBitmapSource.BeginInit();
            grayBitmapSource.Source = origine;
            grayBitmapSource.DestinationFormat = PixelFormats.Gray32Float;
            grayBitmapSource.EndInit();
            return grayBitmapSource;
        }

        internal static WriteableBitmap transformerExposition(BitmapImage origine, int exposition)
        {
            WriteableBitmap wb = new WriteableBitmap(origine);
            uint[] pixel = new uint[wb.PixelWidth * wb.PixelHeight];
            wb.CopyPixels(pixel, 4 * wb.PixelWidth, 0);
            for (uint y = 0; y < wb.PixelHeight; y++)
                for (uint x = 0; x < wb.PixelWidth; x++)
                {
                    byte[] dd = BitConverter.GetBytes(pixel[y * wb.PixelWidth + x]);
                    int B = (int)dd[0] + exposition * 255 / 100;
                    int V = (int)dd[1] + exposition * 255 / 100;
                    int R = (int)dd[2] + exposition * 255 / 100;
                    dd[0] = (byte)((B < 0) ? 0 : (B > 255) ? 255 : B);
                    dd[1] = (byte)((V < 0) ? 0 : (V > 255) ? 255 : V);
                    dd[2] = (byte)((R < 0) ? 0 : (R > 255) ? 255 : R);
                    pixel[y * wb.PixelWidth + x] = BitConverter.ToUInt32(dd, 0);
                }
            wb.WritePixels(new Int32Rect(0, 0, wb.PixelWidth, wb.PixelHeight), pixel, 4 * wb.PixelWidth, 0);
            return wb;
        }
    }
}
