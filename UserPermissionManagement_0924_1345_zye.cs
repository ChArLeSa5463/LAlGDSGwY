// 代码生成时间: 2025-09-24 13:45:04
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

// 用户权限管理系统类
public class UserPermissionManagement
{
    // 用户权限列表
    private Dictionary<string, List<string>> userPermissions = new Dictionary<string, List<string>>();

    // 添加用户权限
    public void AddUserPermission(string username, string permission)
    {
        if (!userPermissions.ContainsKey(username))
        {
            userPermissions[username] = new List<string>();
        }

        if (!userPermissions[username].Contains(permission))
        {
            userPermissions[username].Add(permission);
        }
        else
        {
            throw new Exception("Permission already exists for the user.");
        }
    }

    // 移除用户权限
    public void RemoveUserPermission(string username, string permission)
    {
        if (userPermissions.ContainsKey(username) && userPermissions[username].Contains(permission))
        {
            userPermissions[username].Remove(permission);
        }
        else
        {
            throw new Exception("Permission does not exist for the user.");
        }
    }

    // 检查用户是否具有特定权限
    public bool CheckUserPermission(string username, string permission)
    {
        if (userPermissions.ContainsKey(username) && userPermissions[username].Contains(permission))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // 显示所有用户权限
    public void DisplayAllPermissions()
    {
        foreach (var user in userPermissions)
        {
            Console.WriteLine($"Username: {user.Key}, Permissions: {string.Join(", ", user.Value)}");
        }
    }
}
