﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class SharedController : Controller
    {
      public JsonResult UploadImage()
        {
            JsonResult result = new JsonResult();

            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            try
            {
                var file = Request.Files[0];

                var filename = Guid.NewGuid() + Path.GetExtension(file.FileName);

             
                var path = Path.Combine(Server.MapPath("~/content/images"),filename);
                file.SaveAs(path);

                result.Data = new { Success = true,  ImageURL = string.Format("/content/images/{0}",filename) };

                //var newImage = new Image() { Name = filename };
                //if (ImageService.Instance.SaveNewImage(newImage))
                //{
                //    result.Data = new { Success = true, Image = filename, File = newImage.ID, ImageURL = string.Format("{0}{1}", Variables.ImageFolderPath, filename) };
                //}
                //else
                //{
                //    result.Data = new { success = false, Message = new HttpStatusCodeResult(500) };
                //}

            }
            catch(Exception ex)
            {
                result.Data = new { Success = false, Message = ex.Message };
            }
            return result;
        }
    }
}