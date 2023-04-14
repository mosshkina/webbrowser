using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace webbrowser
{
    
    public partial class WebBrowser : Form
    {
        int i = 0;
        public System.Windows.Forms.WebBrowser wp = new System.Windows.Forms.WebBrowser();
        public WebBrowser()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.WebBrowser webBrowser = new System.Windows.Forms.WebBrowser();   
            webBrowser.Visible = true;
            webBrowser.ScriptErrorsSuppressed= true;
            webBrowser.Dock= DockStyle.Fill;
            webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
            tabControl1.TabPages.Add("New Page");
            tabControl1.SelectTab(i);
            tabControl1.SelectedTab.Controls.Add(webBrowser);
            i += 1;
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl1.SelectedTab.Text = ((System.Windows.Forms.WebBrowser)tabControl1.SelectedTab.Controls[0]).DocumentTitle;
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            if(toolStripTextBox1.Text != null)
            {
                ((System.Windows.Forms.WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripTextBox1.Text);
            }
            else
            {

            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            ((System.Windows.Forms.WebBrowser)tabControl1.SelectedTab.Controls[0]).GoBack();
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            ((System.Windows.Forms.WebBrowser)tabControl1.SelectedTab.Controls[0]).GoForward();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            ((System.Windows.Forms.WebBrowser)tabControl1.SelectedTab.Controls[0]).Refresh();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count > 1)
            { 
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
                i -=1;
            }
            else
                Application.Exit();
        }

        private void toolStripTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((System.Windows.Forms.WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripTextBox1.Text);
            }
        }
        public void ToListHis(List<string> list, XmlElement doc) // добавление информации при запуске прграммы
        {
            foreach (XmlElement elem in doc)
            {
                list.Add($"{elem.ChildNodes[0].InnerText} {elem.ChildNodes[1].InnerText}");
            }
        }
       
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
