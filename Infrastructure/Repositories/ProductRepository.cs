using Domain.interfrances;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductsRepository
{
    public void AddProduct(Products products)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=$"insert into Product (categor_id,name,price) values(@categor_id,@name,@price)";
        var comm=new NpgsqlCommand(query,conn);
        comm.Parameters.AddWithValue("categor_id",products.categoryId);
        comm.Parameters.AddWithValue("name",products.Name);
        comm.Parameters.AddWithValue("price",products.Price);
        comm.ExecuteNonQuery();
    }

    public List<Products> GetProducts()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=$"select id,name,price,categor_id from Product";
        var comm=new NpgsqlCommand(query,conn);
        var data=comm.ExecuteReader();
        List<Products> products = new List<Products>();
        while (data.Read())
        {
            Products product = new Products();
            product.Id=data.GetInt32(0);
            product.Name=data.GetString(1);
            product.Price=data.GetDecimal(2);
            product.categoryId=data.GetInt32(3);
            products.Add(product);
        }

        return products;

    }

    public void DeleteProduct(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=$"delete from Product where id=@id";
        var comm=new NpgsqlCommand(query,conn);
        comm.Parameters.AddWithValue("id",id);
        comm.ExecuteNonQuery();
    }

    public List<Products> GetProductsByCategory(string name)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=$"select p.id,p.name,p.price,categor_id from Product p join Category c on p.categor_id=c.id where c.name=@name";
        var comm=new NpgsqlCommand(query,conn);
        comm.Parameters.AddWithValue("name",name);
        var data=comm.ExecuteReader();
        List<Products> products = new List<Products>();
        while (data.Read())
        {
            Products product = new Products();
            product.Id=data.GetInt32(0);
            product.Name=data.GetString(1);
            product.Price=data.GetDecimal(2);
            product.categoryId=data.GetInt32(3);
            products.Add(product);
        }
        
        return products;
    }

    public Products GetProduct(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=$"select name,price,categor_id from Product where id=@id";
        var comm=new NpgsqlCommand(query,conn);
        comm.Parameters.AddWithValue("id",id);
        var dat=comm.ExecuteReader();
        Products products = new Products();
        while (dat.Read())
        {
            products.Id=dat.GetInt32(0);
            products.Name=dat.GetString(1);
            products.Price=dat.GetDecimal(2);
            products.categoryId=dat.GetInt32(3);
        }
        return products;
    }

    public void UpdateProduct(Products products)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=$"Update Product set name=@name,price=@price,categor_id=@categor_id where id=@id";
        var comm=new NpgsqlCommand(query,conn);
        comm.Parameters.AddWithValue("name",products.Name);
        comm.Parameters.AddWithValue("price",products.Price);
        comm.Parameters.AddWithValue("categor_id",products.categoryId);
        comm.Parameters.AddWithValue("id",products.Id);
        comm.ExecuteNonQuery();
    }

}
