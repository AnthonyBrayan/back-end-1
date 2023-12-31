﻿using Entities;

namespace WebApplication1.IServices
{
    public interface IProductService
    {
        int InsertProduct(ProductItem productItem);
        void UpdateProduct(int productId, ProductItem updatedProduct);
        void DeleteProduct(int productId);
        List<ProductItem> GetProducts();
        List<ProductItem> GetProductsByStockRange(int minStock, int maxStock);
        List<ProductItem> GetProductsByBrand(string brandName);
    }
    
}