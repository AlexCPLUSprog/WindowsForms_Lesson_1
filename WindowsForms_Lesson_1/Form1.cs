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

namespace WindowsForms_Lesson_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            var color = new Color();
            color = Color.FromArgb(255, 0 , 255, 0);
            labelOutput.ForeColor = color;  
            
            try
            {
                var number = Convert.ToInt32(textBoxInput.Text);
                var result = Math.Pow(number, 2).ToString();
                labelOutput.Text = result;
            }
            catch
            {
                var message = "Не удалось преобразовать в число";
                MessageBox.Show(message);
                labelOutput.Text = message;
            }            
        }

        private void btnOpen_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();            
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = "Текстовые (шаблон *.txt)|*.txt" +
                "|Исходник (шаблон *.cs)|*.cs" +
                "|Все (шаблон *.*)|*.*";
            var result = openFileDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    textBoxViewer.Text = sr.ReadToEnd();
                }
                
            }
        }
    }
}
