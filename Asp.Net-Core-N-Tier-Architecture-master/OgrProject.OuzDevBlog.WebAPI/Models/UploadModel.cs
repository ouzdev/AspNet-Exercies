using OgrProject.OuzDevBlog.WebAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OgrProject.OuzDevBlog.WebAPI.Models
{
    public class UploadModel
    {
        public string NewName { get; set; }
        public string ErrorMessage { get; set; }
        public UploadState UploadState { get; set; }
    }
}
