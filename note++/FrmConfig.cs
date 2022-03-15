using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace notePlus
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddFileContextMenuItem("使用 NotePlus 打开");
        }

        /// <summary>
        /// 文件添加右键菜单
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="associatedProgramFullPath"></param>
        private void AddFileContextMenuItem(string itemName)
        {
            string associatedProgramFullPath = Process.GetCurrentProcess().MainModule.FileName + " %1";
            AddFileContextMenuItem(itemName, associatedProgramFullPath);
        }

        /// <summary>
        /// 文件添加右键菜单
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="associatedProgramFullPath"></param>
        private void AddFileContextMenuItem(string itemName, string associatedProgramFullPath)
        {
            //创建项：shell 
            RegistryKey shellKey = Registry.ClassesRoot.OpenSubKey(@"*\shell", true);
            if (shellKey == null)
                shellKey = Registry.ClassesRoot.CreateSubKey(@"*\shell");

            //创建项：右键显示的菜单名称
            RegistryKey rightCommondKey = shellKey.CreateSubKey(itemName);
            RegistryKey associatedProgramKey = rightCommondKey.CreateSubKey("command");

            //创建默认值：关联的程序
            associatedProgramKey.SetValue(string.Empty, associatedProgramFullPath);

            //刷新到磁盘并释放资源
            associatedProgramKey.Close();
            rightCommondKey.Close();
            shellKey.Close();
        }

        private void RemovedFileContextMenuItem(string itemName)
        {
            RegistryKey shellKey = Registry.ClassesRoot.OpenSubKey(@"*\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
            if (shellKey == null)
                shellKey = Registry.ClassesRoot.CreateSubKey(@"*\shell");

            shellKey.DeleteSubKey($"{itemName}\\command");
            shellKey.DeleteSubKey(itemName);

            //刷新到磁盘并释放资源
            shellKey.Close();

            RegistryKey shellKey1 = Registry.ClassesRoot.OpenSubKey(@"directory\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
            if (shellKey1 == null)
                shellKey1 = Registry.ClassesRoot.CreateSubKey(@"directory\shell");

            shellKey1.DeleteSubKey("资源拷贝工具(" + Application.ProductVersion + ")\\command");
            shellKey1.DeleteSubKey("资源拷贝工具(" + Application.ProductVersion + ")");
            shellKey1.Close();
        }

        private void RemoveddDirectoryContextMenuItem(string itemName)
        {
            RegistryKey shellKey = Registry.ClassesRoot.OpenSubKey(@"directory\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
            if (shellKey == null)
                shellKey = Registry.ClassesRoot.CreateSubKey(@"directory\shell");

            shellKey.DeleteSubKey($"{itemName}\\command");
            shellKey.DeleteSubKey(itemName);

            //刷新到磁盘并释放资源
            shellKey.Close();
        }


        private bool GetIsAddRightMenu()
        {
            RegistryKey shellKey = Registry.ClassesRoot.OpenSubKey(@"*\shell", RegistryKeyPermissionCheck.ReadSubTree, System.Security.AccessControl.RegistryRights.ReadKey);
            if (shellKey == null)
                return false;

            RegistryKey rightMenuKey = shellKey.OpenSubKey("ContextMenuHandlers");
            if (rightMenuKey == null)
                return false;

            RegistryKey resCopyToolKey = rightMenuKey.OpenSubKey("ResCopyToolExtension");
            if (resCopyToolKey == null)
                return false;            

            resCopyToolKey.Close();
            rightMenuKey.Close();
            shellKey.Close();

            return true;
        }

        /// <summary>
        /// 文件夹添加右键菜单
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="associatedProgramFullPath"></param>
        private void AddDirectoryContextMenuItem(string itemName, string associatedProgramFullPath)
        {
            //创建项：shell 
            RegistryKey shellKey = Registry.ClassesRoot.OpenSubKey(@"directory\shell", true);
            if (shellKey == null)
                shellKey = Registry.ClassesRoot.CreateSubKey(@"*\shell");

            //创建项：右键显示的菜单名称
            RegistryKey rightCommondKey = shellKey.CreateSubKey(itemName);
            RegistryKey associatedProgramKey = rightCommondKey.CreateSubKey("command");

            //创建默认值：关联的程序
            associatedProgramKey.SetValue("", associatedProgramFullPath);

            //刷新到磁盘并释放资源
            associatedProgramKey.Close();
            rightCommondKey.Close();
            shellKey.Close();
        }
    }
}
