/* ********************
 * Mã sinh viên: 202418889
 * Họ tên: Đặng Thị Hương Giang
 * ********************/
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