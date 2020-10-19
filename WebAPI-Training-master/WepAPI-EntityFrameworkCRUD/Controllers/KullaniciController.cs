using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WepAPI_EntityFrameworkCRUD.Models;

namespace WepAPI_EntityFrameworkCRUD.Controllers
{
    [RoutePrefix("api/kullanicilar")]
    public class KullaniciController : ApiController
    {
        Entities db = new Entities();

        [Route("")]
        public IEnumerable<Kullanicilar> Get()
        {
            return db.Kullanicilar.ToList();
        }

        [Route("{id:int}", Name = "GetById")]
        public HttpResponseMessage Get(int id)
        {
            // Eğer id ye sahip bir kullanıcı olmadığı zmana 200 kodlu bir cevap döneceği için bu kod satırını kullanmak yerine HttpStatusCode tipinde bir değer döndürmek en matıklısı olacaktır.
            //return db.Kullanicilar.FirstOrDefault(x => x.Id == id);

            Kullanicilar user = db.Kullanicilar.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $" {id}'si olan böyle bir kayıt bulunamadı.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }


        }


        [Route("add")]
        public HttpResponseMessage Post(Kullanicilar user)
        {
            //    db.Kullanicilar.Add(user);
            //    db.SaveChanges();

            //Eğer geriye Route Link oluşturup nesneyi döndürecek olursak bu kod bloğunu kullanıyoruz.
            //HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
            //response.Headers.Location = new Uri(Url.Link("GetById", new { id =user.Id }));
            //return response;


            try
            {
                db.Kullanicilar.Add(user);
                //Her zaman saveChanges metodu işlevini yerine getiremeyebilir. Bunun kontrolunu geri dönüş değerinden anlama şansımız vardır. Geri dönüş değeri 0'dan büyükse işlem başarılıdır. SaveChanges METODU GERİYE İNT TİPİNDE BİR DEĞER DÖNDÜRÜR.
                if ((db.SaveChanges()) > 0)
                {
                    /// Başarılı İşlem
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                else
                {
                    //Başarısız İşlem
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Veri Ekleme İşlemi Başarısız.");
                }

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("put")]
        public HttpResponseMessage Put(Kullanicilar user)
        {
            try
            {
                Kullanicilar putUser = new Kullanicilar
                {
                    Ad = user.Ad,
                    Soyad = user.Soyad,
                    Email = user.Email,
                    Telefon = user.Telefon

                };
                db.SaveChanges();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Headers.Location = new Uri(Url.Link("GetById", new { id = user.Id }));
                return response;


            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }


        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var user = db.Kullanicilar.Find(id);
                db.Kullanicilar.Remove(user);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Kayıt başarıyla silindi.");

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }



    }
}
