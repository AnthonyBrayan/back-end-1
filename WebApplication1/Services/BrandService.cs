using Data;
using Entities;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class BrandService : BaseContextService, IBrandService
    {
        public BrandService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertBrand(Brand brand)
        {
            _serviceContext.Brand.Add(brand);
            _serviceContext.SaveChanges();
            return brand.Id_brand;
        }

        public void UpdateBrand(int brandId, Brand updatedBrand)
        {
            var existingBrand = _serviceContext.Brand.FirstOrDefault(b => b.Id_brand == brandId);

            if (existingBrand != null)
            {
                existingBrand.name_brand = updatedBrand.name_brand;

                _serviceContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Marca no encontrada");
            }
        }

        public void DeleteBrand(int brandId)
        {
            var existingBrand = _serviceContext.Brand.FirstOrDefault(b => b.Id_brand == brandId);

            if (existingBrand != null)
            {
                _serviceContext.Brand.Remove(existingBrand);
                _serviceContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Marca no encontrada");
            }
        }

        public List<Brand> GetBrands()
        {
            return _serviceContext.Brand.ToList();
        }
    }
}
