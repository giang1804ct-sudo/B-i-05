/* ********************
 * Mã sinh viên: 202418889
 * Họ tên: Đặng Thị Hương Giang
 * ********************/
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