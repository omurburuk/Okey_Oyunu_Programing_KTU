using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace okeyim
{
    public partial class Form3 : Form
    {
        oyuncu oyuncu;
        public Form3()
        {
           
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        public void oyuncubitir(){
           
            MessageBox.Show(oyuncu.Adi + " elini bitirdi");
        }
    }
}
