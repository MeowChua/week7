﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_Back.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : Controller
    {
        private readonly DataContext dt;
        public ProductTypesController(DataContext dt)
        {
            this.dt = dt;
        }
        [HttpGet]
        public IActionResult GetProductTypes()
        {
            return Ok(dt.ProductTypes.ToList());
            //return View();
        }
        [HttpGet]
        [Route("{id:Int}")]
        public IActionResult GetProductTypeById([FromRoute] int id)
        {
            var pd = dt.ProductTypes.Find(id);
            if (pd == null)
            {
                return NotFound();
            }

            return Ok(pd);
            //return View();
        }
        [HttpDelete]
        [Route("{id:Int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var ar = dt.ProductTypes.Find(id);
            if (ar != null)
            {
                dt.Remove(ar);
                dt.SaveChanges();
                return Ok(ar);
            }
            return NotFound();
        }

    }
}

