using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChristmasMom.Services;
using ChristmasMom.Models;
using ChristmasMom.Filters;

namespace ChristmasMom.Controllers
{
    [Route("api/[controller]")]
    [TypeFilter(typeof(ModelFilter))]
    public class ValuesController : Controller
    {
        private EmailService emailService;

        public ValuesController(EmailService emailService)
        {
            this.emailService = emailService;
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]EmailModel value)
        {
            emailService.SendMail(value);
            return "Check your inbox :)";
        }

    }
}
