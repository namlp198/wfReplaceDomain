using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfReplaceDomain
{
    public partial class Form1 : Form
    {
        List<string> lstDomain = new List<string>();
        string str;
        string res;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (StreamReader reader = File.OpenText(@"C:\Users\namlp\Desktop\Test\testdomain.txt"))
            {
                char[] ch = new char[1] { '\n' };
                str = reader.ReadToEnd();
                lstDomain = str.Split(ch).ToList();

                for (int i = 0; i < lstDomain.Count; i++)
                {
                    listBox1.Items.Add(lstDomain[i]);
                }
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\Users\namlp\Desktop\Test\testdomain.txt", res);
            MessageBox.Show("OK");
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            //Regex r = new Regex(@"(?<=\.)(.+?)(?=\r)|(?<=\.)(.+?)(?=;)");
            //MatchCollection mc = r.Matches(str);
            //for (int i = 0; i < mc.Count; i++)
            //{
            //    string s = mc[i].Groups[i].Value;
            //    listBox2.Items.Add(mc[i].Groups[i].Value);
            //}
            listBox2.Items.Clear();
            char[] ch = new char[2] { '\n', ';' };
            res = Regex.Replace(str, string.Format("(?<=\\{0})(.+?)(?=\r)|(?<=\\{0})(.+?)(?=;)",textBox2.Text.Trim()), textBox1.Text);
            string[] lines = res.Split(ch);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length > 0)
                    listBox2.Items.Add(lines[i]);
            }
        }
    }
}
