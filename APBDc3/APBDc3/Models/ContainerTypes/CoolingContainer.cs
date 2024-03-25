using APBDc3.Models.Base;

namespace APBDc3.Models.ContainerTypes;

public class CoolingContainer: ContainerBase
{
    private Product ProductStored = null;
    private double temerature;
    private static int IdCounter { get; set; }
    public CoolingContainer(double ownWeight, double maxLoadWeight, double height, double depth, double inTemperature) : base(ownWeight, maxLoadWeight, height, depth)
    {
        ID = "KON-C-" + IdCounter;
        IdCounter++;
        temerature = inTemperature;
    }

    public void Load(double weightToLoad, Product product)
    {
        if (LoadWeight == 0)
        {
            if (temerature >= product.StorageTemerature)
            {
                base.Load(weightToLoad);
                ProductStored = product;
            }
            else
            {
                Console.WriteLine("It is too cold for this product");
            }
        }else if (ProductStored.Name == product.Name)
        {
            LoadWeight += weightToLoad;
        }
    }

    public String ToString()
    {
        return ID;
    }
}