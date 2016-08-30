using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrainingDiary.Controllers
{
    public class User1
    {
        public int Id;
        public string Name;
    }
    public class UsersController : BaseController
    {
        //todo: unity, resharper, services
        // GET api/values
        public IEnumerable<User1> Get()
        {
           // return new string[] { "value1", "value2" };
            return new List<User1>() { new User1 { Id = 0, Name = "John Doe" }};
        }

        // GET api/values/5
        public User1 Get(int id)
        {
            //return "value";
            return new User1 { Id = 1, Name = "John Doe 111" };
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(User1 user)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
