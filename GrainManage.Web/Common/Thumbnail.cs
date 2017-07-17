using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace GrainManage.Web.Common
{
    public sealed class Thumbnail
    {
        public enum ResizeType { Zoom, ZoomAndFilling, Cut }

        public byte[] GetThumbnail(int desiredWidth, int desiredHeight, byte[] data, ResizeType resizeType)
        {
            switch (resizeType)
            {
                case ResizeType.Zoom:
                    return ZoomThumbnail(data, desiredWidth, desiredHeight);
                case ResizeType.ZoomAndFilling:
                    return ZoomThumbnailWithFilling(data, desiredWidth, desiredHeight);
                case ResizeType.Cut:
                    return CutThumbnail(data, desiredWidth, desiredHeight);
                default:
                    return null;
            }
        }

        public byte[] GetThumbnail(int desiredWidth, int desiredHeight, string srcImagePath, ResizeType resizeType)
        {
            switch (resizeType)
            {
                case ResizeType.Zoom:
                    return ZoomThumbnail(srcImagePath, desiredWidth, desiredHeight);
                case ResizeType.ZoomAndFilling:
                    return ZoomThumbnailWithFilling(srcImagePath, desiredWidth, desiredHeight);
                case ResizeType.Cut:
                    return CutThumbnail(srcImagePath, desiredWidth, desiredHeight);
                default:
                    return null;
            }
        }

        private byte[] ZoomThumbnail(byte[] data, int desiredWidth, int desiredHeight)
        {
            var srcImage = System.Drawing.Image.FromStream(new System.IO.MemoryStream(data));
            var thumbSize = new Size
            {
                Width = desiredWidth < srcImage.Width ? desiredWidth : srcImage.Width,
                Height = desiredHeight < srcImage.Height ? desiredHeight : srcImage.Height
            };

            if (srcImage.Width * thumbSize.Height > srcImage.Height * thumbSize.Width)
            {
                thumbSize.Height = Convert.ToInt32(((double)srcImage.Height / srcImage.Width) * thumbSize.Width);
            }
            else
            {
                thumbSize.Width = Convert.ToInt32(((double)srcImage.Width / srcImage.Height) * thumbSize.Height);
            }

            return MakeThumbnail(srcImage, thumbSize);
        }

        private byte[] ZoomThumbnailWithFilling(byte[] data, int desiredWidth, int desiredHeight)
        {
            var srcImage = Image.FromStream(new System.IO.MemoryStream(data));
            var thumbSize = new Size
            {
                Width = desiredWidth < srcImage.Width ? desiredWidth : srcImage.Width,
                Height = desiredHeight < srcImage.Height ? desiredHeight : srcImage.Height
            };
            var destRect = new Rectangle
            {
                Width = thumbSize.Width,
                Height = thumbSize.Height
            };
            var srcRect = new Rectangle
            {
                Width = srcImage.Width,
                Height = srcImage.Height
            };

            if (srcRect.Width * thumbSize.Height > srcRect.Height * thumbSize.Width)
            {
                destRect.Height = Convert.ToInt32(((double)srcRect.Height / srcRect.Width) * thumbSize.Width);
                destRect.Y = (thumbSize.Height - destRect.Height) / 2;
            }
            else
            {
                destRect.Width = Convert.ToInt32(((double)srcRect.Width / srcRect.Height) * thumbSize.Height);
                destRect.X = (thumbSize.Width - destRect.Width) / 2;
            }

            return MakeThumbnail(srcImage, thumbSize, destRect, srcRect);
        }

        private byte[] CutThumbnail(byte[] data, int desiredWidth, int desiredHeight)
        {
            var srcImage = Image.FromStream(new System.IO.MemoryStream(data));
            var thumbSize = new Size
            {
                Width = desiredWidth < srcImage.Width ? desiredWidth : srcImage.Width,
                Height = desiredHeight < srcImage.Height ? desiredHeight : srcImage.Height
            };
            var destRect = new Rectangle
            {
                Width = thumbSize.Width,
                Height = thumbSize.Height
            };
            var srcRect = new Rectangle
            {
                Width = srcImage.Width,
                Height = srcImage.Height
            };
            if (srcRect.Width * thumbSize.Height > srcRect.Height * thumbSize.Width)
            {
                srcRect.Width = srcRect.Height * thumbSize.Width / thumbSize.Height;
                srcRect.X = (srcImage.Width - srcRect.Width) / 2;
            }
            else
            {
                srcRect.Height = srcImage.Width * thumbSize.Height / thumbSize.Width;
                srcRect.Y = (srcImage.Height - srcRect.Height) / 2;
            }

            return MakeThumbnail(srcImage, thumbSize, destRect, srcRect);
        }

        private byte[] ZoomThumbnail(string srcImagePath, int desiredWidth, int desiredHeight)
        {
            var srcImage = Image.FromFile(srcImagePath);
            var thumbSize = new Size
            {
                Width = desiredWidth < srcImage.Width ? desiredWidth : srcImage.Width,
                Height = desiredHeight < srcImage.Height ? desiredHeight : srcImage.Height
            };

            if (srcImage.Width * thumbSize.Height > srcImage.Height * thumbSize.Width)
            {
                thumbSize.Height = Convert.ToInt32(((double)srcImage.Height / srcImage.Width) * thumbSize.Width);
            }
            else
            {
                thumbSize.Width = Convert.ToInt32(((double)srcImage.Width / srcImage.Height) * thumbSize.Height);
            }

            return MakeThumbnail(srcImage, thumbSize);
        }

        private byte[] ZoomThumbnailWithFilling(string srcImagePath, int desiredWidth, int desiredHeight)
        {
            var srcImage = Image.FromFile(srcImagePath);
            var thumbSize = new Size
            {
                Width = desiredWidth < srcImage.Width ? desiredWidth : srcImage.Width,
                Height = desiredHeight < srcImage.Height ? desiredHeight : srcImage.Height
            };
            var destRect = new Rectangle
            {
                Width = thumbSize.Width,
                Height = thumbSize.Height
            };
            var srcRect = new Rectangle
            {
                Width = srcImage.Width,
                Height = srcImage.Height
            };

            if (srcRect.Width * thumbSize.Height > srcRect.Height * thumbSize.Width)
            {
                destRect.Height = Convert.ToInt32(((double)srcRect.Height / srcRect.Width) * thumbSize.Width);
                destRect.Y = (thumbSize.Height - destRect.Height) / 2;
            }
            else
            {
                destRect.Width = Convert.ToInt32(((double)srcRect.Width / srcRect.Height) * thumbSize.Height);
                destRect.X = (thumbSize.Width - destRect.Width) / 2;
            }

            return MakeThumbnail(srcImage, thumbSize, destRect, srcRect);
        }

        private byte[] CutThumbnail(string srcImagePath, int desiredWidth, int desiredHeight)
        {
            var srcImage = Image.FromFile(srcImagePath);
            var thumbSize = new Size
            {
                Width = desiredWidth < srcImage.Width ? desiredWidth : srcImage.Width,
                Height = desiredHeight < srcImage.Height ? desiredHeight : srcImage.Height
            };
            var destRect = new Rectangle
            {
                Width = thumbSize.Width,
                Height = thumbSize.Height
            };
            var srcRect = new Rectangle
            {
                Width = srcImage.Width,
                Height = srcImage.Height
            };
            if (srcRect.Width * thumbSize.Height > srcRect.Height * thumbSize.Width)
            {
                srcRect.Width = srcRect.Height * thumbSize.Width / thumbSize.Height;
                srcRect.X = (srcImage.Width - srcRect.Width) / 2;
            }
            else
            {
                srcRect.Height = srcImage.Width * thumbSize.Height / thumbSize.Width;
                srcRect.Y = (srcImage.Height - srcRect.Height) / 2;
            }

            return MakeThumbnail(srcImage, thumbSize, destRect, srcRect);
        }

        private byte[] MakeThumbnail(Image srcImage, Size disiredSize, Rectangle destRect, Rectangle srcRect)
        {
            byte[] result = null;
            using (srcImage)
            {
                using (var destImage = new Bitmap(disiredSize.Width, disiredSize.Height))//新建一个bmp图片 
                {
                    using (var graphic = Graphics.FromImage(destImage))//新建一个画板 
                    {
                        graphic.InterpolationMode = InterpolationMode.High; //设置高质量插值法 
                        graphic.SmoothingMode = SmoothingMode.HighQuality; //设置高质量,低速度呈现平滑程度 
                        graphic.Clear(Color.Transparent);  //清空画布并以透明背景色填充 
                        graphic.DrawImage(srcImage, destRect, srcRect, GraphicsUnit.Pixel);  //在指定位置并且按指定大小绘制原图片的指定部分
                    }
                    using (var memory = new MemoryStream())
                    {
                        destImage.Save(memory, srcImage.RawFormat);
                        result = memory.ToArray();
                    }
                }
            }
            return result;
        }

        private byte[] MakeThumbnail(Image srcImage, Size thumbdSize)
        {
            byte[] result = null;
            using (srcImage)
            {
                using (var destImage = new Bitmap(thumbdSize.Width, thumbdSize.Height))//新建一个bmp图片 
                {
                    using (var graphic = Graphics.FromImage(destImage))//新建一个画板 
                    {
                        graphic.InterpolationMode = InterpolationMode.High; //设置高质量插值法 
                        graphic.SmoothingMode = SmoothingMode.HighQuality; //设置高质量,低速度呈现平滑程度 
                        graphic.Clear(Color.White);  //清空画布并以透明背景色填充 
                        graphic.DrawImage(srcImage,
                            new Rectangle { Width = thumbdSize.Width, Height = thumbdSize.Height },
                            new Rectangle { Width = srcImage.Width, Height = srcImage.Height },
                            GraphicsUnit.Pixel);  //在指定位置并且按指定大小绘制原图片的指定部分
                    }
                    using (var memory = new MemoryStream())
                    {
                        destImage.Save(memory, srcImage.RawFormat);
                        result = memory.ToArray();
                    }
                }
            }
            return result;
        }

        private ImageFormat GetImageFormat(string extension)
        {
            switch (extension.ToLower().Trim('.'))
            {
                case "jpg":
                    return ImageFormat.Jpeg;
                case "jpeg":
                    return ImageFormat.Jpeg;
                case "png":
                    return ImageFormat.Png;
                case "icon":
                    return ImageFormat.Icon;
                case "bmp":
                    return ImageFormat.Bmp;
                case "gif":
                    return ImageFormat.Gif;
                case "emf":
                    return ImageFormat.Emf;
                case "tiff":
                    return ImageFormat.Tiff;
                case "wmf":
                    return ImageFormat.Wmf;
                case "exif":
                    return ImageFormat.Exif;
                default:
                    return ImageFormat.Jpeg;
            }
        }

    }
}