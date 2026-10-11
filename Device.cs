/* ********************
 * Mã sinh viên: 202418889
 * Họ tên: Đặng Thị Hương Giang
 * ********************/
 using System;

public abstract class Device
{
    public string Id { get; } 
    public string Name { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public DeviceStatus Status { get; set; }

    public Device(string id, string name, int year, decimal price)
    {
        if (string.IsNullOrEmpty(id)) throw new Exception("Lỗi: Mã thiết bị không được để trống!");
        if (price <= 0) throw new Exception("Lỗi: Giá mua phải lớn hơn 0");
        if (year > DateTime.Now.Year) throw new Exception("Lỗi: Năm đưa vào sử dụng không được lớn hơn năm hiện tại");

        Id = id;
        Name = name;
        Year = year;
        Price = price;
        Status = DeviceStatus.Active;
    }

    public abstract decimal CalculateExpectedAnnualMaintenanceCost(); 

    public override string ToString()
    {
        return $"[{Id}] {Name} - Năm: {Year} - Giá: {Price:N0} - Trạng thái: {Status}";
    }
}