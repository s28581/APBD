using APBDc3;
using APBDc3.Models.ContainerTypes;

Product p = new Product("apple", false, 20.2);
Product p2 = new Product("apple", false, 13);
Console.WriteLine(p.Name == p2.Name);
Console.WriteLine(p.ToString());


bool t = false;
Console.WriteLine(t?"true":"false");