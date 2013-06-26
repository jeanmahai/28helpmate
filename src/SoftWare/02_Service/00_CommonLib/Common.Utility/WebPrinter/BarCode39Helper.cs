using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Reflection;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace Common.Utility
{
    public class BarCode39Helper
    {
        public static byte[] DrawImage(double height, string codeValue)
        {
            codeValue = EncodeCode39(codeValue);
            string codeText = GetCodeText(codeValue);

            int pxHeight = (int)(ToInches(height) * 96.0);
            int pxWidth = codeText.Length;

            Bitmap bitmap = new Bitmap(pxWidth, pxHeight, PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);

                Font valueFont = new Font("Arial", 9);
                SizeF valueSize = graphics.MeasureString(codeValue, valueFont);
                int pxh = (int)Math.Ceiling(pxHeight - valueSize.Height);

                Pen pen = new Pen(Color.White, 1);
                for (int i = 0; i < codeText.Length; i++)
                {
                    pen.Color = codeText.Substring(i, 1) == "|" ? Color.Black : Color.White;
                    graphics.DrawLine(pen, i, 0, i, pxh);
                }

                int codeValueLength = codeValue.Length;
                float splitWidth = (pxWidth - valueSize.Width) / (codeValueLength - 1);
                float fontWidth = valueSize.Width / codeValue.Length;

                PointF[] positions = new PointF[codeValueLength];
                for (int i = 0; i < codeValueLength; i++)
                {
                    float xPos = i * (splitWidth + fontWidth);
                    positions[i] = new PointF(xPos, pxHeight - 2);
                }

                graphics.TextContrast = 6;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                DrawDriverString(graphics, codeValue, valueFont, new SolidBrush(Color.Black), positions);
            }

            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }

        #region Helper

        private static string EncodeCode39(string codeText)
        {
            if (!codeText.StartsWith("*"))
            {
                codeText = "*" + codeText;
            }
            if (!codeText.EndsWith("*"))
            {
                codeText = codeText + "*";
            }
            return codeText;
        }

        public static double ToInches(double mmSize)
        {
            return mmSize / 25.4;
        }

        private static string GetCodeText(string codeText)
        {
            string zf = codeText.ToLower()
                .Replace("0", "_|_|__||_||_|")
                .Replace("1", "_||_|__|_|_||")
                .Replace("2", "_|_||__|_|_||")
                .Replace("3", "_||_||__|_|_|")
                .Replace("4", "_|_|__||_|_||")
                .Replace("5", "_||_|__||_|_|")
                .Replace("7", "_|_|__|_||_||")
                .Replace("6", "_|_||__||_|_|")
                .Replace("8", "_||_|__|_||_|")
                .Replace("9", "_|_||__|_||_|")
                .Replace("a", "_||_|_|__|_||")
                .Replace("b", "_|_||_|__|_||")
                .Replace("c", "_||_||_|__|_|")
                .Replace("d", "_|_|_||__|_||")
                .Replace("e", "_||_|_||__|_|")
                .Replace("f", "_|_||_||__|_|")
                .Replace("g", "_|_|_|__||_||")
                .Replace("h", "_||_|_|__||_|")
                .Replace("i", "_|_||_|__||_|")
                .Replace("j", "_|_|_||__||_|")
                .Replace("k", "_||_|_|_|__||")
                .Replace("l", "_|_||_|_|__||")
                .Replace("m", "_||_||_|_|__|")
                .Replace("n", "_|_|_||_|__||")
                .Replace("o", "_||_|_||_|__|")
                .Replace("p", "_|_||_||_|__|")
                .Replace("r", "_||_|_|_||__|")
                .Replace("q", "_|_|_|_||__||")
                .Replace("s", "_|_||_|_||__|")
                .Replace("t", "_|_|_||_||__|")
                .Replace("u", "_||__|_|_|_||")
                .Replace("v", "_|__||_|_|_||")
                .Replace("w", "_||__||_|_|_|")
                .Replace("x", "_|__|_||_|_||")
                .Replace("y", "_||__|_||_|_|")
                .Replace("z", "_|__||_||_|_|")
                .Replace("-", "_|__|_|_||_||")
                .Replace("*", "_|__|_||_||_|")
                .Replace("/", "_|__|__|_|__|")
                .Replace("%", "_|_|__|__|__|")
                .Replace("+", "_|__|_|__|__|")
                .Replace(".", "_||__|_|_||_|");
            return zf;
        }

        #endregion

        #region DrawDriverString

        private enum DriverStringOptions
        {
            CmapLookup = 1,
            Vertical = 2,
            Advance = 4,
            LimitSubpixel = 8,
        }

        public static void DrawDriverString(Graphics graphics, string text, Font font, Brush brush, PointF[] positions)
        {
            DrawDriverString(graphics, text, font, brush, positions, null);
        }

        public static void DrawDriverString(Graphics graphics, string text, Font font, Brush brush, PointF[] positions, Matrix matrix)
        {
            if (graphics == null)
                throw new ArgumentNullException("graphics");
            if (text == null)
                throw new ArgumentNullException("text");
            if (font == null)
                throw new ArgumentNullException("font");
            if (brush == null)
                throw new ArgumentNullException("brush");
            if (positions == null)
                throw new ArgumentNullException("positions");

            FieldInfo field = typeof(Graphics).GetField("nativeGraphics", BindingFlags.Instance | BindingFlags.NonPublic);
            IntPtr hGraphics = (IntPtr)field.GetValue(graphics);

            field = typeof(Font).GetField("nativeFont", BindingFlags.Instance | BindingFlags.NonPublic);
            IntPtr hFont = (IntPtr)field.GetValue(font);

            field = typeof(Brush).GetField("nativeBrush", BindingFlags.Instance | BindingFlags.NonPublic);
            IntPtr hBrush = (IntPtr)field.GetValue(brush);

            IntPtr hMatrix = IntPtr.Zero;
            if (matrix != null)
            {
                field = typeof(Matrix).GetField("nativeMatrix", BindingFlags.Instance | BindingFlags.NonPublic);
                hMatrix = (IntPtr)field.GetValue(matrix);
            }

            GdipDrawDriverString(hGraphics, text, text.Length, hFont, hBrush, positions, (int)DriverStringOptions.CmapLookup, hMatrix);
        }

        [DllImport("Gdiplus.dll", CharSet = CharSet.Unicode)]
        internal extern static int GdipMeasureDriverString(
            IntPtr graphics
            , string text
            , int length
            , IntPtr font
            , PointF[] positions
            , int flags
            , IntPtr matrix
            , ref RectangleF bounds);

        [DllImport("Gdiplus.dll", CharSet = CharSet.Unicode)]
        internal extern static int GdipDrawDriverString(
            IntPtr graphics
            , string text
            , int length
            , IntPtr font
            , IntPtr brush
            , PointF[] positions
            , int flags
            , IntPtr matrix);

        #endregion
    }
}
