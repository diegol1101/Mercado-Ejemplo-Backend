using API.Dtos;

using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class FacturaController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public FacturaController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<FacturaDto>>> Get()
    {
        var Factura = await unitofwork.Facturas.GetAllAsync();
        return mapper.Map<List<FacturaDto>>(Factura);
    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<FacturaDto>> Get(int id)
    {
        var Factura = await unitofwork.Facturas.GetByIdAsync(id);
        if (Factura == null){
            return NotFound();
        }
        return this.mapper.Map<FacturaDto>(Factura);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Factura>> Post(FacturaDto FacturaDto)
    {
        var Factura = this.mapper.Map<Factura>(FacturaDto);
        this.unitofwork.Facturas.Add(Factura);
        await unitofwork.SaveAsync();
        if(Factura == null)
        {
            return BadRequest();
        }
        FacturaDto.Id = Factura.Id;
        return CreatedAtAction(nameof(Post), new {id = FacturaDto.Id}, FacturaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<FacturaDto>> Put(int id, [FromBody]FacturaDto FacturaDto){
        if(FacturaDto == null)
        {
            return NotFound();
        }
        var Factura = this.mapper.Map<Factura>(FacturaDto);
        unitofwork.Facturas.Update(Factura);
        await unitofwork.SaveAsync();
        return FacturaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id){
        var Factura = await unitofwork.Facturas.GetByIdAsync(id);
        if(Factura == null)
        {
            return NotFound();
        }
        unitofwork.Facturas.Remove(Factura);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}
