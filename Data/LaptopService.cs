using System.Data.SqlClient;

namespace BlazorApp.Data;

public class LaptopService
{
    private string connectionString = "Data Source=192.168.2.2;Initial Catalog=DB;User ID=sa;Password=Passw0rd";

    public List<Laptop> ReadLaptops()
    {
        List<Laptop> laptops = new();
        using (SqlConnection con = new(connectionString))
        {
            SqlCommand cmd = new("SELECT * FROM Laptops", con);
            con.Open();
            
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Laptop laptop = new();
                laptop.Id = (int)reader[0];
                laptop.Gpu = (string)reader[1];
                laptop.Cpu = (string)reader[2];
                laptop.Memory = (int)reader[3];
                laptop.Brand = (string)reader[4];
                laptop.Name = (string)reader[5];
                laptop.Price = (decimal)reader[6];
                laptops.Add(laptop);
            }
            con.Close();
        }

        return laptops;
    }
    
    public void DeleteLaptop(int id)
    {
        using (SqlConnection con = new(connectionString))
        {
            SqlCommand cmd = new($"DELETE FROM Laptops WHERE Id = {id}", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }

    public void CreateLaptop(Laptop laptop)
    {
        using (SqlConnection con = new(connectionString))
        {
            string query =  "INSERT INTO Laptops (Gpu, Cpu, Memory, Brand, Name, Price) VALUES (@Gpu, @Cpu, @Memory, @Brand, @Name, @Price)";
            SqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Gpu", laptop.Gpu);
            cmd.Parameters.AddWithValue("@Cpu", laptop.Cpu);
            cmd.Parameters.AddWithValue("@Memory", laptop.Memory);
            cmd.Parameters.AddWithValue("@Brand", laptop.Brand);
            cmd.Parameters.AddWithValue("@Name", laptop.Name);
            cmd.Parameters.AddWithValue("@Price", laptop.Price);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }

    public void UpdateLaptop(Laptop laptop)
    {
        using (SqlConnection con = new(connectionString))
        {
            string query = "UPDATE Laptops SET Gpu = @Gpu, Cpu = @Cpu, Memory = @Memory, Brand = @Brand, Name = @Name, Price = @Price WHERE Id = @Id";
            SqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Id", laptop.Id);
            cmd.Parameters.AddWithValue("@Gpu", laptop.Gpu);
            cmd.Parameters.AddWithValue("@Cpu", laptop.Cpu);
            cmd.Parameters.AddWithValue("@Memory", laptop.Memory);
            cmd.Parameters.AddWithValue("@Brand", laptop.Brand);
            cmd.Parameters.AddWithValue("@Name", laptop.Name);
            cmd.Parameters.AddWithValue("@Price", laptop.Price);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}