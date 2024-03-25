using APBDc3.Exceptions;

namespace APBDc3.Models.Base;

public abstract class ContainerBase
{
    public double LoadWeight { get; set; } = 0;
    public double OwnWeight { get; set; }
    protected double MaxLoadWeight { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public string ID { get; set; }

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