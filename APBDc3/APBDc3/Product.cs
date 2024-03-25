namespace APBDc3;

public class Product
{
    internal String Name { set; get; }
    internal bool IsDangerous { set; get; }
    internal double StorageTemerature { set; get; }

    public Product(string name, bool isDangerous, double storageTemerature)
    {
        Name = name;
        IsDangerous = isDangerous;
        StorageTemerature = storageTemerature;
    }
}