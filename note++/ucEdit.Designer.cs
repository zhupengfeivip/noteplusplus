﻿
namespace notePlus
{
    partial class ucEdit
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.eHost = new System.Windows.Forms.Integration.ElementHost();
            this.SuspendLayout();
            // 
            // eHost
            // 
            this.eHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eHost.Location = new System.Drawing.Point(0, 0);
            this.eHost.Name = "eHost";
            this.eHost.Size = new System.Drawing.Size(287, 148);
            this.eHost.TabIndex = 0;
            this.eHost.Text = "elementHost1";
            this.eHost.Child = null;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.eHost);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(287, 148);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost eHost;
    }
}
