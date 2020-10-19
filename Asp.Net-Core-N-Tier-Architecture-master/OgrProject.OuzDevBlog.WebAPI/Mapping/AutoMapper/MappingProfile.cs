using AutoMapper;
using OgProject.OuzDevBlog.Entities.Concrate;
using OgrProject.OuzDevBlog.DTO.DTOs;
using OgrProject.OuzDevBlog.DTO.DTOs.CategoryDTOs;
using OgrProject.OuzDevBlog.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OgrProject.OuzDevBlog.WebAPI.Mapping.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

       //---------------------------------------------

            CreateMap<ArticleListDTO, Article>();
            CreateMap<Article, ArticleListDTO>();

            CreateMap<ArticleUpdateModel, Article>();
            CreateMap<Article, ArticleUpdateModel>();

            CreateMap<ArticleAddModel, Article>();
            CreateMap<Article, ArticleAddModel>();

      //---------------------------------------------

            CreateMap<CategoryAddDTO, Category>();
            CreateMap<Category, CategoryAddDTO>();

            CreateMap<CategoryListDTO, Category>();
            CreateMap<Category, CategoryListDTO>();

            CreateMap<CategoryUpdateDTO, Category>();
            CreateMap<Category, CategoryUpdateDTO>();

      //----------------------------------------------
            






        }
    }
}
