namespace APBDc3;

public interface IHazardNotifier
{
    void SendDangerNotification(String ContainerID)
    {
        Console.WriteLine("Dangerous situation on " + ContainerID);
    }
}