/* ********************
 * Mã sinh viên: 202418889
 * Họ tên: Đặng thị Hương Giang 
 * ********************/
using System;

public enum DeviceStatus { Active, UnderMaintenance, Retired }

public interface INetworkable
{
    string IpAddress { get; }
    void Connect(string ipAddress);
    void Disconnect();
    bool IsConnected { get; }
}

public abstract class Device
{
    public string Id { get; } 
    public string Name { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public DeviceStatus Status { get; set; }

    public Device(string id, string name, int year, decimal price)
    {
       
        Id = id;
        Name = name;
        Year = year;
        Price = price;
        Status = DeviceStatus.Active;
    }

    public abstract decimal CalculateExpectedAnnualMaintenanceCost();

    public override string ToString()
    {
        return $"[{Id}] {Name} - Nam: {Year} - Gia: {Price} - Trang thai: {Status}";
    }
}

public class Computer : Device, INetworkable
{
    public int Ram { get; set; }
    public string Processor { get; set; }
    public bool HasGPU { get; set; }
    
    public string IpAddress { get; private set; }
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
        if (HasGPU) cost += Price * 0.02m;
        
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
        IpAddress = string.Empty;
        IsConnected = false;
    }
}

public class Printer : Device
{
    public string Type { get; set; } 
        public int PrintedPages { get; set; }
    public bool IsColor { get; set; } 

    public Printer(string id, string name, int year, decimal price, string type, int pages, bool isColor) 
        : base(id, name, year, price)
    {
        Type = type;
        PrintedPages = pages;
        IsColor = isColor;
    }

    public override decimal CalculateExpectedAnnualMaintenanceCost()
    {
        decimal cost = Price * 0.04m;
        if (PrintedPages > 100000) cost += 500000;
        if (IsColor) cost += 300000;
        return cost;
    }
}


public class NetworkPrinter : Printer, INetworkable
{
    public string IpAddress { get; private set; }
    public bool IsConnected { get; private set; }

    public NetworkPrinter(string id, string name, int year, decimal price, string type, int pages, bool isColor) 
        : base(id, name, year, price, type, pages, isColor) { }

    public void Connect(string ipAddress)
    {
        if (string.IsNullOrEmpty(ipAddress) || IsConnected) return;
        IpAddress = ipAddress;
        IsConnected = true;
    }

    public void Disconnect()
    {
        IpAddress = string.Empty;
        IsConnected = false;
    }
}

public class Projector : Device
{
    public int Brightness { get; set; }
    public int LampHours { get; set; }
    public int MaxLampLife { get; set; } 
    public Projector(string id, string name, int year, decimal price, int brightness, int lampHours) 
        : base(id, name, year, price)
    {
        Brightness = brightness;
        LampHours = lampHours;
        MaxLampLife = 5000; 
    }

    public override decimal CalculateExpectedAnnualMaintenanceCost()
    {
        decimal cost = Price * 0.03m;
        if (LampHours > 3000) cost += 1500000;
        return cost;
    }
}