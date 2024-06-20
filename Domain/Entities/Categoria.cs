namespace Domain.Entities;
public class Categoria : BaseEntity
{
    public string Descripcion {get; set;}

    /*llaves*/

    public ICollection<Producto> Productos {get; set;}
}
