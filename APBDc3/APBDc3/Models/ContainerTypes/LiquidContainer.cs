using APBDc3.Exceptions;
using APBDc3.Models.Base;

namespace APBDc3.Models.ContainerTypes;

public class LiquidContainer : ContainerBase, IHazardNotifier
{
    private static int IdCounter { get; set; }
    public LiquidContainer(double ownWeight, double maxLoadWeight, double height, double depth) : base( ownWeight, maxLoadWeight, height, depth)
    {
        ID = "KON-L-" + IdCounter;
        IdCounter++;
    }

    public void Load(double weightToLoad, Product product)
    {
        LoadWeight += weightToLoad;
        if (LoadWeight > MaxLoadWeight * (product.IsDangerous ? 0.5 : 0.9))
        {
            LoadWeight = MaxLoadWeight * (product.IsDangerous ? 0.5 : 0.9);
            IHazardNotifier.SendDangerNotification(ID);
        }
        
    }
    
    public String ToString()
    {
        return ID;
    }

}
