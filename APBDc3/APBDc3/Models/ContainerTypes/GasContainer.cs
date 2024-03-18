using APBDc3.Models.Base;

namespace APBDc3.Models.ContainerTypes;

public class GasContainer : ContainerBase
{
    public GasContainer(double loadWeight, double ownWeight, double maxWeight, double height, double depth) : base(loadWeight, ownWeight, maxWeight, height, depth)
    {
    }

}