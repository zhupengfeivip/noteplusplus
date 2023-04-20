using ICSharpCode.AvalonEdit.Highlighting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace notePlus
{
    public partial class FrmMain : Form
    {
        public FrmMain(string openFilePath)
        {
            InitializeComponent();

            if (string.IsNullOrWhiteSpace(openFilePath) == false)
                OpenFilePath(openFilePath);
            else
                新建NToolStripMenuItem.PerformClick();
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.Filter = "文本文本|*.txt;*.log;*.bat;*.cs;*.php;*.html;*.js;*.ts;*.ini;*.config;*.css|所有文件(*.*)|*.*";
            dlg.CheckFileExists = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < dlg.FileNames.Length; i++)
                {
                    string currentFileName = dlg.FileNames[i];

                    ICSharpCode.AvalonEdit.TextEditor textEditor = new ICSharpCode.AvalonEdit.TextEditor();
                    textEditor.ShowLineNumbers = true;
                    textEditor.FontFamily = new System.Windows.Media.FontFamily("Cascadia Code");
                    //textEditor.FontStyle = FontStyle.Regular;
                    //textEditor.Font =  new Font(textEditor.Font, textEditor.Font.Style | FontStyle.Regular);
                    textEditor.FontSize = 13;
                    textEditor.Load(currentFileName);
                    string ext = Path.GetExtension(currentFileName);
                    textEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(ext);
                    if (textEditor.SyntaxHighlighting == null)
                    {
                        switch (ext)
                        {
                            default:
                                textEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.DefaultIndentationStrategy();
                                break;
                        }
                    }

                    ElementHost host = new ElementHost();
                    host.Child = textEditor;
                    host.Dock = DockStyle.Fill;

                    TabPage page = new TabPage();
                    page.Text = dlg.SafeFileNames[i];
                    page.Controls.Add(host);
                    tabControlMain.Controls.Add(page);
                    tabControlMain.SelectedTab = page;
                }
            }
        }

        private void OpenFilePath(string openFilePath)
        {
            //ICSharpCode.AvalonEdit.TextEditor textEditor = new ICSharpCode.AvalonEdit.TextEditor();
            //textEditor.ShowLineNumbers = true;
            //textEditor.FontFamily = new System.Windows.Media.FontFamily("Cascadia Code");
            ////textEditor.FontStyle = FontStyle.Regular;
            ////textEditor.Font =  new Font(textEditor.Font, textEditor.Font.Style | FontStyle.Regular);
            //textEditor.FontSize = 13;
            //textEditor.Load(openFilePath);
            //string ext = Path.GetExtension(openFilePath);
            //textEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(ext);
            //if (textEditor.SyntaxHighlighting == null)
            //{
            //    switch (ext)
            //    {
            //        default:
            //            textEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.DefaultIndentationStrategy();
            //            break;
            //    }
            //}

            //ElementHost host = new ElementHost();
            //host.Child = textEditor;
            //host.Dock = DockStyle.Fill;

            TabPage page = new TabPage();
            page.Text = openFilePath;
            //ucEdit uc = new ucEdit(openFilePath);
            ucEdit2 uc = new ucEdit2(openFilePath);
            uc.Dock = DockStyle.Fill;
            page.Controls.Add(uc);
            tabControlMain.Controls.Add(page);
            tabControlMain.SelectedTab = page;
        }

        private void 新建NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICSharpCode.AvalonEdit.TextEditor textEditor = new ICSharpCode.AvalonEdit.TextEditor();
            textEditor.ShowLineNumbers = true;

            ElementHost host = new ElementHost();
            host.Child = textEditor;
            host.Dock = DockStyle.Fill;

            TabPage page = new TabPage();
            page.Text = "未命名记事本";
            page.Controls.Add(host);
            tabControlMain.Controls.Add(page);
            tabControlMain.SelectedTab = page;
            textEditor.Focus();
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SaveFileDialog dlg = new SaveFileDialog();
            //dlg.DefaultExt = ".txt";
            //DialogResult dr = dlg.ShowDialog();
            //if (dr != DialogResult.OK) return;
            //string currentFileName = dlg.FileName;

            TabPage page = tabControlMain.SelectedTab;
            ucEdit edit = page.Controls[0] as ucEdit;
            if (edit == null) return;

            edit.SaveFile();

            //ElementHost host = page.Controls[0] as ElementHost;
            //if (host == null) return;
            //ICSharpCode.AvalonEdit.TextEditor textEditor = host.Child as ICSharpCode.AvalonEdit.TextEditor;
            //if (textEditor == null) return;

            //textEditor.Save(currentFileName);
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = fontDialog1.ShowDialog();
            if (dr != DialogResult.OK) return;

            TabPage page = tabControlMain.SelectedTab;
            ucEdit edit = page.Controls[0] as ucEdit;
            if (edit == null) return;

            edit.SaveFile();
            //ElementHost host = page.Controls[0] as ElementHost;
            //if (host == null) return;
            //ICSharpCode.AvalonEdit.TextEditor textEditor = host.Child as ICSharpCode.AvalonEdit.TextEditor;
            //if (textEditor == null) return;

            edit.SetFontSize(fontDialog1.Font.Size);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void 选项OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfig frm = new FrmConfig();
            frm.ShowDialog(this);
        }
    }
}
