using APBDc3.Exceptions;

namespace APBDc3.Models.Base;

public abstract class ContainerBase
{
    protected double LoadWeight { get; set; }
    protected double OwnWeight { get; set; }
    protected double MaxLoadWeight { get; set; }
    protected double Height { get; set; }
    protected double Depth { get; set; }
    protected string ID { get; set; }

    public ContainerBase(double loadWeight, double ownWeight, double maxLoadWeight, double height, double depth)
    {
        LoadWeight = loadWeight;
        OwnWeight = ownWeight;
        MaxLoadWeight = maxLoadWeight;
        Height = height;
        Depth = depth;
    }

    public void Unload(double weightToUnload)
    {
        if (weightToUnload < LoadWeight)
        {
            LoadWeight -= weightToUnload;
        }
        else
        {
            Console.WriteLine("Not enough load to unload, unloaded " + LoadWeight + " kg");
            LoadWeight = 0;
        }
    }

    public void Load(double weightToLoad, Product product)
    {
        LoadWeight += weightToLoad;
        if (LoadWeight > MaxLoadWeight)
        {
            LoadWeight = MaxLoadWeight;
            throw new OverfillException();
        }
    }
    
}