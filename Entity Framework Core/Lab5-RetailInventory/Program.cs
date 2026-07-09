using Microsoft.EntityFrameworkCore;

using var context = new AppDbContext();

// ===== Lab 4: Inserting Initial Data =====
/*var electronics = new Category { Name = "Electronics" };
var groceries = new Category { Name = "Groceries" };
await context.Categories.AddRangeAsync(electronics, groceries);

var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };
await context.Products.AddRangeAsync(product1, product2);

await context.SaveChangesAsync();
Console.WriteLine("Data inserted successfully.");
*/
// ===== Lab 5: Retrieving Data =====
// 1. Retrieve all products
var products = await context.Products.ToListAsync();
foreach (var p in products)
    Console.WriteLine($"{p.Name} - ₹{p.Price}");

// 2. Find by ID
var product = await context.Products.FindAsync(1);
Console.WriteLine($"Found: {product?.Name}");

// 3. FirstOrDefault with condition
var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
Console.WriteLine($"Expensive: {expensive?.Name}");