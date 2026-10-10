/* ********************
 * Mã sinh viên: 202418889
 * Họ tên: Đặng Thị Hương Giang
 * ********************/
 using System;
using System.Collections.Generic;

public class LabRoom
{
    public string Maphong { get; set; }
    public string Tenphong { get; set; }
    public int Succhua { get; set; }
    private List<Device> danhsachmay;
    public LabRoom(string id, string name, int capacity)
    {
     Maphong = id;
     Tenphong = name;
     Succhua = capacity;
        danhsachmay = new List<Device>();
    }

    public void ThemThietBi(Device d)
    {
        // TODO: quen chua check trung ID
        danhsachmay.Add(d);
    }

    public bool Xoahietbi(string id)
    {
        Device d = Timthietbi(id);
        if (d != null)
        {
         danhsachmay.Remove(d);
            return true;
        }
        return false;
    }

    public Device Timthietbi(string id)
    {
     foreach (var d in danhsachmay)
        {
         if (d.Id == id) return d;
        }
        return null;
    }

    public decimal Tinhtongtienbaotri()
    {
        decimal tong = 0;
        foreach (var d in danhsachmay)
        {
            tong += d.Tinhtienbaotri(); 
        }
        return tong;
    }

    public List<Device> Laymaycanbaotri()
    {
        List<Device> kq = new List<Device>();
        foreach (var d in danhsachmay)
        {
            int soNam = DateTime.Now.Year - d.Year;
            if (d.Status == DeviceStatus.UnderMaintenance || soNam > 5)
            {
                kq.Add(d);
            }
        }
        return kq;
    }

    public List<Device> Laytatcamay()
    {
        return danhsachmay;
    }
}