/* ********************
 * Mã sinh viên: 202418889
 * Họ tên: Đặng Thị Hương Giang
 * ********************/
 using System;
using System.Collections.Generic;

public class LabRoom
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    private List<Device> Devices;

    public LabRoom(string id, string name, int capacity)
    {
        Id = id;
        Name = name;
        Capacity = capacity;
        Devices = new List<Device>();
    }

    public void AddDevice(Device device)
    {
        if (device == null) return;

        if (FindDevice(device.Id) != null)
        {
            Console.WriteLine($"[Lỗi] Thiết bị mã {device.Id} đã tồn tại trong phòng!");
            return;
        }

        Devices.Add(device);
    }

    public bool RemoveDevice(string deviceId)
    {
        Device? d = FindDevice(deviceId); // Thêm ? để fix cảnh báo vàng
        if (d != null)
        {
            Devices.Remove(d);
            return true;
        }
        return false;
    }

    public Device? FindDevice(string deviceId) // Thêm ? để fix cảnh báo vàng
    {
        foreach (var d in Devices)
        {
            if (d.Id == deviceId) return d;
        }
        return null;
    }

    public decimal CalculateAnnualMaintenanceCost()
    {
        decimal total = 0;
        foreach (var d in Devices)
        {
            // Sửa lỗi đỏ: Đổi TinhTienBaoTri thành tên tiếng Anh
            total += d.CalculateExpectedAnnualMaintenanceCost(); 
        }
        return total;
    }

    public List<Device> GetDevicesRequiringMaintenance()
    {
        List<Device> result = new List<Device>();
        foreach (var d in Devices)
        {
            int age = DateTime.Now.Year - d.Year;
            if (d.Status == DeviceStatus.UnderMaintenance || age > 5)
            {
                result.Add(d);
            }
        }
        return result;
    }

    public List<Device> GetAllDevices()
    {
        return Devices;
    }
}