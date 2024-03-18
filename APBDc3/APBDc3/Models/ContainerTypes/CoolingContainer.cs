using APBDc3.Models.Base;

namespace APBDc3.Models.ContainerTypes;

public class CoolingContainer : ContainerBase
{
    public CoolingContainer(double loadWeight, double ownWeight, double maxWeight, double height, double depth) : base(loadWeight, ownWeight, maxWeight, height, depth)
    {
    }
}