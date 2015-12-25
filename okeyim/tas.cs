using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace okeyim
{
    class tas : Panel
    {
        int _sayisi;
        string _rengi;
        public Panel p;
       public  bool tasGosterilecekMi;
       

        public string Rengi
        {
            set
            {
                _rengi = value;
            }
            get
            {
                return _rengi;
            }
        }
        public int Sayisi
        {
            set
            {
                _sayisi = value;
            }
            get
            {
                return _sayisi;
            }
        }

        public bool TasGosterilecekMi
        {
            get
            {
                return tasGosterilecekMi;
            }
            set
            {
                tasGosterilecekMi = value;
            }
        }
        public tas(string rengi, int sayisi)
        {
           
            this.BackColor = Color.White;
            this._rengi = rengi;
            this._sayisi = sayisi;
            this.Paint += new PaintEventHandler(tas_Paint);
            this.Name = rengi + sayisi;
            this.Width = 35;
            this.Height = 50; 
            this.tasGosterilecekMi = true;
        }

        void tas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
       
            if (tasGosterilecekMi)
            {
                FontFamily fontFamily = new FontFamily("Times New Roman");
                Font font = new Font(fontFamily, 25, FontStyle.Regular, GraphicsUnit.Pixel);
                
                if (Rengi == "kırmızı")
                {
                    g.DrawString(Convert.ToString(Sayisi), font, Brushes.Red, ClientRectangle);
                         g.DrawString("o", font, Brushes.Red, new Point(15,25));
                }
                else if (Rengi =="yeşil")
                {
                    g.DrawString(Convert.ToString(Sayisi), font, Brushes.Green, ClientRectangle);
                    g.DrawString("o", font, Brushes.Green, new Point(15, 25));
                }
                else if (Rengi == "mavi")
                {
                    g.DrawString(Convert.ToString(Sayisi), font, Brushes.Blue, ClientRectangle);
                    g.DrawString("o", font, Brushes.Blue, new Point(15, 25));

                }
                else
                {
                    g.DrawString(Convert.ToString(Sayisi), font, Brushes.Black, ClientRectangle);
                    g.DrawString("o", font, Brushes.Black, new Point(15, 25));
                }
                
            }
        }

        public float esik;
    }


     

}
