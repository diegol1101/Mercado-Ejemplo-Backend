namespace Domain.Entities;
public class Producto : BaseEntity
{

    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio {get; set; }

    /*llaves*/
    public ICollection<Factura> Facturas { get; set; }
    public int CategoriaIdFk { get; set; }
    public Categoria Categoria { get; set; } 

}
