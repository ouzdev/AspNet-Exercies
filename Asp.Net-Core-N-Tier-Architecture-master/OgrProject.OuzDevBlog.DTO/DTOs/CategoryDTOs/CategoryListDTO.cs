using OgrProject.OuzDevBlog.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OgrProject.OuzDevBlog.DTO.DTOs.CategoryDTOs
{
    public class CategoryListDTO:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
