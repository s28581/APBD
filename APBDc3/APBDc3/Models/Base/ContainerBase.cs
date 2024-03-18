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
    
}