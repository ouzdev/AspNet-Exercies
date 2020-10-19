using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAAPI.Models;

namespace WebAAPI.Controllers
{
    //RoutePrefix: Bu tanımlamayı yapmamızın amacı metodlara Route tanımlaması eklerken "api/employee" yazmaya gerek kalmadan sadece ilgili url tanımlamasını yazmamıza olanak tanır.

    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee { Id = 0, Name = "Mustafa" },
            new Employee { Id = 1, Name = "Burak" },
            new Employee { Id = 2, Name = "Yunus" },
            new Employee { Id = 3, Name = "Oğuzcan" }
        };
        // "" ifadesi id vs. gibi istek olmaz ise bu metod çağrılır.
        [Route("")]
        public IEnumerable<Employee> Get()
        {
            return employees;
        }
        // Route tanımlarken kısıtlayıcı kullanabiliyoruz. Bu sayede kullanıcı sadece int tipte bir istekte bulunduğunda bu metod tetikleniyor.

        // Default Value ve Optional: metodlara varsayılan değerler verebiliyoruz.

        // [Route("detail/{id:decimal?}")] -> Bu tarzda tanımlamalarde metod parametresinde mutlaka varsayılan değer verilmesi gereki (bkz. Employee(decimal = 2))

        // Bir diğer yöntemde
        // [Route("detail/{id:decimal=2}")] -> Bu tarzda tanımlamalarde metod parametresinde değer tanımlaması yapılmaz (bkz. Employee(decimal id))


        [Route("{id:int:max(4):min(0)}", Name = "GetById")]
        public Employee Get(int id)
        {
            return employees.FirstOrDefault(x => x.Id == id);
        }
        // Bu tanımlama ise sadece string türde istek olduğunda çağrılacak metodumuz.
        [Route("{name:alpha}")]
        public Employee Get(string name)
        {
            return employees.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }

        //Route tanımlamasıyla bu actionın url sini oluştururuz.
        // kullanıc id tanımlamasından sonra örneğin 5/tasks adında bir istekte bulunduğunda koşturulacak metodumuz bu metoddur.
        [Route("{id}/tasks")]
        public IEnumerable<string> GetEmployeeTask(int id)
        {
            switch (id)
            {
                case 0:
                    return new List<string> { "Task:1-1", "Task 1-2", "Task 1-3" };
                case 1:
                    return new List<string> { "Task:2-1", "Task 2-2", "Task 2-3" };
                case 2:
                    return new List<string> { "Task:3-1", "Task 3-2", "Task 3-3" };
                case 3:
                    return new List<string> { "Task:4-1", "Task 4-2", "Task 4-3" };
                default:
                    return null;
            }
        }
        // Burası en önemli kısım. Normalde "api/employee/api/tasks" gibi kullanıcı adında bir istekte bulunacağı yerde "api/employee" tanımlamasını ezip sadece "/api/tasks" olarak yazığında bu metod çağrılacaktır. Bu işlemi tilda "~" işareti üstlenmektedir. 
        [Route("~/api/tasks")]
        public IEnumerable<string> GetTasks()
        {
            return new List<string>{
                "Task:1-1", "Task 1-2", "Task 1-3","Task:2-1", "Task 2-2", "Task 2-3","Task:3-1", "Task 3-2", "Task 3-3" ,"Task:4-1", "Task 4-2", "Task 4-3"};
        }

        //Route Name ile Route Link Oluşturma

        // Teori: Ornek olarak db'ye bir insert işlemi gerçekleştirildiğinde geriye kaydedilen verinin değerlerini ve url bilgisini elde etmek için kullanılır. Mesela bir ad soyad'dan oluşan bir kayıdınız var ve kaydettikten sonra ekranda kaydedilen o verinin bilgilerini görmek istediğinizde WebApi tarafında bu veriyi ekrana getirmek için bir url oluşturulması gerekecektir. Tam olarak bu işlemi yapacak olan Route Link'dir.

        [Route("add")]
        public HttpResponseMessage Post(Employee emp)
        {
            emp.Id = employees.Max(x => x.Id) + 1;
            employees.Add(emp);

            //Kalıbımız (tip)/(nesne adı)=(new) (nesne Tipi(Durum Kodu))

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Url.Link("GetById", new { id = emp.Id }));

            return response;

        }

    }
}



