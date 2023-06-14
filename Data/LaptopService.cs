namespace BlazorApp.Data;

public class LaptopService
{
    public Laptop ReadLaptop()
    {
        return new Laptop(1, "Nvidia RTX 3080", "Intel i7-10700K", 16, "Asus", "ROG Strix G17", 17990);
    }

    public List<Laptop> ReadLaptops()
    {
        List<Laptop> laptops = new(){ ReadLaptop()};
        
        return laptops;
    }
    
    public void DeleteLaptop(int id)
    {
        Console.WriteLine($"Laptop with id {id} was deleted");
    }
}