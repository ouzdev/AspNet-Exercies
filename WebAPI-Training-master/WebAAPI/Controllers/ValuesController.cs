using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAAPI.Controllers
{

    public class ValuesController : ApiController
    {
        static List<string> degerler = new List<string>()
        { "value0","value1","value2"};
        // GET api/values

        [HttpGet]
        public IEnumerable<string> Degerler()
        {
            return degerler;
        }

        // GET api/values/5
        [HttpGet]
        public string TekDegerGetir(int id)
        {
            return degerler[id];
        }

        // POST api/values
        [HttpPost]
        public void DegerEkle([FromBody]string value)
        {
            degerler.Add(value);
        }

        // PUT api/values/57
        [HttpPut]
        public void DegerGuncelle(int id, [FromBody]string value)
        {
            degerler[id] = value;
        }

        // DELETE api/values/5
        [HttpDelete]
        public void DegerSil(int id)
        {
            degerler.RemoveAt(id);
        }
    }
}
