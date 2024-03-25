using System.Collections;

namespace APBDc3.Models.Base;

public class Ship
{
    private ArrayList AllContainers;
    private int maxContainerNumber { get; set; }
    private double MaxSpeed { get; set; }
    private double MaxLoadWeight { get; set; }
    private int Id;
    private static int IdCounter;

    public Ship(int maxContainerNumber, double maxSpeed, double maxLoadWeight)
    {
        this.maxContainerNumber = maxContainerNumber;
        MaxSpeed = maxSpeed;
        MaxLoadWeight = maxLoadWeight;
        AllContainers = new ArrayList();
        Id = IdCounter;
        IdCounter++;
    }

    public void LoadContainer(ContainerBase con)
    {
        double weight = con.LoadWeight;
        foreach (ContainerBase c in AllContainers)
        {
            weight += c.LoadWeight;
        }
        if (AllContainers.Count < maxContainerNumber && weight < MaxLoadWeight)
        {
            AllContainers.Add(con);
        }
    }

    public void LoadContainers(ContainerBase[] con)
    {
        foreach (ContainerBase c in con)
        {
            LoadContainer(c);
        }
    }

    public void UnLoadContainer(String id)
    {
        ContainerBase conToRemove = null;
        foreach (ContainerBase con in AllContainers)
        {
            if (con.ID == id)
            {
                conToRemove = con;
            }
        }

        if (conToRemove == null)
        {
            Console.WriteLine("There is no such container on this ship");
            return;
        }
        AllContainers.Remove(conToRemove);
    }
    
    public void ReplaceContainer(ContainerBase con, String idToReplace)
    {
        ContainerBase containerToReplace = null;
        int IndexToReplace = -1;
        int counter = 0;
        foreach (ContainerBase t in AllContainers)
        {
            if (idToReplace == t.ID)
            {
                containerToReplace = t;
                IndexToReplace = counter;
            }

            counter++;
        }
        if (IndexToReplace == -1)
        {
            Console.WriteLine("There is no such container on this ship");
            return;
        }
        AllContainers.Insert(IndexToReplace,con);
    }

    public void TransferContainer(ContainerBase con, Ship ship)
    {
        AllContainers.Remove(con);
        ship.AllContainers.Add(con);
    }

    public String ToString()
    {
        return "Ship " + Id + "(speed:" + MaxSpeed + ", maxContainerNum: "
               + maxContainerNumber + ", maxWeight: " + MaxLoadWeight + ")";
    }
}