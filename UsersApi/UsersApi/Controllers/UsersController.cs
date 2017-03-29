using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UsersApi.Models;

namespace UsersApi.Controllers
{
    public class UsersController : ApiController
    {
        // GET: api/Users
        public IEnumerable<User> Get()
        {
            return Model.GetAll();
        }

        // GET: api/Users/5
        public User Get(int id)
        {
            return Model.GetUser(id);
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
            var user = JsonConvert.DeserializeObject<User>(value); // Convert JSON to Users
            Model.CreateUser(user); // Create a new User
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
            var user = JsonConvert.DeserializeObject<User>(value);
            Model.UpdateUser(id, user);
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
            Model.DeleteUser(id);
        }
    }
}
