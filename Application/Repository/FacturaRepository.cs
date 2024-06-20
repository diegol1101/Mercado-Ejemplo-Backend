using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
    public class FacturaRepository  : GenericRepo<Factura>, IFactura
{
    protected readonly ApiContext _context;
    public FacturaRepository(ApiContext context) : base (context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Factura>> GetAllAsync()
    {
        return await _context.Facturas
            .ToListAsync();
    }
    public override async Task<Factura> GetByIdAsync(int id)
    {
        return await _context.Facturas
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<Factura> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Facturas as IQueryable<Factura>;
        if(string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }
        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }
}
