using Data;
using Entities;
using WebApplication1.IServices;


namespace WebApplication1.Services
{
    public class ProductService : BaseContextService, IProductService
    {
        public ProductService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int insertProduct(ProductItem productItem)
        {
            _serviceContext.Products.Add(productItem);
            _serviceContext.SaveChanges();
            return productItem.Id;
        }

        public void UpdateProduct(int productId, ProductItem updatedProduct)
        {
            var existingProduct = _serviceContext.Products.FirstOrDefault(p => p.Id == productId);

            if (existingProduct == null)
            {
                // Si el producto no existe, podrías lanzar una excepción o manejar el caso según tus requerimientos.
                throw new InvalidOperationException("El producto no existe.");
            }

            // Actualiza las propiedades del producto con la información del producto modificado
            existingProduct.productName = updatedProduct.productName;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.Stock = updatedProduct.Stock;

            _serviceContext.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = _serviceContext.Products.Find(productId);
            if (product != null)
            {
                _serviceContext.Products.Remove(product);
                _serviceContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("El producto no existe.");
            }
        }

        public List<ProductItem> GetProducts()
        {
            return _serviceContext.Products.ToList();
        }

        public List<ProductItem> GetProductsByStockRange(int minStock, int maxStock)
        {
            return _serviceContext.Products.Where(p => p.Stock >= minStock && p.Stock <= maxStock).ToList();
        }

    }
}