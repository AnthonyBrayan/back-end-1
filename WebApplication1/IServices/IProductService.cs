using Entities;

namespace WebApplication1.IServices
{
    public interface IProductService
    {
        int insertProduct(ProductItem productItem);
        void UpdateProduct(int productId, ProductItem updatedProduct);
        void DeleteProduct(int productId);
        List<ProductItem> GetProducts();
    }
}