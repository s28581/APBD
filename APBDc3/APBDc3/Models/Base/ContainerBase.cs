using APBDc3.Exceptions;

namespace APBDc3.Models.Base;

public abstract class ContainerBase
{
    internal double LoadWeight { get; set; } = 0;
    protected double OwnWeight { get; set; }
    protected double MaxLoadWeight { get; set; }
    protected double Height { get; set; }
    protected double Depth { get; set; }
    internal string ID { get; set; }

    public ContainerBase( double ownWeight, double maxLoadWeight, double height, double depth)
    {
        OwnWeight = ownWeight;
        MaxLoadWeight = maxLoadWeight;
        Height = height;
        Depth = depth;
    }

    public void UnLoad()
    {
        LoadWeight = 0;
        
    }

    public void Load(double weightToLoad)
    {
        LoadWeight += weightToLoad;
        if (LoadWeight > MaxLoadWeight)
        {
            LoadWeight = MaxLoadWeight;
            throw new OverfillException();
        }
    }
    
}