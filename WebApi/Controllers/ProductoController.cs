﻿using System.Collections.Generic;
using Application;
using Application.Request;
using Application.Services;
using Domain.Contracts;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TiendaContext _context;
        public ProductoController(TiendaContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        // GET: api/Producto
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Producto/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Producto
        [HttpPost("MateriaPrima")]
        public ActionResult<Response> Post(ProductoRequest productoRequest)
        {
            Response response = new CrearProductoMateriaPrima(_unitOfWork).
                CrearProducto(productoRequest);
            return Ok(response);
        }

        // PUT: api/Producto/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
