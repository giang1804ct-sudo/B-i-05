/* ********************
 * Mã sinh viên: 202418889
 * Họ tên: Đặng Thị Hương Giang
 * ********************/
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