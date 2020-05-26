﻿using Domain.Contracts;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Base
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;
        private IProductoRepository _productoRepository;
        private ITerceroUsuarioRepository _terceroUsuarioRepository;
        private ITerceroRepository _terceroRepository;
        private ITerceroProvedorRepository _terceroProvedorRepository;
        private ITerceroEmpleadoRepository _terceroEmpleadoRepository;
        private ITerceroClienteRepository _terceroClienteRepository;
        private ICompraRepository _compraRepository;

        public ITerceroRepository TerceroRepository
        {
            get 
            {
                return _terceroRepository ?? 
                    (_terceroRepository = new TerceroRepository(_dbContext)); 
            }
        }

        public ITerceroProvedorRepository TerceroProvedorRepository
        {
            get 
            {
                return _terceroProvedorRepository ?? 
                    (_terceroProvedorRepository = new TerceroProveedorRepository(_dbContext)); 
            }
        }

        public ITerceroUsuarioRepository TerceroUsuarioRepository
        {
            get 
            { 
                return _terceroUsuarioRepository ?? 
                    (_terceroUsuarioRepository = new TerceroUsuarioRepository(_dbContext)); 
            }

        }
        private IRoleRepository _roleRepository;

        public IRoleRepository RoleRepository
        {
            get 
            { 
                return _roleRepository ?? (_roleRepository = new RoleRepository(_dbContext)); 
            }
        }

        public ITerceroEmpleadoRepository TerceroEmpleadoRepository
        {
            get { return _terceroEmpleadoRepository ??
                   (_terceroEmpleadoRepository = new TerceroEmpleadoRepository(_dbContext)); }
        }

        public ITerceroClienteRepository TerceroClienteRepository
        {
            get { return _terceroClienteRepository ?? 
                    (_terceroClienteRepository = new TerceroClienteRepository(_dbContext)); }
        }

        public IProductoRepository ProductoRepository 
        { 
            get 
            { 
                return _productoRepository ?? 
                    (_productoRepository = new ProductoRepository(_dbContext)); 
            }
        }

        public ICompraRepository CompraRepository
        {
            get 
            { 
                return _compraRepository ?? 
                    (_compraRepository = new CompraRepository(_dbContext)); 
            }
        }

        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }


        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext)_dbContext).Dispose();
                _dbContext = null;
            }
        }
    }
}
