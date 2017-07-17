using DataBase.GrainManage.Models;
using GrainManage.Common;
using GrainManage.Web.Models.District;
using GrainManage.Web.Models.Image;
using GrainManage.Web.Util;
using GrainManage.Web.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrainManage.Web.Controllers
{
    public class ImageController : BaseController
    {
        public ActionResult GetImages(InputGetImages input)
        {
            var result = new BaseOutput();
            int total = 0;
            var creator = UserName;
            var repo = GetRepo<Image>();
            var list = repo.GetPaged(out total, input.PageIndex, input.PageSize, f => f.Creator == creator, o => o.Id, false);
            if (!list.Any())
            {
                SetResponse(s => s.NoData, input, result);
            }
            else
            {
                result.total = total;
                result.data = MapTo<List<ImageDto>>(list);
                if (input.DesiredSize != null && input.DesiredSize.Width > 0 && input.DesiredSize.Height > 0)
                {
                    foreach (var image in result.data)
                    {
                        image.File = GetThumb(input.DesiredSize.Width, input.DesiredSize.Height, image.File);
                    }
                }
                SetResponse(s => s.Success, input, result);
            }
            return JsonNet(result);
        }
        public ActionResult ValidateCode()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(4);
            Session[GlobalVar.ValidateCode] = code;
            byte[] bytes = vCode.CreateValidateGraphic2(code);
            return File(bytes, @"image/jpeg");
        }
        public ActionResult GetImageUrl(int[] imageIds)
        {
            var result = new BaseOutput();
            var userName = UserName;
            var repo = GetRepo<Image>();
            var images = repo.GetFiltered(f => imageIds.Contains(f.Id) && f.Creator == userName).ToList();
            var dic = new Dictionary<int, string>();
            foreach (var imageId in imageIds)
            {
                var image = images.Where(f => f.Id == imageId).FirstOrDefault();
                if (image != null)
                {
                    var absolutePath = GetAbsolutePath(userName, image.ImageName);
                    if (IsFileExists(absolutePath))
                    {
                        dic[imageId] = GetImageUrl(imageId, userName);
                    }
                }
            }
            SetResponse(s => s.Success, null, result);
            result.data = dic;
            return JsonNet(result);
        }

        public ActionResult Download(int imageID)
        {
            var creator = UserName;
            var repo = GetRepo<Image>();
            var image = repo.GetFiltered(f => f.Creator == creator && f.Id == imageID).First();
            var absolutePath = GetAbsolutePath(creator, image.ImageName);
            var data = ReadFile(absolutePath);
            return File(data, "image/jpeg");
        }

        public ActionResult DownloadSizedImage(int imageID, int width, int height)
        {
            var userName = UserName;
            var repo = GetRepo<Image>();
            var image = repo.GetFiltered(f => f.Id == imageID && f.Creator == userName).First();
            var absolutePath = GetAbsolutePath(userName, image.ImageName);
            var data = ReadFile(absolutePath);
            if (width > 0 && height > 0)
            {
                data = GetThumb(width, height, data);
            }
            return File(data, "image/jpeg");
        }
        public ActionResult Insert(InputInsert input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var creator = UserName;
            var result = new BaseOutput();
            input.Image.Creator = creator;
            var repo = GetRepo<Image>();
            int imageID = repo.GetFiltered(f => f.ImageName == input.Image.ImageName && f.Creator == creator).Select(s => s.Id).FirstOrDefault();
            if (imageID > 0)
            {
                SetResponse(s => s.FileHasExist, input, result);
            }
            else
            {
                var image = repo.Add(MapTo<Image>(input.Image));
                result.data = image.Id;
                if (image.Id > 0)
                {
                    var absolutePath = GetAbsolutePath(UserName, image.ImageName);
                    SaveFile(absolutePath, input.Image.File);
                    SetResponse(s => s.Success, input, result);
                }
                else
                {
                    SetResponse(s => s.InsertFailed, input, result);
                }
            }
            return JsonNet(result);
        }

        public ActionResult Update(InputUpdate input)
        {
            if (IsGetRequest)
            {
                return View(input);
            }
            var result = new BaseOutput();
            var image = input.Image;
            image.Creator = UserName;
            var repo = GetRepo<Image>();
            var model = repo.GetFiltered(f => f.Id == image.ImageId && f.Creator == image.Creator, true).First();
            var oldImageName = model.ImageName;
            model.ImageName = image.ImageName;
            model.Creator = image.Creator;
            model.Remark = image.Remark;
            model.Modified = DateTime.Now;
            repo.UnitOfWork.SaveChanges();
            if (image.File != null)
            {
                var absolutePath = GetAbsolutePath(image.Creator, oldImageName);
                DeleteFile(absolutePath);
                SaveFile(absolutePath, input.Image.File);
            }
            SetResponse(s => s.Success, input, result);
            return JsonNet(result);
        }
        public ActionResult Delete(int imageID)
        {
            var result = new BaseOutput();
            var creator = UserName;
            var repo = GetRepo<Image>();
            var model = repo.GetFiltered(f => f.Id == imageID && f.Creator == creator).FirstOrDefault();
            if (model != null)
            {
                repo.Delete(model);
            }
            var path = GetAbsolutePath(creator, model.ImageName);
            if (IsFileExists(path))
            {
                System.IO.File.Delete(path);
            }
            SetResponse(s => s.Success, null, result);
            return JsonNet(result);
        }

        private string GetImageUrl(int imageID, string userName)
        {
            var repo = GetRepo<Image>();
            var model = repo.GetFiltered(f => f.Id == imageID && f.Creator == userName).FirstOrDefault();
            if (string.IsNullOrEmpty(userName))
            {
                return string.Format("{0}/{1}", AppConfig.GetValue("ImageServerPath"), model.ImageName);
            }
            else
            {
                return string.Format("{0}/{1}/{2}", AppConfig.GetValue("ImageServerPath"), userName, model.ImageName);
            }
        }

        //生成缩略图
        private byte[] GetThumb(int width, int height, byte[] data)
        {
            var thumbData = data;
            if (data != null)
            {
                thumbData = new Thumbnail().GetThumbnail(width, height, data, Thumbnail.ResizeType.Zoom);
            }
            return thumbData;
        }

        private string GetAbsolutePath(string userName, string imageName)
        {
            var rootPath = AppConfig.GetValue("ImagePath");
            var absolutePath = string.IsNullOrEmpty(userName) ? Path.Combine(rootPath, imageName) : Path.Combine(rootPath, userName, imageName);
            return absolutePath;
        }

        private bool SaveFile(string absolutePath, byte[] photo)
        {
            bool isSuccess = false;
            if (photo != null && !IsFileExists(absolutePath))
            {
                var directoryPath = Path.GetDirectoryName(absolutePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                System.IO.File.WriteAllBytes(absolutePath, photo);
                isSuccess = true;
            }
            return isSuccess;
        }

        private byte[] ReadFile(string absolutePath)
        {
            byte[] file = null;
            if (IsFileExists(absolutePath))
            {
                file = System.IO.File.ReadAllBytes(absolutePath);
            }
            return file;
        }

        private bool DeleteFile(string absolutePath)
        {
            bool isSuccess = false;
            if (IsFileExists(absolutePath))
            {
                System.IO.File.Delete(absolutePath);
                isSuccess = true;
            }
            return isSuccess;
        }

        private bool IsFileExists(string absolutePath)
        {
            return System.IO.File.Exists(absolutePath);
        }

    }
}
