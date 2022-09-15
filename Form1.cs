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

namespace Text07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
                StreamWriter sw = new StreamWriter("pomocny.txt");


                while (!streamReader.EndOfStream)
                {

                    string line = streamReader.ReadLine();
                    listBox1.Items.Add(line);
                   

                }
                streamReader.Close();
                sw.Close();


            }

            else
            {
                MessageBox.Show("Nebyl vybrán žádný soubor");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
         

                StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
              
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    foreach (char c in line)
                    {
                        if (char.IsUpper(c))
                        {
                            char.ToLower(c);
                        }
                    }
                }
                streamReader.Close();
              

                File.Delete(openFileDialog1.FileName);
                File.Move("pomocny.txt", openFileDialog1.FileName);

                //zobrazeni opraveneho souboru
                streamReader = new StreamReader(openFileDialog1.FileName);
                while (!streamReader.EndOfStream)
                {
                    string s = streamReader.ReadLine();
                    listBox2.Items.Add(s);
                }
                streamReader.Close();
            
        }
    }
}

