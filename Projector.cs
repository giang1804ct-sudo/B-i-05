/* ********************
 * Mã sinh viên: 202418889
 * Họ tên: Đặng Thị Hương Giang
 * ********************/
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