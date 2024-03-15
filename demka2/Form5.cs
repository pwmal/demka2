using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demka2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            barcode("1267304506");
        }

        public void barcode(string nums, int resolution = 20)
        {
            float height = 25.93f * resolution;
            float lineHeight = 22.85f * resolution;
            float leftOffset = 3.63f * resolution;
            float rightOffset = 2.31f * resolution;
            float longLineHeight = lineHeight + 1.65f * resolution;
            float numHeight = 2.75f * resolution;
            float lineToFontOffset = 0.165f * resolution;
            float lineNumWidth = 0.15f * resolution;
            float lineWidthFull = 1.35f * resolution;
            float lineOffset = 0.2f * resolution;

            float width = leftOffset + rightOffset + 6 * (lineNumWidth + lineOffset) + nums.Length * (lineWidthFull + lineOffset);
            Bitmap bitmap = new Bitmap((int)width, (int)height);
            Graphics g = Graphics.FromImage(bitmap);

            Font font = new Font("Arial", 48, FontStyle.Regular, GraphicsUnit.Pixel);
            StringFormat fontFormat = new StringFormat();
            fontFormat.Alignment = StringAlignment.Center;
            fontFormat.LineAlignment = StringAlignment.Center;

            float x = leftOffset;
            

            g.FillRectangle(Brushes.Black, x, 0, lineToFontOffset, longLineHeight);
            x += lineNumWidth*3;
            g.FillRectangle(Brushes.Black, x, 0, lineToFontOffset, longLineHeight);
            x += lineNumWidth * 3;

            for (int i = 0; i < nums.Length; i++)
            {
                RectangleF fontRect = new RectangleF(x, lineHeight + lineToFontOffset, lineWidthFull, numHeight);
                g.DrawString(nums[i].ToString(), font, Brushes.Black, fontRect, fontFormat);
                if (nums[i] == '0')
                {
                    g.FillRectangle(Brushes.Black, x, 0, lineWidthFull, lineHeight);
                    x += lineNumWidth * 10;
                    continue;
                }
                g.FillRectangle(Brushes.Black, x, 0, lineNumWidth * Convert.ToInt32(nums[i].ToString()), lineHeight);
                x += lineNumWidth * 10;
                if (i == nums.Length/2 || i == nums.Length - 1) 
                {
                    g.FillRectangle(Brushes.Black, x, 0, lineToFontOffset, longLineHeight);
                    x += lineNumWidth * 3;
                    g.FillRectangle(Brushes.Black, x, 0, lineToFontOffset, longLineHeight);
                    x += lineNumWidth * 3;
                }
            }

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // делаем чтобы картинка помещалась в pictureBox
            pictureBox1.Image = bitmap; // устанавливаем картинку
        }
    }
}
