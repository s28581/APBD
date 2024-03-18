using APBDc3.Exceptions;

namespace APBDc3.Models.Base;

public abstract class ContainerBase
{
    protected double LoadWeight { get; set; }
    protected double OwnWeight { get; set; }
    protected double MaxWeight { get; set; }
    protected double Height { get; set; }
    protected double Depth { get; set; }
    protected string ID { get; set; }

    public ContainerBase(double loadWeight, double ownWeight, double maxWeight, double height, double depth)
    {
        LoadWeight = loadWeight;
        OwnWeight = ownWeight;
        MaxWeight = maxWeight;
        Height = height;
        Depth = depth;
    }

    public void Unload(double weightToUnload)
    {
        LoadWeight -= weightToUnload;
    }

    public void Load(double weightToLoad)
    {
        LoadWeight += weightToLoad;
        if (LoadWeight > MaxWeight)
        {
            throw new OverfillException();
        }
    }
    
}