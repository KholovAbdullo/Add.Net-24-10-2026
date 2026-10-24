using Domain.Models;
using Infrastructure.Repositories;

var categoryRepo = new CategoryRepository();
var productRepo = new ProductRepository();

while (true)
{
    System.Console.WriteLine("===============================");
    System.Console.WriteLine(@"
    Table Category!
    1.Show all categories.
    2.Show category.
    3.Add new category.
    4.Update category.
    5.Delete category.

    Table Products!
    6. Show all Products
    7. Show Product by id
    8. Add Product
    9. Update Product
    10. Delete Product
    11. Show Products by Category name
    0 - Exit.");
    var a = Console.ReadLine();
    System.Console.WriteLine("===============================");
    switch (a)
    {
        case "1":
            var allCategories = categoryRepo.GetCategories();
            foreach(var item in allCategories)
            {
                System.Console.WriteLine(item.Id+" "+item.Name);
            }
            break;
        case "2":
            System.Console.Write("Enter id of category: ");
            var categoryIdToShow = Convert.ToInt32(Console.ReadLine());
            var categoryToShow = categoryRepo.GetCategory(categoryIdToShow);
            System.Console.WriteLine(categoryToShow.Id+" "+categoryToShow.Name);
            break;
        case "3":
            System.Console.Write("Enter name: ");
            var categoryName = Console.ReadLine()!;
            var newCategory = new Category()
            {
                Name = categoryName
            };
            categoryRepo.AddCategory(newCategory);
            break;
        case "4":
            System.Console.Write("Enter id: ");
            var categoryIdToUpdate = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter new name: ");
            var newCategoryName = Console.ReadLine()!;
            var categoryToUpdate = new Category()
            {
                Id = categoryIdToUpdate,
                Name = newCategoryName
            };
            categoryRepo.UpdateCategory(categoryToUpdate);
            break;
        case "5":
            System.Console.Write("Enter id: ");
            var categoryIdToDelete = Convert.ToInt32(Console.ReadLine());
            categoryRepo.DeleteCategory(categoryIdToDelete);
            break;

        case "6":
            var product=productRepo.GetProducts();
            foreach(var p in product)
            {
                Console.WriteLine(p.Id+" "+p.Name+" "+p.Price+" "+p.categoryId);
            }
            break;

        case "7": 
            Console.Write("Enter product id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var product1=productRepo.GetProduct(id);
            Console.WriteLine(product1.Id+" "+product1.Name+" "+product1.Price+" "+product1.categoryId);
            break;

        case "8":
            Console.Write("Enter product Name: ");
            var name=Console.ReadLine()!;
            Console.Write("Enter product Price: ");
            var price=Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter product categor_id: ");
            var categor_id=Convert.ToInt32(Console.ReadLine());
            Products products = new Products()
            {
                Name=name,
                Price=price,
                categoryId=categor_id
            };
            productRepo.AddProduct(products);
            break;

        case "9":
            Console.Write("Enter product id: ");
            var idd=Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter product Name: ");
            var nam=Console.ReadLine()!;
            Console.Write("Enter product Price: ");
            var pri=Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter product categor_id: ");
            var categor_idd=Convert.ToInt32(Console.ReadLine());
            Products products1 = new Products()
            {
                Id=idd,
                Name=nam,
                Price=pri,
                categoryId=categor_idd
            };

            productRepo.UpdateProduct(products1);
            break;

        case "10":
            Console.Write("Enter product id: ");
            int deleteId = Convert.ToInt32(Console.ReadLine());
            productRepo.DeleteProduct(deleteId);
            break;

        case "11":
            Console.Write("Enter category Name: ");
            var names=Console.ReadLine()!;
            var categorys = productRepo.GetProductsByCategory(names);
            foreach(var p in categorys)
            {
                Console.WriteLine(p.Id+" "+p.Name+" "+p.Price+" "+p.categoryId);
            }
            break;
        case "0":
            System.Console.WriteLine("Exiting ...");
            return;
    }
}