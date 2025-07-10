using hometask5.Models;
using Microsoft.EntityFrameworkCore;

namespace hometask5.Solution;

public class EfCoreSolution(string connectionString)
{
    public void ReadOrders()
    {
        using var context = new ApplicationContext(connectionString);
        var oneYearAgo = DateTime.Now.AddYears(-1);

        var orders = context.Orders
            .AsNoTracking()
            .Where(o => o.OrdDatetime >= oneYearAgo);

        foreach (var order in orders)
        {
            Console.WriteLine($"OrderId={order.OrdId}, Date={order.OrdDatetime}, An={order.OrdAn}");
        }
    }
    
    public void CreateOrder(Order order)
    {
        using var context = new ApplicationContext(connectionString);
        
        context.Orders.Add(order);
        context.SaveChanges();
        Console.WriteLine($"Inserted Order ID = {order.OrdId}");
    }

    public void UpdateOrder(int id, DateTime newDate, int newAn)
    {
        using var context = new ApplicationContext(connectionString);
        var order = context.Orders.Find(id);
        
        if (order == null)
        {
            Console.WriteLine("Order not found.");
            return;
        }
        
        order.OrdDatetime = newDate;
        order.OrdAn = newAn;
        context.SaveChanges();
        Console.WriteLine("Order updated.");
    }
    
    public void DeleteOrder(int id)
    {
        using var context = new ApplicationContext(connectionString);
        var order = context.Orders.Find(id);
        
        if (order == null)
        {
            Console.WriteLine("Order not found.");
            return;
        }
        
        context.Orders.Remove(order);
        context.SaveChanges();
        Console.WriteLine("Order deleted.");
    }
}