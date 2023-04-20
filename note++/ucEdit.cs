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

namespace notePlus
{
    public partial class ucEdit : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        ICSharpCode.AvalonEdit.TextEditor textEditor = new ICSharpCode.AvalonEdit.TextEditor();

        /// <summary>
        /// 
        /// </summary>
        public string FilePath;


        public ucEdit(string openFilePath)
        {
            InitializeComponent();

            FilePath = openFilePath;
            textEditor.ShowLineNumbers = true;
            textEditor.FontFamily = new System.Windows.Media.FontFamily("Cascadia Code");
            textEditor.FontSize = 13;
        
            textEditor.Load(openFilePath);
            textEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.DefaultIndentationStrategy();
            textEditor.WordWrap = true;
            textEditor.HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Hidden;
            string ext = Path.GetExtension(openFilePath);
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

            eHost.Child = textEditor;
            eHost.Dock = DockStyle.Fill;
        }


        public void SaveFile()
        {
            textEditor.Save(FilePath);
        }

        public void SetFontSize(float size)
        {
            textEditor.FontSize = size;
        }


    }
}
