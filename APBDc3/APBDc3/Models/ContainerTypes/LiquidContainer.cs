using APBDc3.Models.Base;

namespace APBDc3.Models.ContainerTypes;

public class LiquidContainer : ContainerBase, IHazardNotifier
{
    private static int IDNumber = 1;
    public LiquidContainer(double loadWeight, double ownWeight, double maxLoadWeight, double height, double depth) : base(loadWeight, ownWeight, maxLoadWeight, height, depth)
    {
        ID = "KON-L-" + IDNumber;
        IDNumber++;
    }
    
    

}
