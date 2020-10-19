using OgProject.OuzDevBlog.BusinessLayer.Abstract;
using OgProject.OuzDevBlog.DataAccessLayer.Abstarct;
using OgProject.OuzDevBlog.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace OgProject.OuzDevBlog.BusinessLayer.Concrate
{
   public class CommentManager:GenericManager<Comment>,ICommentService
    {
        private readonly IGenericDal<Comment> _genericDal;
        public CommentManager(IGenericDal<Comment> genericDal):base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
