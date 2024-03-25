using APBDc3.Models.Base;

namespace APBDc3.Models.ContainerTypes;

public class GasContainer : ContainerBase
{
    private static int IdCounter { get; set; }
    private double Pressure { get; set; } = 1;
    public GasContainer(double ownWeight, double maxLoadWeight, double height, double depth) : base(ownWeight, maxLoadWeight, height, depth)
    {
        ID = "KON-G-" + IdCounter;
        IdCounter++;
    }

    public void UnLoad()
    {
        LoadWeight = 0.05 * LoadWeight;
        Pressure = 1;
    }

    public void Load(double weightToLoad)
    {
        base.Load(weightToLoad);
        Pressure += weightToLoad / LoadWeight * 100;
    }
    public String ToString()
    {
        return ID;
    }

}