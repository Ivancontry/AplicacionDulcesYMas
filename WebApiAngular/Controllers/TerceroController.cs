﻿using Application.Request;
using Application.Services.TercerosServices.ClienteServices;
using Application.Services.TercerosServices.EmpleadoServices;
using Application.Services.TercerosServices.ProveedorServices;
using Application.Services.TercerosServices.TerceroServices;
using Application.Services.TercerosServices.UsuarioServices;
using Domain.Contracts;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerceroController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DulcesYmasContext _context;
        public TerceroController(DulcesYmasContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        // GET: api/Tercero
      
        [HttpPost("")]
        public ActionResult Post(TerceroRequest request)
        {
            var response = new TerceroCrearService(this._unitOfWork)
                .CrearTercero(request);
            return Ok(response);
        }
        [HttpGet("GetPaginados")]
        public IActionResult GetTercerosPaginados(PaginationRequest request)
        {
            Response response = new ListarTercerosPaginadosService(_unitOfWork)
                .Get(request);
            if (response.Data == null)
                return BadRequest("No hay terceros por el momento");
            return Ok(response);
        }
        [HttpPost("usuario")]
        public ActionResult PostUsuario(TerceroUsuarioRequest request)
        {
            var response = new TerceroUsuarioCrearService(this._unitOfWork)
                .Crear(request);
            return Ok(response);
        }
        [HttpPost("Empleados")]
        public IActionResult PostEmpleado(TerceroEmpleadoRequest request)
        {
            var response = new TerceroEmpleadoCrearService(this._unitOfWork)
                .Crear(request);
            if (response.Data == null) {
				return BadRequest (response.Mensaje);
			}
			return Ok (response);
        }
        [HttpGet("Empleados/{id}")]
        public ActionResult GetEmpleado(int id)
        {
            var response = new TerceroEmpleadoBuscarService(this._unitOfWork)
                .BuscarEmpleado(id);
            return Ok(response);
        }
        [HttpPost("Empleados/GetPaginados")]
        public ActionResult<Response> GetEmpleadosPaginados(PaginationRequest request)
        {
            Response response = new ListarEmpleadosPaginadosService(_unitOfWork)
                .Get(request);
            var data = (List<TerceroEmpleadoRequest>)response.Data;
            if (data.Count == 0)
                return BadRequest("No hay empleados por el momento");
            return Ok(response);
        }
        [HttpPost("Proveedores")]
        public ActionResult PostProvedor(TerceroProveedorRequest request)
        {
            var response = new TerceroProveedorCrearService(this._unitOfWork)
                .Crear(request);
            if (response.Data == null) {
				return BadRequest (response.Mensaje);
			}
			return Ok (response);
        }
        [HttpPost("Proveedores/GetPaginados")]
        public IActionResult GetProveedoresPaginados(PaginationRequest request)
        {
            Response response = new ListarProveedoresPaginadosService(_unitOfWork)
                .GetPaginados(request);
            var data = (List<TerceroProveedorRequest>)response.Data;
            if (data.Count == 0)
                return BadRequest("No hay proveedores por el momento");
            return Ok(response);
        }
        [HttpPost("Clientes/GetPaginados")]
        public IActionResult GetClientesPaginados(PaginationRequest request)
        {
            Response response = new ListarClientesPaginadosService(_unitOfWork)
                .GetPaginados(request);
            var data = (List<TerceroClienteRequest>)response.Data;
            if (data.Count  == 0)
                return BadRequest("No hay clientes por el momento");
            return Ok(response);
        }
        [HttpGet("")]
        public IEnumerable<TerceroRequest> GetTerceros()
        {
            return new TerceroGetAllService(this._unitOfWork).GetTerceros();
        }
    }
}
