/* ********************
 * Mã sinh viên: 202418889
 * Họ tên: Đặng Thị Hương Giang
 * ********************/
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

