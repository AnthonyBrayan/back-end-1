using Entities;

namespace WebApplication1.IServices
{
    public interface IBrandService
    {
        int InsertBrand(Brand brand);
        void UpdateBrand(int brandId, Brand updatedBrand);
        void DeleteBrand(int brandId);
        List<Brand> GetBrands();
    }
}
