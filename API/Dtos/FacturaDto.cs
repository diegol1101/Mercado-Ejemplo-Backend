using Domain.Entities;
namespace API.Dtos;
public class FacturaDto : BaseEntity
{
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal Vtotal { get; set; }

    /*llaves*/
    public int ProductoIdFk { get; set; }
}
