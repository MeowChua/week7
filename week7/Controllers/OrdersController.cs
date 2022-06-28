﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Week7.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Week7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly DataContext dt;
        public OrdersController(DataContext dt)
        {
            this.dt = dt;
        }
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(dt.Orders.ToList());
            //return View();
        }
        [HttpGet]
        [Route("{id:Int}")]
        public IActionResult GetOrderById([FromRoute] int id)
        {
            var pd = dt.Orders.Find(id);
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
            var ar = dt.Orders.Find(id);
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
