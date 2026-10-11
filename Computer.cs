/* ********************
 * Mã sinh viên: 202418889
 * Họ tên: Đặng Thị Hương Giang
 * ********************/
 using System;

public class Computer : Device, INetworkable
{
    public int Ram { get; set; }
    public string Processor { get; set; }
    public bool HasGPU { get; set; }
    
    public string IpAddress { get; private set; } = "";
    public bool IsConnected { get; private set; }

    public Computer(string id, string name, int year, decimal price, int ram, string processor, bool hasGPU) 
        : base(id, name, year, price)
    {
        Ram = ram;
        Processor = processor;
        HasGPU = hasGPU;
    }

    public override decimal CalculateExpectedAnnualMaintenanceCost()
    {
        decimal cost = Price * 0.05m;
        if (HasGPU) 
        {
            cost += Price * 0.02m;
        }
        
        int age = DateTime.Now.Year - Year;
        if (age > 5) 
        {
            cost += Price * 0.01m;
        }
        
        return cost;
    }

    public void Connect(string ipAddress)
    {
        if (string.IsNullOrEmpty(ipAddress) || IsConnected) return;
        IpAddress = ipAddress;
        IsConnected = true;
    }

    public void Disconnect()
    {
        IpAddress = "";
        IsConnected = false;
    }
}