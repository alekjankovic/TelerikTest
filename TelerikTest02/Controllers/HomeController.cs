using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TelerikTest02.Data;
using TelerikTest02.Models;
using TelerikTest02.Models.HelperModels;

namespace TelerikTest02.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/getcategories")]
        public JsonResult Categories()
        {
            var model = _context.Categories.ToList();
            return Json(model);
        }

        [HttpGet]
        [Route("api/getgriddata")]
        public JsonResult GridData()
        {

            var model = _context.Categories.Include(x => x.Products).Select(x => new {
                x.Id,
                x.Name,
                ProductsList = x.Products.Select(y => new  {
                    Id = y.Id,
                    Name = y.Name,
                    ValidFrom = y.ValidFrom,
                    Price = y.Price,
                    Quantity = y.Quantity
                }).ToList()
            }).ToList();

            var result = new JsonResult(model);
            result.StatusCode = 200;
            result.ContentType = "json";
            return result;

        }

        [HttpPost]
        [Route("api/addnewproduct")]
        public HttpResponseMessage AddProduct(Products postData)
        {
            ProductEditModel model = new ProductEditModel(_context, postData);
            model.AddNew();

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            return response;
        }

        [HttpPost]
        [Route("api/addnewcategory")]
        public HttpResponseMessage AddCategory(Categories postData)
        {
            CategoryEditModel model = new CategoryEditModel(_context, postData);
            model.AddNew();

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            return response;
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
