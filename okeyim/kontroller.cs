using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace okeyim
{
    class kontroller
    {
        int deger;
        public List<tas> _tas;
        oyuncu oyuncu;
        public  kontroller(oyuncu oyuncu){
            this.oyuncu=oyuncu;
          
        }
        List<tas> uyumlutasdizisi;
        List<tas> uyumsuztasdizisi;
        int uyumlusayisi = 0;
        public void grupolarakata(List<tas> tasgrubu)// taşların grubunu belirle
        {
            while (tasgrubu[i] != null)
            {
                uyumlutasdizisi.Add(tasgrubu[i]);
               
            } 
            
        }
     
       public  void Bitir(){
           Form2 f = new Form2();
           f.Show();
           
       }

        int i = 0;
        int sonuc = 0;

     
       
        private int ara(oyuncu oyuncu, tas tas)
        {
            int donecek=0;
           for (int i =0;i<oyuncu.taslari.Count;i++){
               if (oyuncu.taslari[i].Rengi == tas.Rengi & oyuncu.taslari[i].Sayisi == tas.Sayisi  )
               {
                   donecek = 1;
                   break;
               }
           }
           return donecek;
        }



        public void  dusunenoyuncu( oyuncu oyuncu ){

            for (int i = 0; i < oyuncu.taslari.Count-1; i++)
            {
                oyuncu.taslari[i].esik = 0f;
            }
            tasrenkkontrol(oyuncu);
            taskontrol(oyuncu);

            bitmekontrolu bk = new bitmekontrolu(oyuncu);
            bool  bittimi=bk.bitebilirmikontrol();

            if (bittimi == true)
            {
                MessageBox.Show(oyuncu.Adi +  " elini bitirdi");
                Form3 f = new Form3();
                f.Show();
            }

        }
  float esik = 0;
     
        /// <summary> problem
        ///  oyuncu nesnesinin taşlarının, oyuncu sınıfını değişken olarak alan kontroller sınıfında oyun kurallarına uygun hale olup olmadığını sıra kontrol methoduna 
        ///  önce taş nesnesinin varlıgının sağlanması sonra renk uyumluluğu ile bir üst sayıda  taş ve bir alt taşın varlık kontrolü ile sağlanan taşnesnelerinin per durumuna uyumlu 
        ///  Listesine içerisinde taş nesnesinin varlığını kontrol edilip eğer yoksa eklendikten sonra 
        /// </summary>
        public tas ElimeEnAzYarayanTas(oyuncu oyuncu)
        {
            float Esik = 10f;
            tas EnAzYarayanTas = new tas("bordo", 61); ;
            for (int i = 0; i < oyuncu.taslari.Count-1; i++)
            {
                if (oyuncu.taslari[i].esik < Esik)
                {
                    Esik = oyuncu.taslari[i].esik;
                    EnAzYarayanTas = oyuncu.taslari[i];
                }
            }
            return EnAzYarayanTas;
        }
        float dusunce_esik = 0; 
        public  void dusun(oyuncu oyuncu)
        {
            rengeGoreDusun(oyuncu);
            siraliyagoreDusun(oyuncu);

        }

        // oyuncunun sol kuyusuna atılan taşın 
        public void  siraliyagoreDusun( oyuncu oyuncu)// taşların sıra uyumluluğuna göre eşik değeri verir
        {
            for (int i = 0; i < oyuncu.taslari.Count-1; i++)
            {
                int h =ara(oyuncu, new tas(oyuncu.taslari[i].Rengi, oyuncu.taslari[i].Sayisi + 1));

                int k = ara(oyuncu, new tas(oyuncu.taslari[i].Rengi, oyuncu.taslari[i].Sayisi -1));

                if (h == 1)
                    oyuncu.taslari[i].esik += 0.2f;
                if (k == 1)
                    oyuncu.taslari[i].esik += 0.2f;
            }
        
        }
        public float rengeGoreDusun(oyuncu oyuncu)// taşların sıralı olup olmadığını kontrol eder
        {
            for (int i = 0; i < oyuncu.taslari.Count - 1; i++)
            {
                oyuncu.taslari[i].esik = 0f;
                int h1=0;
                int h2 = 0;
                int h3 = 0;
                if (oyuncu.taslari[i].Rengi == "yeşil")
                {
                   h1 = ara(oyuncu, new tas("mavi", oyuncu.taslari[i].Sayisi ));
                   h2 = ara(oyuncu, new tas("siyah", oyuncu.taslari[i].Sayisi ));
                   h3 = ara(oyuncu, new tas("kırmızı", oyuncu.taslari[i].Sayisi ));
                }
              
                if (oyuncu.taslari[i].Rengi == "mavi")
                {
                    h1 = ara(oyuncu, new tas("yeşil", oyuncu.taslari[i].Sayisi));
                    h2 = ara(oyuncu, new tas("siyah", oyuncu.taslari[i].Sayisi));
                    h3 = ara(oyuncu, new tas("kırmızı", oyuncu.taslari[i].Sayisi));
                }
                if (oyuncu.taslari[i].Rengi == "siyah")
                {
                    h1 = ara(oyuncu, new tas("yeşil", oyuncu.taslari[i].Sayisi));
                    h2 = ara(oyuncu, new tas("mavi", oyuncu.taslari[i].Sayisi));
                    h3 = ara(oyuncu, new tas("kırmızı", oyuncu.taslari[i].Sayisi));
                }
                if (oyuncu.taslari[i].Rengi == "kırmızı")
                {
                    h1 = ara(oyuncu, new tas("yeşil", oyuncu.taslari[i].Sayisi));
                    h2 = ara(oyuncu, new tas("mavi", oyuncu.taslari[i].Sayisi));
                    h3 = ara(oyuncu, new tas("siyah", oyuncu.taslari[i].Sayisi));
                }
                if (h1 == 1)
                    dusunce_esik += 0.2f;
                if (h2 == 1)
                    dusunce_esik += 0.2f;
                if (h3 == 1)
                    dusunce_esik += 0.2f;
            }
            return dusunce_esik;
        }
     /*   public float renkli(oyuncu oyuncu)// taşların sıralı olup olmadığını kontrol eder
        {
           
            for (int i = 0; i < oyuncu.taslari.Count-1; i++)
            {
                if (i < 13)
                {
                    if (oyuncu.taslari[i].Sayisi == oyuncu.taslari[i + 1].Sayisi & oyuncu.taslari[i].Sayisi == oyuncu.taslari[i + 2].Sayisi & oyuncu.taslari[i].Rengi != oyuncu.taslari[i + 1].Rengi & oyuncu.taslari[i].Rengi == oyuncu.taslari[i + 2].Rengi)
                    {
                      
                        List<tas> t = new List<tas>();
                        int k=ara(oyuncu, oyuncu.taslari[i]);
                        if( k==0)oyuncu.uyumdakitaslari.Add(oyuncu.taslari[i]);
                        int y = ara(oyuncu, oyuncu.taslari[i+1]);
                        if (y == 0) oyuncu.uyumdakitaslari.Add(oyuncu.taslari[i + 1]);
                        int z = ara(oyuncu, oyuncu.taslari[i+1]);
                        if (z == 0) oyuncu.uyumdakitaslari.Add(oyuncu.taslari[i + 2]);
                     
                        oyuncu.persayisi++;
                        oyuncu.uyumlutassayisi += 3;
                      
                    }
                }

            }
            return dusunce_esik;
        }*/

        public int renkkontrol(List<tas> taslar) // benim elim için renk peri kontrolü
        {
            string[] renkler=new string[4];
            int bak = 1;
            int count=0;
            if (taslar.Count >= 3 & taslar.Count <= 4)
            {

                for (int i = 0; i < taslar.Count - 1; i++)
                {


                    if (taslar[i].Sayisi == taslar[i + 1].Sayisi & bak == 1 & renkara(renkler, taslar[i].Rengi) == 0)
                    {
                        renkler[count] = taslar[i].Rengi;
                        bak = 1;
                    }
                    else
                    {
                        bak = 2;
                        break;
                    }
                }

            }
            else bak = 2;
            return bak;
        }

        public int  renkara( string[] renkler,string renk) // renk peri için renk arama
           { int varmidu=0;

            for (int i = 0; i < renkler.Length; i++)
            {
                if (renkler[i] == renk)
                {
                    varmidu = 1;
                    break;
                }
            }
            return varmidu;
        }

        public int sirakontrol(List<tas> taslar)// benim elim için sıra per kontrolü
        {
            int bak=1;
            if (taslar.Count >= 3)
            {
                for (int i = 0; i < taslar.Count - 1; i++)
                {
                    if (taslar[i].Sayisi + 1 == taslar[i + 1].Sayisi & taslar[i].Rengi == taslar[i].Rengi & bak == 1)
                    {
                        bak = 1;

                    }
                    else
                    {
                        bak = 2;
                        break;
                    }
                }
            }
            else bak = 2;
            return bak;
        }
       
        public void tasrenkkontrol(oyuncu oyuncu)// taşlara renk uyumuna göre eşik değeri verir
        {
            for (int i = 0; i < oyuncu.taslari.Count - 1; i++)
            {
                int kontrol = 0;
                int kontrol2 = 0;
                int kontrol3 = 0;
                if (oyuncu.taslari[i].Rengi == "yeşil")
                {
                    kontrol = ara(oyuncu, new tas("mavi", oyuncu.taslari[i].Sayisi));
                    kontrol2 = ara(oyuncu, new tas("siyah", oyuncu.taslari[i].Sayisi));
                    kontrol3 = ara(oyuncu, new tas("kırmızı", oyuncu.taslari[i].Sayisi));
                    if (kontrol == 1 & kontrol2 == 1 )
                    {
                        oyuncu.taslari[i].esik += 0.55f;
                    }
                    if (kontrol2 == 1 & kontrol3 == 1 )
                    {
                        oyuncu.taslari[i].esik += 0.55f;
                    }
                    if (kontrol == 1 & kontrol3 == 1)
                    {
                        oyuncu.taslari[i].esik += 0.55f;
                    }
                    else if (kontrol == 1 || kontrol2 == 1 || kontrol3 == 1)
                    {
                        oyuncu.taslari[i].esik += 0.15f;

                    }
               
                }
                else if (oyuncu.taslari[i].Rengi == "mavi")
                {
                    kontrol = ara(oyuncu, new tas("yeşil", oyuncu.taslari[i].Sayisi));
                    kontrol2 = ara(oyuncu, new tas("siyah", oyuncu.taslari[i].Sayisi));
                    kontrol3 = ara(oyuncu, new tas("kırmızı", oyuncu.taslari[i].Sayisi));

                    if (kontrol == 1 & kontrol2 == 1)
                    {
                        oyuncu.taslari[i].esik += 0.55f;
                    }
                    if (kontrol2 == 1 & kontrol3 == 1)
                    {
                        oyuncu.taslari[i].esik += 0.55f;
                    }
                    if (kontrol == 1 & kontrol3 == 1)
                    {
                        oyuncu.taslari[i].esik += 0.55f;
                    }
                    else if (kontrol == 1 || kontrol2 == 1 || kontrol3 == 1)
                    {
                        oyuncu.taslari[i].esik += 0.15f;

                    }
                    else oyuncu.taslari[i].esik = 0;


                }
                if (oyuncu.taslari[i].Rengi == "siyah")
                {
                    kontrol = ara(oyuncu, new tas("mavi", oyuncu.taslari[i].Sayisi));
                    kontrol2 = ara(oyuncu, new tas("yeşil", oyuncu.taslari[i].Sayisi));
                    kontrol3 = ara(oyuncu, new tas("kırmızı", oyuncu.taslari[i].Sayisi));
                    if (kontrol == 1 & kontrol2 == 1)
                    {
                        oyuncu.taslari[i].esik += 0.55f;
                    }
                    if (kontrol2 == 1 & kontrol3 == 1)
                    {
                        oyuncu.taslari[i].esik += 0.55f;
                    }
                    if (kontrol == 1 & kontrol3 == 1)
                    {
                        oyuncu.taslari[i].esik += 0.55f;
                    }
                    else if (kontrol == 1 || kontrol2 == 1 || kontrol3 == 1)
                    {
                        oyuncu.taslari[i].esik += 0.15f;

                    }
                    else oyuncu.taslari[i].esik = 0;
                }
                if (oyuncu.taslari[i].Rengi == "kırmızı")
                {
                    kontrol = ara(oyuncu, new tas("yeşil", oyuncu.taslari[i].Sayisi));
                    kontrol2 = ara(oyuncu, new tas("mavi", oyuncu.taslari[i].Sayisi));
                    kontrol3 = ara(oyuncu, new tas("siyah", oyuncu.taslari[i].Sayisi));
                    if (kontrol == 1 & kontrol2 == 1)
                    {
                        oyuncu.taslari[i].esik += 0.55f;
                    }
                    if (kontrol2 == 1 & kontrol3 == 1)
                    {
                        oyuncu.taslari[i].esik += 0.55f;
                    }
                    if (kontrol == 1 & kontrol3 == 1)
                    {
                        oyuncu.taslari[i].esik += 0.55f;
                    }
                    else if (kontrol == 1 || kontrol2 == 1 || kontrol3 == 1)
                    {
                        oyuncu.taslari[i].esik += 0.15f;

                    }
                    else oyuncu.taslari[i].esik = 0;
                }
                
            }
        }
        public void taskontrol(oyuncu oyuncu)// taşların sıralıya uyumuna göre eşik değeri verir
        {
            for (int i = 0; i < oyuncu.taslari.Count - 1; i++)
            {
                int kontrol1 = 0;
                int kontrol2 = 0;
                kontrol1 = ara(oyuncu, new tas(oyuncu.taslari[i].Rengi, oyuncu.taslari[i].Sayisi + 1));
                kontrol2 = ara(oyuncu, new tas(oyuncu.taslari[i].Rengi, oyuncu.taslari[i].Sayisi - 1));
               int  kontrol11 = ara(oyuncu, new tas(oyuncu.taslari[i].Rengi, oyuncu.taslari[i].Sayisi + 2));
                int kontrol22 = ara(oyuncu, new tas(oyuncu.taslari[i].Rengi, oyuncu.taslari[i].Sayisi - -2));
                if (kontrol1 == 1 & kontrol2 == 1)
                {
                    oyuncu.taslari[i].esik += 0.55f;
                }
                else if(kontrol1==1 & kontrol11==1)
                    oyuncu.taslari[i].esik += 0.55f;
                else if (kontrol2 == 1 & kontrol2 == 1)
                    oyuncu.taslari[i].esik += 0.55f;
                else if(kontrol1==1 || kontrol2==1)
                    oyuncu.taslari[i].esik += 0.15f;
                
            }

            string b = "";
        }


        public void uyumsuzekle(oyuncu oyuncu)//
        {
           
                for (int i = 0; i < oyuncu.taslari.Count - 1; i++)
                {
                    int kontrol = 0; 
                    if (oyuncu.uyumdakitaslari.Count != 0)
                     {
                    for (int ji = 0; ji < oyuncu.uyumdakitaslari.Count - 1; ji++)
                    {
                        
                        if (oyuncu.uyumdakitaslari[ji].Sayisi==oyuncu.taslari[i].Sayisi & oyuncu.uyumdakitaslari[ji].Rengi==oyuncu.taslari[i].Rengi)
                        {
                            kontrol = 1;
                        }
                    }
                    if (kontrol == 0)
                    {
                        int baktıkuyumsuzdamı = uyumsuzdaara(oyuncu, oyuncu.taslari[i]);
                        if (baktıkuyumsuzdamı == 0)
                        {
                            oyuncu.uyumsuztaslari.Add(oyuncu.taslari[i]);
                        }
                    }
                    
                }
            }
        }





        public int uyumdaara(oyuncu oyuncu,tas tas)
        {
            int bak=0;

            if (oyuncu.uyumdakitaslari.Count != 0)
            {
                for (int i = 0; i < oyuncu.uyumdakitaslari.Count - 1; i++)
                {
                    if (oyuncu.uyumdakitaslari[i].Rengi == tas.Rengi & oyuncu.uyumdakitaslari[i].Sayisi==tas.Sayisi)
                    {
                        bak = 1;
                    }
                }
            }
            return bak;
        }
        public int uyumsuzdaara(oyuncu oyuncu, tas tas)
        {
            int bak = 0;

            if (oyuncu.uyumsuztaslari.Count != 0)
            {
                for (int i = 0; i < oyuncu.uyumsuztaslari.Count - 1; i++)
                {
                    if (oyuncu.uyumsuztaslari[i].Rengi == tas.Rengi & oyuncu.uyumdakitaslari[i].Sayisi==tas.Sayisi)
                    {
                        bak = 1;
                    }
                }
            }
            return bak;
        }

   
        
    }
}
