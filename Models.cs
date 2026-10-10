/* ********************
 * Mã sinh viên: [Điền mã của bạn]
 * Họ tên: Đặng Thị Hương Giang
 * ********************/
using System;

public enum DeviceStatus { Active, UnderMaintenance, Retired }

public interface INetworkable
{
 string IpAddress { get; }
 void Connect(string ip);
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
        // TODO:  check điều kiện (giá > 0, năm...)
        Id = id;
        Name = name;
        Year = year;
        Price = price;
        Status = DeviceStatus.Active;
    }

    public abstract decimal Tinhtienbaotri(); 

    public override string ToString()
    {
        return $"[{Id}] {Name} - Năm: {Year} - Giá: {Price:N0} - Trạng thái: {Status}";
    }
}

public class Computer : Device, INetworkable
{
  public int Ram { get; set; }
  public string CPU { get; set; }
  public bool CoCardroi { get; set; } 
    
 public string IpAddress { get; private set; }
 public bool IsConnected { get; private set; }

    public Computer(string id, string name, int year, decimal price, int ram, string cpu, bool cocardroi) 
        : base(id, name, year, price)
    {
        Ram = ram;
        CPU = cpu;
        CoCardroi = cocardroi;
    }

    public override decimal Tinhtienbaotri()
    {
        decimal tien = Price * 0.05m;
        if (CoCardroi) 
        {
            tien += Price * 0.02m;
        }
       
        return tien;
    }

    public void Connect(string ip)
    {
        if (string.IsNullOrEmpty(ip) || IsConnected) return;
        IpAddress = ip;
        IsConnected = true;
    }

    public void Disconnect()
    {
        IpAddress = "";
        IsConnected = false;
    }
}

public class Printer : Device
{
    public string Loaimay { get; set; } // Laser hoặc In phun
    public int Sotrangdain { get; set; }
    public bool Inmau { get; set; }

    public Printer(string id, string name, int year, decimal price, string loaiMay, int soTrang, bool inMau) 
        : base(id, name, year, price)
    {
        Loaimay = loaiMay;
        Sotrangdain = soTrang;
        Inmau = inMau;
    }

    public override decimal Tinhtienbaotri()
    {
        decimal tien = Price * 0.04m;
        if (Sotrangdain > 100000) tien += 500000;
        if (Inmau) tien += 300000;
        return tien;
    }
}

// Máy in mạng
public class NetworkPrinter : Printer, INetworkable
{
    public string IpAddress { get; private set; }
    public bool IsConnected { get; private set; }

    public NetworkPrinter(string id, string name, int year, decimal price, string loaiMay, int soTrang, bool inMau) 
        : base(id, name, year, price, loaiMay, soTrang, inMau) { }

    public void Connect(string ip)
    {
        if (string.IsNullOrEmpty(ip) || IsConnected) return;
        IpAddress = ip;
        IsConnected = true;
    }

    public void Disconnect()
    {
        IpAddress = "";
        IsConnected = false;
    }
}

public class Projector : Device
{
    public int Dosang { get; set; }
    public int Giobongden { get; set; }

    public Projector(string id, string name, int year, decimal price, int dosang, int giobongden) 
        : base(id, name, year, price)
    {
        Dosang = dosang;
        Giobongden = giobongden;
    }

    public override decimal Tinhtienbaotri()
    {
        decimal tien = Price * 0.03m;
        if (Giobongden > 3000) tien += 1500000;
        return tien;
    }
}