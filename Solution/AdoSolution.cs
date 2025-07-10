using System.Data;
using hometask5.Models;
using Microsoft.Data.SqlClient;

namespace hometask5.Solution;

public class AdoSolution(string connectionString)
{
    public void ReadOrdersWithSqlDataReader()
    {
        var oneYearAgo = DateTime.Now.AddYears(-1);

        using var conn = new SqlConnection(connectionString);
        using var cmd = new SqlCommand("SELECT ord_id, ord_datetime, ord_an FROM Orders WHERE ord_datetime >= @date", conn);
        cmd.Parameters.AddWithValue("@date", oneYearAgo);

        conn.Open();
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"OrderId={reader.GetInt32(0)}, Date={reader.GetDateTime(1)}, An={reader.GetInt32(2)}");
        }
    }

    public void ReadOrdersWithSqlDataAdapter()
    {
        var oneYearAgo = DateTime.Now.AddYears(-1);
        var dt = new DataTable();

        using var conn = new SqlConnection(connectionString);
        using var adapter = new SqlDataAdapter("SELECT ord_id, ord_datetime, ord_an FROM Orders WHERE ord_datetime >= @date", conn);
        adapter.SelectCommand.Parameters.AddWithValue("@date", oneYearAgo);
        adapter.Fill(dt);

        foreach (DataRow row in dt.Rows)
        {
            Console.WriteLine($"OrderId={row["ord_id"]}, Date={row["ord_datetime"]}, An={row["ord_an"]}");
        }
    }
    
    public void CreateOrderWithSqlCommand(Order order)
    {
        using var conn = new SqlConnection(connectionString);
        using var cmd = new SqlCommand("INSERT INTO Orders (ord_datetime, ord_an) VALUES (@datetime, @an); SELECT SCOPE_IDENTITY();", conn);

        cmd.Parameters.AddWithValue("@datetime", order.OrdDatetime);
        cmd.Parameters.AddWithValue("@an", order.OrdAn);

        conn.Open();
        var insertedId = cmd.ExecuteScalar();
        Console.WriteLine($"Inserted Order ID = {insertedId}");
    }

    public void UpdateOrderWithSqlCommand(int id, DateTime newDate, int newAn)
    {
        using var conn = new SqlConnection(connectionString);
        using var cmd = new SqlCommand("UPDATE Orders SET ord_datetime = @datetime, ord_an = @an WHERE ord_id = @id", conn);

        cmd.Parameters.AddWithValue("@datetime", newDate);
        cmd.Parameters.AddWithValue("@an", newAn);
        cmd.Parameters.AddWithValue("@id", id);

        conn.Open();
        var rows = cmd.ExecuteNonQuery();
        Console.WriteLine(rows > 0 ? "Order updated." : "Order not found.");
    }

    public void DeleteOrderWithSqlCommand(int id)
    {
        using var conn = new SqlConnection(connectionString);
        using var cmd = new SqlCommand("DELETE FROM Orders WHERE ord_id = @id", conn);

        cmd.Parameters.AddWithValue("@id", id);

        conn.Open();
        var rows = cmd.ExecuteNonQuery();
        Console.WriteLine(rows > 0 ? "Order deleted." : "Order not found.");
    }
}