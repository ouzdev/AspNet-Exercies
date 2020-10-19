using Microsoft.Extensions.DependencyInjection;
using OgProject.OuzDevBlog.BusinessLayer.Abstract;
using OgProject.OuzDevBlog.BusinessLayer.Concrate;
using OgProject.OuzDevBlog.DataAccessLayer.Abstarct;
using OgProject.OuzDevBlog.DataAccessLayer.Concrate.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OgProject.OuzDevBlog.BusinessLayer.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IArticleService, ArticleManager>();
            services.AddScoped<IArticleDal, EfArticleRepository>();
        }
    }
}
