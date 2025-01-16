using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Belyakov.Forms
{
    /// <summary>
    /// Interaction logic for Cap.xaml
    /// </summary>
    public partial class Cap : Window
    {
        public Cap()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            captchaText = GenerateRandomText(6);
            Bitmap captchaBitmap = GenerateCaptchaImage(captchaText);
            Captcha.Source = ConvertBitmapToBitmapSource(captchaBitmap);
        }

        private Bitmap GenerateCaptchaImage(string text)
        {
            int width = 200;
            int height = 100; 
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                Random rand = new Random();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int gray = rand.Next(256);
                        g.FillRectangle(new SolidBrush(System.Drawing.Color.FromArgb(gray, gray, gray)), x, y, 1, 1);
                    }
                }

                Font font = new Font("Arial", 20, System.Drawing.FontStyle.Bold);
                System.Drawing.Brush textBrush = System.Drawing.Brushes.Black;

                SizeF textSize = g.MeasureString(text, font);

                float startX = (width - textSize.Width) / 2;

                for (int i = 0; i < text.Length; i++)
                {
                    float waveHeight = (float)(Math.Sin(i + DateTime.Now.Second) * 10);                 
                    g.DrawString(text[i].ToString(), font, textBrush, new PointF(startX + i * 18, height / 2 + waveHeight));
                }
            }

            return bitmap;
        }
        string captchaText = String.Empty;

        private string GenerateRandomText(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] stringChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }
        private BitmapSource ConvertBitmapToBitmapSource(Bitmap bitmap)
        {
            IntPtr hBitmap = bitmap.GetHbitmap();
            BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                hBitmap,
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            DeleteObject(hBitmap);

            return bitmapSource;
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            captchaText = GenerateRandomText(6);
            Bitmap captchaBitmap = GenerateCaptchaImage(captchaText);
            Captcha.Source = ConvertBitmapToBitmapSource(captchaBitmap);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
