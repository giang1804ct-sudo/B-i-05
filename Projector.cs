/* ********************
 * Mã sinh viên: 202418889
 * Họ tên: Đặng Thị Hương Giang
 * ********************/
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
        MaxLampLife = 5000; // Giả sử mặc định tuổi thọ bóng đèn là 5000 giờ
    }

    public override decimal CalculateExpectedAnnualMaintenanceCost()
    {
        decimal cost = Price * 0.03m;
        if (LampHours > 3000) cost += 1500000;
        return cost;
    }
}