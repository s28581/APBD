namespace APBDc3;

public class Product
{
    public String Name { set; get; }
    public bool IsDangerous { set; get; }
    public double StorageTemerature { set; get; }

    public Product(string name, bool isDangerous, double storageTemerature)
    {
        Name = name;
        IsDangerous = isDangerous;
        StorageTemerature = storageTemerature;
    }
}