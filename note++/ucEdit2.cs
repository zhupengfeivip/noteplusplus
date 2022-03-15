using ICSharpCode.TextEditor.Document;
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
    public partial class ucEdit2 : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public string FilePath;


        string[] modes = new string[] { "ASP3/XHTML", "BAT", "Boo", "Coco", "C++.NET", "C#", "HTML", "Java", "JavaScript", "PHP", "TeX", "VBNET", "XML", "TSQL" };

        public ucEdit2(string openFilePath)
        {
            InitializeComponent();

            FilePath = openFilePath;
            //textEditor.ShowLineNumbers = true;
            //textEditor.Font = new System.Windows.Media.FontFamily("Cascadia Code");
            //textEditor.FontSize = 13;
            string ext = Path.GetExtension(openFilePath);
            textEditor.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy(GetHighlightingStrategyByExtension(ext));
            textEditor.Text = System.IO.File.ReadAllText(openFilePath);
            
        }

        private string GetHighlightingStrategyByExtension(string ext)
        {
            switch (ext.ToLower())
            {
                case ".asp":
                    return "ASP3/XHTML";
                case ".bat":
                    return "BAT";
                case ".cs":
                    return "C#";
                case ".htm":
                case ".html":
                    return "HTML";
                default:
                    return "";
            }
        }
    }
}
