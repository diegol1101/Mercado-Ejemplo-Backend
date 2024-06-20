namespace Domain.Interfaces;
public interface IUnitOfWork
{
   
   IProducto Productos { get; }
   ICategoria Categorias { get; }
   IFactura Facturas { get; }
Task<int> SaveAsync();
}
