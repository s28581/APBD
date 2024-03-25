namespace APBDc3;

public interface IHazardNotifier
{
    static void SendDangerNotification(String ContainerID)
    {
        Console.WriteLine("Dangerous situation on " + ContainerID);
    }
    static void SendNotification(String ContainerID, String Message)
    {
        Console.WriteLine("Dangerous situation on " + ContainerID);
    }
}