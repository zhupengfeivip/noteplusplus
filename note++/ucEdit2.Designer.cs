
namespace notePlus
{
    partial class ucEdit2
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
            this.textEditor = new ICSharpCode.TextEditor.TextEditorControl();
            this.SuspendLayout();
            // 
            // textEditor
            // 
            this.textEditor.AutoScroll = true;
            this.textEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditor.IsReadOnly = false;
            this.textEditor.Location = new System.Drawing.Point(0, 0);
            this.textEditor.Name = "textEditor";
            this.textEditor.Size = new System.Drawing.Size(543, 387);
            this.textEditor.TabIndex = 0;
            this.textEditor.Text = "textEditorControl1";
            // 
            // ucEdit2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textEditor);
            this.Name = "ucEdit2";
            this.Size = new System.Drawing.Size(543, 387);
            this.ResumeLayout(false);

        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl textEditor;
    }
}
