using OgrProject.OuzDevBlog.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OgrProject.OuzDevBlog.DTO.DTOs.AppUserDTOs
{
    public class AppUserLoginDTO: IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
