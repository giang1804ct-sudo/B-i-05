using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("====== QUẢN LÝ THIẾT BỊ LAB ======\n");

        // tạo máy tính
        Computer mt1 = new Computer("MT01", "Dell Optiplex", 2021, 15000000, 8, "Core i5", false);
        Computer mt2 = new Computer("MT02", "Alienware", 2018, 30000000, 16, "Core i7", true); 
        
        // tạo máy in
        Printer mayIn1 = new Printer("PR01", "Canon 2900", 2022, 3500000, "Laser", 120000, false); 
        NetworkPrinter mayIn2 = new NetworkPrinter("PR02", "HP ColorJet", 2023, 8000000, "Ink", 50000, true); 
        
        // tạo máy chiếu
        Projector mayChieu1 = new Projector("PJ01", "Sony VPL", 2019, 12000000, 3500, 3200); 

        // test trạng thái
        mt1.Status = DeviceStatus.UnderMaintenance; 

        // tạo phòng
        LabRoom phong1 = new LabRoom("LAB-01", "Phòng TH Phần Mềm", 30);
        LabRoom phong2 = new LabRoom("LAB-02", "Phòng TH Mạng", 20);

        phong1.ThemThietBi(mt1);
        phong1.ThemThietBi(mayIn1);
        phong1.ThemThietBi(mayChieu1);

        phong2.ThemThietBi(mt2);
        phong2.ThemThietBi(mayIn2);

        // Test them trung ma
        Console.WriteLine("=> Thêm máy trùng ID vào Phòng 1:");
        phong1.ThemThietBi(mt1); 
        Console.WriteLine();

        // In danh sach
        Console.WriteLine("--- DANH SÁCH MÁY PHÒNG 1 ---");
        foreach (var d in phong1.Laytatcamay()) 
        {
            Console.WriteLine(d.ToString());
        }
        Console.WriteLine($"-> Tổng tiền bảo trì phòng 1: {phong1.Tinhtongtienbaotri():N0} VND\n");

        Console.WriteLine("--- DANH SÁCH MÁY PHÒNG 2 ---");
        foreach (var d in phong2.Laytatcamay()) Console.WriteLine(d.ToString());
        Console.WriteLine($"-> Tổng tiền bảo trì phòng 2: {phong2.Tinhtongtienbaotri():N0} VND\n");

        Console.WriteLine("--- CÁC MÁY CẦN BẢO TRÌ (PHÒNG 1) ---");
        foreach (var d in phong1.Laymaycanbaotri()) 
        {
            Console.WriteLine("- " + d.Name);
        }
        Console.WriteLine();

        // Test interface
        Console.WriteLine("--- TEST KẾT NỐI MẠNG ---");
        List<Device> tatCaMay = new List<Device> { mt1, mt2, mayIn1, mayIn2, mayChieu1 };
        
        foreach (var d in tatcamay)
        {
            if (d is INetworkable netDevice) 
            {
                netDevice.Connect("192.168.1.100");
                Console.WriteLine($"May {d.Name} đã kết nối vào IP: {netDevice.IpAddress}");
            }
        }
        
        Console.ReadLine();
    }
}