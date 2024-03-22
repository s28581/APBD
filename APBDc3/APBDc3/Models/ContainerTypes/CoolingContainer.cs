using APBDc3.Models.Base;

namespace APBDc3.Models.ContainerTypes;

public class CoolingContainer: ContainerBase
{
    protected static int IDNumber = 1;
    public CoolingContainer(double loadWeight, double ownWeight, double maxLoadWeight, double height, double depth) : base(loadWeight, ownWeight, maxLoadWeight, height, depth)
    {
        ID = "KON-C-" + IDNumber;
        IDNumber++;
    }

    public String ToString()
    {
        return ID;
    }
}