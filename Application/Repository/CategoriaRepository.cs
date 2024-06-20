using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
    public class CategoriaRepository  : GenericRepo<Categoria>, ICategoria
{
    protected readonly ApiContext _context;
    public CategoriaRepository(ApiContext context) : base (context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Categoria>> GetAllAsync()
    {
        return await _context.Categorias
            .ToListAsync();
    }
    public override async Task<Categoria> GetByIdAsync(int id)
    {
        return await _context.Categorias
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<Categoria> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Categorias as IQueryable<Categoria>;
        if(string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Descripcion.ToLower().Contains(search));
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
