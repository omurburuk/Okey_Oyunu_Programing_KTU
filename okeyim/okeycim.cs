using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace okeyim
{
    public partial class okeycim : Form
    {
        
        List<tas> taslar = new List<tas>();
        // ArrayList<tas> taslar = new ArrayList()<tas>;
        string[] renkdizisi = { "kırmızı", "yeşil", "mavi", "siyah" };
        public string[] isimler = { "Ayşe", "Mehmet", "Gizem", "Zeynep","Gülcan", "Kamil", "Burak", "Ömer", "Kübra", "Mustafa", "Yasemin", "Fırat", "Havva", "Gözde", "Melike", "Yiğit", "Zeyit", "Halit" };

        oyuncu ben;
        tas gosterge;
        tas okey;
        tas sahteokey1;
        tas sahteokey2;
        oyuncu sistem1;
        oyuncu sistem2;
        oyuncu sistem3 ;
        k_oyuncu sagalt = new k_oyuncu("sagkuyu", 1);
        k_oyuncu solalt = new k_oyuncu("solkuyu", 4);
        k_oyuncu sagust = new k_oyuncu("sagust", 2);
        k_oyuncu solust = new k_oyuncu("solust", 3);
        k_oyuncu ortanca = new k_oyuncu("ortanca", 3);

        public okeycim()
        {
            InitializeComponent();
        }
        konum[,] konumlar = new konum[2, 15];
        public void kisiler()
        {
            ben = new oyuncu("Ömür", 306033);
            Random r=new Random();
            int k = r.Next(0, 18);
            sistem1=new oyuncu(isimler[k], 61);
            int s = r.Next(0, 18);
            while(true){
                if (k == s)
                    s = r.Next(0, 18);
                else break;
            }
            sistem2 = new oyuncu(isimler[s], 34);
            int y = r.Next(0, 18);
            while (true)
            {
                if (k == y || s==y)
                    y = r.Next(0, 18);
                else break;
            }
            sistem3 = new oyuncu(isimler[y], 06);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    konumlar[i, j] = new konum();
                }
            }
            kisiler();
            olustur();
            dagıt();
            siralama s = new siralama(ben);
            s.bubble_sort();
            benimtaslar();
            ortataslar();
           

            label1.Text = sistem1.Adi;
            label2.Text = sistem2.Adi;
            label3.Text = sistem3.Adi;
            label4.Text = ben.Adi;

           
        }


        private void olustur()
        {

            for (int h = 0; h < 2; h++)
            {
                for (int k = 0; k < 4; k++)
                {
                    for (int i = 1; i <= 13; i++)
                    {
                        tas tas = new tas(renkdizisi[k], i);
                        taslar.Add(tas);
                       tas.MouseDown += new MouseEventHandler(_MouseDown);
                        tas.MouseMove += new MouseEventHandler(_MouseMove);
                        tas.MouseUp += new MouseEventHandler(_MouseUp);

                    }
                }
            }

        }
        /// <summary>
        /// Taş At
        /// </summary>
        /// <param name="tas"></param>
        
        int[] cikanlar = new int[104];
        private void dagıt()
        {
            int kontrol = 1;
            int s = 1;

            while (s != 103)
            {
                Random r = new Random();//üret
                int cikacak = r.Next(1, 103);

                //ara bak var mı içinde
                for (int i = 0; i < cikanlar.Length; i++)
                {
                    if (cikanlar[i] == cikacak)
                    {
                        kontrol = 0; // varsa bırak tekrar üret
                        continue;
                    }
                }
                if (kontrol == 1)
                {
                    // yoksa ekle tutulan taşı birine şutla
                    if (s <= 15)
                    {
                        // Oyuncu taşı
                        
                        ben.taslari.Add(taslar[cikacak]);


                    }
                    else if (15 < s & s <= 29)
                    {
                        sistem1.taslari.Add(taslar[cikacak]);
                        Console.Write("sistem1 taşi : " + taslar[cikacak]);
                    }
                    else if (29 < s & s <= 43)
                    {      // taşlari dağıt
                        sistem2.taslari.Add(taslar[cikacak]);
                        Console.Write("sistem2 taşi : " + taslar[cikacak]);
                    }
                    else if (43 < s & s <= 57)
                    {
                        sistem3.taslari.Add(taslar[cikacak]);
                        Console.Write("sistem3 taşi : " + taslar[cikacak]);
                    }
                    else
                    {

                        ortanca.taslari.Add(taslar[cikacak]);
                        Console.Write("yer taşi : " + taslar[cikacak]);
                    }
                    cikanlar[s] = cikacak;

                    s++;
                    kontrol = 1;
                }
                else kontrol = 1;

            }

            gosterge = ortanca.taslari[0];
            ortanca.taslari.Remove(ortanca.taslari[0]);
            okey = new tas(gosterge.Rengi, gosterge.Sayisi + 1);
            gkuyuekle();
            sirabende = true;
            tascekebilir = false;
            string fs = "bakalım";
        }

        int orta_x = 450, orta_y = 180;
        int sol_x = 0, sol_y = -300;
        int sag_x = 0, sag_y = -300;
        int solu_x = 0, solu_y = -300;
        int sagu_x = 0, sagu_y = -300;
   
        public void benimtaslar()
        {
            int ı_x = 170, ı_y = 340;
            for (int i = 0; i < ben.taslari.Count; i++)
            {

                if (ben.taslari[i].Rengi== gosterge.Rengi & ben.taslari[i].Sayisi==gosterge.Sayisi)
                {
                    MessageBox.Show("Gösterge Yaptınız");
                }
                if (ben.taslari[i].Name == okey.Name)
                {
                    MessageBox.Show("Okeyiniz  Var");
                }

                ben.taslari[i].Left = ı_x;
                konumlar[0, i].KonumTas = ben.taslari[i];
                ı_x += 37;

                ben.taslari[i].Top = ı_y;
                oyunpaneli.Controls.Add(ben.taslari[i]);//taş panellerini üret ve ana panele ekle ( mouse eventleri panellere oluştururken eklenir ).
             
            }

         
        }
        // orta taşlar içinde aynı panel oluşturma işlemi yapıldı bunlar  için bir sınıf yapmak gerekli
        public void ortataslar()
        {
            label5.Text = Convert.ToString(ortanca.taslari.Count);
            for (int i = ortanca.taslari.Count-1; i >0; i--)
            {

                ortanca.taslari[i].tasGosterilecekMi = false;
                ortanca.taslari[i].Left = orta_x;



                ortanca.taslari[i].Top = orta_y;
                oyunpaneli.Controls.Add(ortanca.taslari[i]);
             


            }
        }
        public void solkuyuekle()
        {

            for (int i = solust.taslari.Count - 1; i >= 0; i--)
            {

              
                solust.taslari[i].Left = 260;


                solust.taslari[i].Top = 80;
                oyunpaneli.Controls.Add(solust.taslari[i]);
               


            }
        }
 
        public void sagustkuyutasekle()
        {

            for (int i = sagust.taslari.Count - 1; i >= 0; i--)
            {
                sagust.taslari[i].tasGosterilecekMi = true;
                sagust.taslari[i].Left = 600;


                sagust.taslari[i].Top = 80;
                oyunpaneli.Controls.Add(sagust.taslari[i]);
              


            }
        }

        public void solaltkuyutasekle()
        {

            for (int i = solalt.taslari.Count - 1; i >=0; i--)
            {

                solalt.taslari[i].Left = 260;

                 solalt.taslari[i].Top = 250;
                 oyunpaneli.Controls.Add(solalt.taslari[i]);
                


            }
        }


        public void sagaltkuyuekle()
        {

            for (int i = sagalt.taslari.Count - 1; i >=0; i--)
            {
                sagalt.taslari[i].Left = 600;

                sagalt.taslari[i].Top = 250;
                oyunpaneli.Controls.Add(sagalt.taslari[i]);
                


            }
        }


        oyuncu oyuncu;
        k_oyuncu koyuncu;
        k_oyuncu koyuncuonce;
        public void threadolus()
        {
            oyuncu = sistem1;
            koyuncu = sagust;
            koyuncuonce = sagalt;
            tasoyna();
          
            oyuncu = sistem2;
            koyuncu = solust;
            koyuncuonce = sagust;
            tasoyna(); 
            oyuncu = sistem3;
            koyuncu = solalt;
            koyuncuonce = solust;
            tasoyna();
            sirabende = true;
            tascekebilir = true;
          
        }
        bool yarıyormu = false;
      
        public  void tasoyna()
        {
           kontroller k = new kontroller(oyuncu);
           tascek t = new tascek(oyuncu);
            tas tas;
            int h = 0;
            if (koyuncuonce.taslari.Count != 0)
            {
                tas = koyuncuonce.taslari[koyuncuonce.taslari.Count-1];
                
                h = t.yararmikontrol(tas, oyuncu);
                if (h == 0)
                {
                    
                    if (ortanca.taslari.Count == 0)
                    {
                        this.Close();
                        MessageBox.Show("Ortanın Taşları Bitti");
                        this.Close();

                       
                    }
                    else
                    {
                        oyuncu.tascek(ortanca.taslari[0], ortanca, oyuncu);
                        for (int i = 0; i < oyuncu.taslari.Count - 1; i++)
                        {
                            oyuncu.taslari[i].esik = 0;
                        }
                        if (oyuncu == sistem1)
                        {
                            while (ortanca.taslari[0].Left < 600)
                                ortanca.taslari[0].Left += 2;
                        }
                        if (oyuncu == sistem2)
                        {
                            while (ortanca.taslari[0].Top > 75)
                                ortanca.taslari[0].Top -= 2;
                        }
                        if (oyuncu == sistem3)
                        {
                            while (ortanca.taslari[0].Left > 300)
                                ortanca.taslari[0].Left -= 2;
                        }


                        ıstakalık ı = new ıstakalık(oyuncu);
                        int hsd= ı.dos();

                        int sad =  hsd;
                        ortanca.taslari[0].tasGosterilecekMi = true;
                        oyunpaneli.Controls.Remove(ortanca.taslari[0]);
                        ortataslar();

                       
                        k.dusunenoyuncu(oyuncu);
                        bitmekontrolu bt = new bitmekontrolu(oyuncu);
                        Boolean bittinmi = bt.bitebilirmikontrol();
                        if (bittinmi == true)
                        {
                            Form3 f = new Form3();
                            MessageBox.Show(oyuncu.Adi + " " + oyuncu.Numara + " elini bitirdi");

                            f.Show();
                            this.Close();
                        }
                    }
                    
                }
            }
            if (h != 0)
            {
                oyuncu.tascek(koyuncuonce.taslari[koyuncuonce.taslari.Count - 1], koyuncu, oyuncu);
                 
                k.dusunenoyuncu(oyuncu);
                bitmekontrolu bt = new bitmekontrolu(oyuncu);
                Boolean bittinmi = bt.bitebilirmikontrol();
                if (bittinmi == true)
                {
                    Form3 f = new Form3();
                    MessageBox.Show(oyuncu.Adi + " " + oyuncu.Numara + " elini bitirdi");

                    f.Show();
                    this.Close();
                }

            }
           
          
         
          tasat tasat = new tasat(oyuncu);
            tas  EnazYarayanTas = tasat.enazyarayantas();
           oyuncu.tasat(EnazYarayanTas,oyuncu,koyuncu);
         
           
        }
         
      

        tas secilenTas = null;

        private void _MouseDown(object sender, MouseEventArgs e)
        {
            tas t = (tas)sender;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (konumlar[i,j].KonumTas !=null)
                    {
                        if (konumlar[i,j].KonumTas.Name ==t.Name)
                        {
                            secilenTas = konumlar[i, j].KonumTas;
                            konumlar[i, j].KonumTas = null;
                            break;
                        }
                    }
                }
            }
            kPanel = (Panel)sender;
            konum = e.Location;
            surukleme = true;
            kPanel.Cursor = Cursors.SizeAll;
         //   MessageBox.Show("" + t.Sayisi + "    renk " + t.Rengi);
            // mousedown eventi 
        }


        public ArrayList panels = new ArrayList();
        Panel kPanel;
        Point konum;
        Boolean surukleme = false;

        Boolean sirabende = true;
        Boolean tascekebilir = false;
        public int okeyinsayisi = 0;
        public string okeyinrengi = "kırmızı";
        int kosacakmi = 0;
        private void _MouseMove(object sender, MouseEventArgs e)
        {
            if (ortanca.taslari.Count == 0)
            {
                MessageBox.Show("Ortanın Taşları Bitti");
                this.Close();
            }
            if (surukleme)
            {
                 tas t = (tas)sender;
            t.Left = e.X + t.Left - (konum.X);
            t.Top = e.Y + t.Top - (konum.Y);

            if (sirabende = true & tascekebilir == true & t.Left > 550 & t.Top < 300)
            {
                MessageBox.Show("Taş Çekmelisin");
                t.Left = 550;
                t.Top = 390;

            }
            if (sirabende = true & tascekebilir == false & t.Left > 600 & t.Top < 290)
            {
                ben.tasat(t, ben, sagalt);
                surukleme = false;
                sirabende = false;
                tascekebilir = false;
                t.Left = 600;
                t.Top = 250;
                kosacakmi = 1;
               
            }
            else if (sirabende = true & tascekebilir == true & t==ortanca.taslari[ortanca.taslari.Count-1])
            {
                ortanca.taslari[ortanca.taslari.Count-1].tasGosterilecekMi = true;
                ben.tascek(t, ortanca, ben);
               // t.tasGosterilecekMi = true;
                tascekebilir = false;
                sirabende = true;
            }
            else if  (sirabende = true & tascekebilir == true )
            {
                if (solalt.taslari.Count != 0)
                {
                    if (t.Name == solalt.taslari[solalt.taslari.Count - 1].Name)
                    {
                        ben.tascek(t, solalt, ben);
                        tascekebilir = false;
                    }
                }
               

            }
            }
           
           
            label5.Text = Convert.ToString(ortanca.taslari.Count);
            
        }
        tas tas;
      
        private void _MouseUp(object sender, MouseEventArgs e)
        {

            if (kosacakmi == 1)
            {
                kostur();
                kosacakmi = 0;
            }
            tas[,] liste = new tas[14, 14];
            int satır = 0, sutun = 0;


            tas t = (tas)sender;
            int x = 170;
            int y = 340;
            Rectangle r1 = new Rectangle(t.Left, t.Top, 35, 50);
            for (int i = 0; i < 2; i++)
            {

                for (int j = 0; j < 15; j++)
                {
                    Rectangle r2 = new Rectangle(x, y, 35, 50);

                    if (r1.IntersectsWith(r2))
                    {

                        konumlar[i, j].KonumTas = t;
                        t.Left = x;
                        t.Top = y;
                        //  MessageBox.Show("x :"+x+" y :"+y +"\n i :"+i +" j :"+j);
                        break;
                    }
                    x += 37;

                }
                x = 170;
                y += 55;
            }
            if (t.Left < 50 && t.Top < 50)
            {
                ben.uyumlutassayisi=0;
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        if (konumlar[i, j].KonumTas != null)
                        {
                            liste[satır, sutun] = konumlar[i, j].KonumTas;
                            sutun++;
                        }
                        else
                        {
                            if (sutun != 0)
                            {
                                satır++;
                                sutun = 0;
                            }
                        }
                    }
                }

                int [] dizi = new int [14];
                int yesler = 0;
                int kontrol = 0;
                int perler=0;
                for (int i = 0; i < 14; i++)
                {
                    List<tas> per = new List<tas>();
                    for (int j = 0; j < 14; j++)
                    {
                        if (liste[i, j] != null)
                        {
                            
                            per.Add(liste[i, j]);
                         //   MessageBox.Show("liste " + i + liste[i, j].Name);
                        }
                    }
                    perler++;
                    kontroller k = new kontroller(ben);
                    int bak1 = k.sirakontrol(per);
                    int bak2 = k.renkkontrol(per);
                    if (bak1 == 1 || bak2 == 1 )
                    {
                        kontrol = 1;
                    }
                    else
                    {
                        kontrol = -1;
                        break;
                    }
                }
                
               
                if (kontrol == -1)
                {
                    MessageBox.Show("Eliniz bitik Değil");
                    t.Left = 230;
                    t.Top = 350;
                }
                else
                {
                    kontroller ek = new kontroller(ben);
                    ek.Bitir();
                }
            }

          


          
            surukleme = false;//bırakma
            kPanel.Cursor = Cursors.SizeAll;
        }


        private void button3_Click(object sender, EventArgs e)
        {                                                   
            okeyim.okeycim.ActiveForm.Close();
        }

        private void oyunpaneli_Paint(object sender, PaintEventArgs e)
        {

        }
        public void kostur(){ 
            threadolus();
            sagustkuyutasekle();
            solkuyuekle();
            solaltkuyutasekle();
            
            sagaltkuyuekle();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            kostur();
            
        }
    
        public void gkuyuekle()
        {

                gosterge.Left = 380;

                gosterge.Top = 180;
                oyunpaneli.Controls.Add(gosterge);
              

            
        }

            }


        }
