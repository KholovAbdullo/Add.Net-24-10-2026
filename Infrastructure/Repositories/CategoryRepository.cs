using Domain.interfrances;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public void AddCategory(Category category)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=$"insert into Category(name) values(@name)";
        var comm=new NpgsqlCommand(query,conn);
        comm.Parameters.AddWithValue("name",category.Name);
        comm.ExecuteNonQuery();
    }

    public List<Category> GetCategories()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=$"select * from Category";
        var comm=new NpgsqlCommand(query,conn);
        var Data=comm.ExecuteReader();
        List<Category> categories = new List<Category>();
        while (Data.Read())
        {
            Category category = new Category();
            category.Id=Data.GetInt32(0);
            category.Name=Data.GetString(1);

            categories.Add(category);
        }

        return categories;
    }

    public Category GetCategory(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=$"select * from Category";
        var comm=new NpgsqlCommand(query,conn);
        var Data=comm.ExecuteReader();
        Category category = new Category();
        while (Data.Read())
        {
            category.Id=Data.GetInt32(0);
            category.Name=Data.GetString(1);
        }
        return category;
    }

    public void DeleteCategory(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=$"delete from Category where id=@id";
        var comm=new NpgsqlCommand(query,conn);
        comm.Parameters.AddWithValue("id",id);
        comm.ExecuteNonQuery();
    }

    public void UpdateCategory(Category category)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=$"Update Category set name=@name where id=@id";
        var comm=new NpgsqlCommand(query,conn);
        comm.Parameters.AddWithValue("name",category.Name);
        comm.Parameters.AddWithValue("id",category.Id);
        comm.ExecuteNonQuery();
    }

}
