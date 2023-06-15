namespace BlazorApp.Data;

public class Laptop
{
    public Laptop()
    {
        
    }

    public Laptop(Laptop laptop)
    {
        this.Id = laptop.Id;
        this.Gpu = laptop.Gpu;
        this.Cpu = laptop.Cpu;
        this.Memory = laptop.Memory;
        this.Brand = laptop.Brand;
        this.Name = laptop.Name;
        this.Price = laptop.Price;
    }
    
    public Laptop(int Id, string Gpu, string Cpu, int Memory, string Brand, string Name, double Price)
    {
        this.Id = Id;
        this.Gpu = Gpu;
        this.Cpu = Cpu;
        this.Memory = Memory;
        this.Brand = Brand;
        this.Name = Name;
        this.Price = Price;
    }

    public bool DBReady()
    {
        return Gpu != null && Cpu != null && Memory != 0 && Brand != null && Name != null && Price != 0;
    }

    public int Id { get; set; }
    public string? Gpu { get; set; }
    public string? Cpu { get; set; }
    public int Memory { get; set; }
    public string? Brand { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
}