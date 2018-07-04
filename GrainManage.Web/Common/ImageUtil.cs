using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Transforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Common
{
    public class ImageUtil
    {
        public static void BuildCompLogo(string imgPath, string logoPath)
        {
            using (Image<Rgba32> image = Image.Load(imgPath))
            {
                var width = 0;
                var height = 0;
                if (image.Height > 170)
                {
                    height = 170;
                }
                width = Convert.ToInt32(((decimal)height / image.Height) * image.Width);
                image.Mutate(x => x.Resize(width, height));
                image.Save(logoPath);
            }
        }
    }
}
