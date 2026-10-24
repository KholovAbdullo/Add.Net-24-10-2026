using Domain.Models;

namespace Domain.interfrances;

public interface IProductsRepository
{
    void AddProduct(Products products);
    void UpdateProduct(Products products);
    void DeleteProduct(int id);
    Products GetProduct(int id);
    List<Products> GetProducts();
    List<Products> GetProductsByCategory(string name);
}
