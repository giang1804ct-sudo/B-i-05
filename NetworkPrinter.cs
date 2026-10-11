/* ********************
 * Mã sinh viên: 202418889
 * Họ tên: Đặng Thị Hương Giang
 * ********************/
 public class NetworkPrinter : Printer, INetworkable
{
    public string IpAddress { get; private set; } = "";
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
        IpAddress = "";
        IsConnected = false;
    }
}