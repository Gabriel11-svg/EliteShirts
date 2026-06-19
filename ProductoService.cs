using EliteShirts.API.Interfaces;
using EliteShirts.API.Models;

namespace EliteShirts.API.Services
{
    public class ProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Producto?> GetProducto(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CrearProducto(Producto producto)
        {
            await _repository.AddAsync(producto);
        }

        public async Task ActualizarProducto(Producto producto)
        {
            await _repository.UpdateAsync(producto);
        }

        public async Task EliminarProducto(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}