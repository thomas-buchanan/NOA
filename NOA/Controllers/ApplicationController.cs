using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NOA.Controllers
{
    public class ApplicationController : Controller
    {
        private IHostingEnvironment _env;

        public ApplicationController(IHostingEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index() => View();

        public IActionResult SingleFile(IFormFile file)
        {
            var dir = _env.ContentRootPath;
            using (var fileStream = new FileStream(Path.Combine(dir, "NAV.txt"), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
                return RedirectToAction("Index");
        }
    }
}
