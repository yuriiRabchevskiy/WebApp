using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPP.Models;

namespace WebAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private DataBaseContext _db;

        public UserController(ILogger<UserController> logger, DataBaseContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _db.Users.Select(o => o).ToArray();
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
            User user = new User();
            user.Name = value;
            _db.Users.Add(user);
            _db.SaveChanges();
        }
    }
}