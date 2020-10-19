using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OgProject.OuzDevBlog.BusinessLayer.Abstract;
using OgProject.OuzDevBlog.Entities.Concrate;
using OgrProject.OuzDevBlog.DTO.DTOs;
using OgrProject.OuzDevBlog.WebAPI.Models;

namespace OgrProject.OuzDevBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : BaseController
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;
        public ArticlesController(IArticleService articleService,IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<ArticleListDTO>>(await _articleService.GetAllSortedByPostedTimeAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
         {
            return Ok(_mapper.Map<ArticleListDTO>(await _articleService.FindByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ArticleAddModel articleAddModel)
        {
            var uploadModel = await UploadFileAsync(articleAddModel.Image,"image/jpeg");
            if (uploadModel.UploadState==Enums.UploadState.Success)
            {

                articleAddModel.ImagePath = uploadModel.NewName;
                await _articleService.AddAsync(_mapper.Map<Article>(articleAddModel));
                return Created("", articleAddModel);

            }
            else if (uploadModel.UploadState==Enums.UploadState.NotExist)
            {
                await _articleService.AddAsync(_mapper.Map<Article>(articleAddModel));
                return Created("", articleAddModel);

            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm]ArticleUpdateModel articleUpdateModel)
        {
            

            if (id != articleUpdateModel.Id)
            {
                return BadRequest("Id bulunamadı. Geçersiz Id");
            }
           
            var uploadModel = await UploadFileAsync(articleUpdateModel.Image, "image/jpeg");
            if (uploadModel.UploadState == Enums.UploadState.Success)
            {
                var updateArticle = await _articleService.FindByIdAsync(articleUpdateModel.Id);
                updateArticle.ImagePath = uploadModel.NewName;
                updateArticle.Description = articleUpdateModel.Description;
                updateArticle.ShortDescription = articleUpdateModel.ShortDescription;
                updateArticle.Title = articleUpdateModel.Title;

                await _articleService.UpdateAsync(updateArticle);
                return NoContent();

            }
            else if (uploadModel.UploadState == Enums.UploadState.NotExist)
            {
                var updateArticle = await _articleService.FindByIdAsync(articleUpdateModel.Id);
                updateArticle.Description = articleUpdateModel.Description;
                updateArticle.ShortDescription = articleUpdateModel.ShortDescription;
                updateArticle.Title = articleUpdateModel.Title;
                await _articleService.UpdateAsync(updateArticle);
                return NoContent();
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _articleService.DeleteAsync(new Article { Id = id });
            return NoContent();

        }

        

    }
}
