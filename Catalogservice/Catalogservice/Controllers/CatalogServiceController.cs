using Catalogservice.Data;
using Catalogservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class CatalogController : ControllerBase

    {

        private readonly AppDBContext _context;

        public CatalogController(AppDBContext context)

        {

            _context = context;

        }

        [HttpGet]
        //to get all catalogs
        public async Task<IActionResult> GetAll()

        {

            var shipments = await _context.CatalogServices.ToListAsync();

            return Ok(shipments);

        }

        [HttpGet("{id}")]
        //to search a catalog
        public async Task<IActionResult> Get(int id)

        {

            var shipment = await _context.CatalogServices.FindAsync(id);

            if (shipment is null)

            {

                return NotFound();

            }

            else

            {

                return Ok(shipment);

            }

        }

        [HttpPost]
        //to create a  catalog
        public async Task<IActionResult> Create([FromBody] Catalog shipping)

        {

            _context.CatalogServices.Add(shipping);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), shipping);

        }

        [HttpPut("{id}")]
        // to update a catalog
        public async Task<IActionResult> Update(int id, Catalog shipping)

        {

            var shipment = await _context.CatalogServices.FindAsync(id);

            if (shipment is null)

            {

                return NotFound();

            }

            else

            {

                shipment.catalogName = shipping.catalogName;

                shipment.catalogDescription = shipping.catalogDescription;

                await _context.SaveChangesAsync();


                return Ok(shipment);

            }

        }

        [HttpDelete("{id}")]
        // to delete a catalog
        public async Task<IActionResult> Delete(int id)

        {

            var shipment = await _context.CatalogServices.FindAsync(id);

            if (shipment is null)

            {

                return NotFound();

            }

            else

            {

                _context.CatalogServices.Remove(shipment);

                await _context.SaveChangesAsync();

                return Ok(shipment);

            }

        }

    }

}

