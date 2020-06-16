using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTestApplication.Models;

namespace WebTestApplication.Controllers
{
    public class res
    {
        public int resCode { get; set; }
        public object resData { get; set; }
        public string resMsg { get; set; }
    }
    public class TestController : Controller
    {
        private readonly DemoDatabaseContext _context;

        public TestController(DemoDatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(Product products)
        {
            res resObj = new res();
            try
            {
                _context.Add(products);
                if(await _context.SaveChangesAsync() > 0)
                {
                    resObj.resCode = 1;
                    resObj.resMsg = "Item added successfully";
                }
                else
                {
                    resObj.resCode = 0;
                    resObj.resMsg = "Sorry,something went wrong.";
                }
            }
            catch (Exception ex)
            {
                string msg= ex.Message;
                resObj.resCode = 0;
                resObj.resMsg = "Sorry,something went wrong.";
            }
            return Json(resObj);   
        }
        [HttpPost]
        public async Task<IActionResult> GetItems()
        {
            res resObj = new res();
            try
            {
                var lstProduct = _context.Product.ToList(); 
                if (lstProduct.Count > 0)
                {
                    resObj.resCode = 1;
                    resObj.resData = lstProduct;
                    resObj.resMsg = "Data available";
                }
                else
                {
                    resObj.resCode = 0;
                    resObj.resMsg = "No Data Available.";
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                resObj.resCode = 0;
                resObj.resMsg = "Sorry,something went wrong.";
            }
            return Json(resObj);
        }
    }
}