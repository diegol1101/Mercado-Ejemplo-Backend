using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    public UnitOfWork(ApiContext context)
    {
        _context = context;
    }
    private readonly ApiContext _context;
    
    private ProductoRepository _Productos;
    public IProducto Productos
    {
        get
        {
            if (_Productos == null)
            {
                _Productos = new ProductoRepository(_context);
            }
            return _Productos;
        }
    }
    private CategoriaRepository _Categorias;
    public ICategoria Categorias
    {
        get
        {
            if (_Categorias == null)
            {
                _Categorias = new CategoriaRepository(_context);
            }
            return _Categorias;
        }
    }
    private FacturaRepository _Facturas;
    public IFactura Facturas
    {
        get
        {
            if (_Facturas == null)
            {
                _Facturas = new FacturaRepository(_context);
            }
            return _Facturas;
        }
    }
    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
