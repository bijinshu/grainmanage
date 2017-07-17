using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace GrainManage.Web.Common
{
    public class ValidateCode
    {
        /// <summary>
        /// 创建验证码的图片
        /// </summary>
        /// <param name="containsPage">要输出到的page对象</param>
        /// <param name="validateNum">验证码</param>
        public byte[] CreateValidateGraphic1(string validateCode)
        {
            Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 12.0), 22);
            Graphics g = Graphics.FromImage(image);
            //生成随机生成器
            Random random = new Random();
            try
            {
                //清空图片背景色
                g.Clear(Color.White);
                //画图片的干扰线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                Rectangle rectangle = new Rectangle(0, 0, image.Width, image.Height);
                using (LinearGradientBrush brush = new LinearGradientBrush(rectangle, Color.Blue, Color.DarkRed, 1.2f, true))
                {
                    g.DrawString(validateCode, font, brush, 3, 2);
                }

                //画图片的前景干扰点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //保存图片数据
                using (MemoryStream stream = new MemoryStream())
                {
                    image.Save(stream, ImageFormat.Jpeg);
                    //输出图片流
                    return stream.ToArray();
                }
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        public byte[] CreateValidateGraphic2(string validateCode)
        {
            int codeW = 80;
            int codeH = 22;
            //颜色列表，用于验证码、噪线、噪点 
            Color[] color = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.Brown, Color.DarkBlue };
            //字体列表，用于验证码 
            string[] font = { "Times New Roman", "Verdana", "Arial", "Gungsuh", "Impact" };
            Random rnd = new Random();
            //生成验证码字符串 

            //创建画布
            Bitmap bmp = new Bitmap(codeW, codeH);
            Graphics g = Graphics.FromImage(bmp);
            try
            {
                g.Clear(Color.White);
                //画噪线 
                for (int i = 0; i < 1; i++)
                {
                    int x1 = rnd.Next(codeW);
                    int y1 = rnd.Next(codeH);
                    int x2 = rnd.Next(codeW);
                    int y2 = rnd.Next(codeH);
                    Color clr = color[rnd.Next(color.Length)];
                    g.DrawLine(new Pen(clr), x1, y1, x2, y2);
                }
                //画验证码字符串 
                for (int i = 0; i < validateCode.Length; i++)
                {
                    Font ft = new Font(font[rnd.Next(font.Length)], 16);
                    Color clr = color[rnd.Next(color.Length)];
                    using (SolidBrush brush = new SolidBrush(clr))
                    {
                        g.DrawString(validateCode[i].ToString(), ft, brush, (float)i * 18 + 2, (float)0);
                    }
                }
                //画噪点 
                for (int i = 0; i < 100; i++)
                {
                    int x = rnd.Next(bmp.Width);
                    int y = rnd.Next(bmp.Height);
                    Color clr = color[rnd.Next(color.Length)];
                    bmp.SetPixel(x, y, clr);
                }

                //将验证码图片写入内存流，并将其以 "image/Png" 格式输出 
                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            finally
            {
                g.Dispose();
                bmp.Dispose();
            }

        }

        public string CreateValidateCode(int length)
        {
            //const string character = "abcdefghijklmnopqrstuvwxyz0123456ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] character = { '2', '3', '4', '5', '6', '8', '9', 'a', 'b', 'd', 'e', 'f', 'h', 'k', 'm', 'n', 'r', 'x', 'y', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };
            string randomcode = String.Empty;
            //生成一定长度的验证码  
            System.Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                randomcode += character[random.Next(character.Length)];
            }
            return randomcode;
        }
    }
}