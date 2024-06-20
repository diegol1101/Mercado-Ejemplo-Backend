using Domain.Entities;
namespace API.Dtos;
public class ProductoDto : BaseEntity
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio {get; set; }

    /*llaves*/
    public int CategoriaIdFk { get; set; }
    
}
