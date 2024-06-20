namespace Domain.Entities;
public class Factura : BaseEntity
{
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal Vtotal { get; set; }

    /*llaves*/
    public int ProductoIdFk { get; set; }
    public Producto Producto { get; set; }
}
