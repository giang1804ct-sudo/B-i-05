/* ********************
 * Mã sinh viên: 202418889
 * Họ tên: Đặng Thị Hương Giang
 * ********************/
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
