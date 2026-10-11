/* ********************
 * Mã sinh viên: 202418889
 * Họ tên: Đặng Thị Hương Giang
 * ********************/
 using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("====== QUẢN LÝ THIẾT BỊ LAB ======\n");

        // Tạo máy tính
        Computer pc1 = new Computer("PC01", "Dell Optiplex", 2021, 15000000, 8, "Core i5", false);
        Computer pc2 = new Computer("PC02", "Alienware", 2018, 30000000, 16, "Core i7", true); 
        
        // Tạo máy in
        Printer prn1 = new Printer("PR01", "Canon 2900", 2022, 3500000, "Laser", 120000, false); 
        NetworkPrinter prn2 = new NetworkPrinter("PR02", "HP ColorJet", 2023, 8000000, "Ink", 50000, true); 
        
        // Tạo máy chiếu
        Projector proj1 = new Projector("PJ01", "Sony VPL", 2019, 12000000, 3500, 3200); 

        // Test đổi trạng thái
        pc1.Status = DeviceStatus.UnderMaintenance; 

        // Tạo phòng
        LabRoom lab1 = new LabRoom("LAB-01", "Phòng TH Phần Mềm", 30);
        LabRoom lab2 = new LabRoom("LAB-02", "Phòng TH Mạng", 20);

        // Gọi các hàm bằng tên tiếng Anh
        lab1.AddDevice(pc1);
        lab1.AddDevice(prn1);
        lab1.AddDevice(proj1);

        lab2.AddDevice(pc2);
        lab2.AddDevice(prn2);

        // Test thêm trùng mã
        Console.WriteLine("=> Thử thêm máy trùng ID vào Phòng 1:");
        lab1.AddDevice(pc1); 
        Console.WriteLine();

        // In danh sách
        Console.WriteLine("--- DANH SÁCH MÁY PHÒNG 1 ---");
        foreach (var d in lab1.GetAllDevices()) 
        {
            Console.WriteLine(d.ToString());
        }
        Console.WriteLine($"-> Tổng tiền bảo trì phòng 1: {lab1.CalculateAnnualMaintenanceCost():N0} VND\n");

        Console.WriteLine("--- DANH SÁCH MÁY PHÒNG 2 ---");
        foreach (var d in lab2.GetAllDevices()) Console.WriteLine(d.ToString());
        Console.WriteLine($"-> Tổng tiền bảo trì phòng 2: {lab2.CalculateAnnualMaintenanceCost():N0} VND\n");

        Console.WriteLine("--- CÁC MÁY CẦN BẢO TRÌ (PHÒNG 1) ---");
        foreach (var d in lab1.GetDevicesRequiringMaintenance()) 
        {
            Console.WriteLine("- " + d.Name);
        }
        Console.WriteLine();

        // Test interface kết nối mạng
        Console.WriteLine("--- TEST KẾT NỐI MẠNG ---");
        List<Device> allDevices = new List<Device> { pc1, pc2, prn1, prn2, proj1 };
        
        foreach (var d in allDevices)
        {
            if (d is INetworkable netDevice) 
            {
                netDevice.Connect("192.168.1.100");
                Console.WriteLine($"Máy {d.Name} đã kết nối vào IP: {netDevice.IpAddress}");
            }
        }
        
        Console.ReadLine();
    }
}