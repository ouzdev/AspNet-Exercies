using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OgrProject.OuzDevBlog.WebAPI.Models;

namespace OgrProject.OuzDevBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public async Task<UploadModel> UploadFileAsync(IFormFile file, string contentType)
        {
            UploadModel uploadModel = new UploadModel();
            if (file != null)
            {
                if (file.ContentType != contentType)
                {
                    uploadModel.ErrorMessage = "Dosya uzantısı geçersiz. Lütfen Resim (jpeg) seçiniz.";
                    uploadModel.UploadState = Enums.UploadState.Error;
                    return uploadModel;
                }
                else
                {
                    var newName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + newName);
                    var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);

                    uploadModel.NewName = newName;
                    uploadModel.UploadState = Enums.UploadState.Success;
                    return uploadModel;
                }
            }
            uploadModel.ErrorMessage = "Dosya Bulunamadı !";
            uploadModel.UploadState = Enums.UploadState.NotExist;
            return uploadModel;
        }
    }
}
