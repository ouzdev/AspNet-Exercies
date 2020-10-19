using OgProject.OuzDevBlog.BusinessLayer.Abstract;
using OgProject.OuzDevBlog.DataAccessLayer.Abstarct;
using OgProject.OuzDevBlog.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OgProject.OuzDevBlog.BusinessLayer.Concrate
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
      private readonly  IGenericDal<AppUser> _genericDal;
        public AppUserManager(IGenericDal<AppUser> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

    }
}
