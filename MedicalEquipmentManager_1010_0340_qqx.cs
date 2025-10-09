// 代码生成时间: 2025-10-10 03:40:25
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

// 医疗设备管理类
public class MedicalEquipmentManager
{
    // 医疗设备列表
    private List<MedicalEquipment> equipmentList = new List<MedicalEquipment>();

    // 构造函数
    public MedicalEquipmentManager()
    {
        // 初始化设备列表
        InitializeEquipmentList();
    }

    // 初始化设备列表
    private void InitializeEquipmentList()
    {
        // 填充一些示例设备
        equipmentList.Add(new MedicalEquipment("ECG Machine", 2023));
        equipmentList.Add(new MedicalEquipment("Ultrasound", 2022));
        equipmentList.Add(new MedicalEquipment("X-Ray", 2021));
    }

    // 获取所有医疗设备的方法
    public List<MedicalEquipment> GetAllEquipments()
    {
        return equipmentList;
    }

    // 添加医疗设备的方法
    public void AddEquipment(MedicalEquipment equipment)
    {
        if (equipment == null)
        {
            throw new ArgumentNullException(nameof(equipment), "Equipment cannot be null");
        }

        // 检查设备是否已存在
        if (equipmentList.Any(e => e.Name == equipment.Name))
        {
            throw new InvalidOperationException("Equipment already exists");
        }

        equipmentList.Add(equipment);
    }

    // 删除医疗设备的方法
    public void RemoveEquipment(string equipmentName)
    {
        var equipment = equipmentList.FirstOrDefault(e => e.Name == equipmentName);
        if (equipment == null)
        {
            throw new InvalidOperationException("Equipment not found");
        }

        equipmentList.Remove(equipment);
    }
}

// 医疗设备类
public class MedicalEquipment
{
    public string Name { get; private set; }
    public int YearOfManufacture { get; private set; }

    // 构造函数
    public MedicalEquipment(string name, int yearOfManufacture)
    {
        Name = name;
        YearOfManufacture = yearOfManufacture;
    }
}
