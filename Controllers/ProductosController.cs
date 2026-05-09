using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentasApi.Data;
using VentasApi.Models;

namespace VentasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly VentasDbContext _context;

        public ProductosController(VentasDbContext context)
        {
            _context = context;
        }

        // GET: api/productos
        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var productos = await _context.Productos.ToListAsync();
            return Ok(productos);
        }

        // GET: api/productos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                return NotFound(new { mensaje = "Producto no encontrado" });

            return Ok(producto);
        }

        // POST: api/productos
        [HttpPost]
        public async Task<IActionResult> CrearProducto([FromBody] Producto producto)
        {
            try
            {
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return Ok(new { mensaje = "Producto guardado", producto });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al guardar", detalle = ex.Message });
            }
        }

        // PUT: api/productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProducto(int id, [FromBody] Producto producto)
        {
            var existente = await _context.Productos.FindAsync(id);
            if (existente == null)
                return NotFound(new { mensaje = "Producto no encontrado" });

            existente.Nombre = producto.Nombre;
            existente.Precio = producto.Precio;
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Producto actualizado", producto = existente });
        }

        // DELETE: api/productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                return NotFound(new { mensaje = "Producto no encontrado" });

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Producto eliminado" });
        }
    }
}