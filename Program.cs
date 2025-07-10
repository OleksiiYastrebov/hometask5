using Microsoft.Extensions.Configuration;
using hometask5.Models;
using hometask5.Solution;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var connectionString = config.GetConnectionString("DefaultConnection");

var adoSolution = new AdoSolution(connectionString);
var efCoreSolution = new EfCoreSolution(connectionString);

Console.WriteLine("Task1:");
adoSolution.ReadOrdersWithSqlDataReader();

Console.WriteLine("Task2:");
adoSolution.ReadOrdersWithSqlDataAdapter();

Console.WriteLine("Task3:");
efCoreSolution.ReadOrders();

Console.WriteLine("Task4:");
var newOrder = new Order { OrdDatetime = DateTime.Now, OrdAn = 1 };
adoSolution.CreateOrderWithSqlCommand(newOrder);

Console.WriteLine("Task5");
adoSolution.UpdateOrderWithSqlCommand(1, DateTime.Now.AddDays(-1), 1);

Console.WriteLine("Task6");
adoSolution.DeleteOrderWithSqlCommand(1);

Console.WriteLine("Task7.1");
efCoreSolution.CreateOrder(new Order { OrdDatetime = DateTime.Now, OrdAn = 1 });

Console.WriteLine("Task7.2");
efCoreSolution.UpdateOrder(2, DateTime.Now.AddDays(-2), 1);

Console.WriteLine("Task7.3");
efCoreSolution.DeleteOrder(2);
