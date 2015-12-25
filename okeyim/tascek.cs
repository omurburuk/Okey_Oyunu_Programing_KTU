using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace okeyim
{
    class tascek
    {
        oyuncu oyuncu;

        public tascek(oyuncu oyuncu)
        {
            this.oyuncu=oyuncu;
        }
        float esik = 0f;

        public int yararmikontrol(tas tas, oyuncu oyuncu)// sistem oyuncuları için eline yarıyor mu diye kontrol etmek
        {

            float t = kontrol1renk(tas, oyuncu);
            float f = kontrol2sira(tas, oyuncu);
            if (t > 0.5 || f > 0.5)
            {

                return 1;
            }
            return 0;
        }
        public float kontrol1renk(tas tas, oyuncu oyuncu)// oyuncunun soluna atılan taşın eline renge göre yarayıp 
        // yaramadığını kontrol eder
        {

            int h1 = 0;
            int h2 = 0;
            int h3 = 0;
            if (tas.Rengi == "yeşil")
            {
                h1 = ara(oyuncu, new tas("mavi", tas.Sayisi));
                h2 = ara(oyuncu, new tas("siyah", tas.Sayisi));
                h3 = ara(oyuncu, new tas("kırmızı", tas.Sayisi));
            }

            else if (tas.Rengi == "mavi")
            {
                h1 = ara(oyuncu, new tas("yeşil", tas.Sayisi));
                h2 = ara(oyuncu, new tas("siyah", tas.Sayisi));
                h3 = ara(oyuncu, new tas("kırmızı", tas.Sayisi));
            }
            else if (tas.Rengi == "siyah")
            {
                h1 = ara(oyuncu, new tas("yeşil", tas.Sayisi));
                h2 = ara(oyuncu, new tas("mavi", tas.Sayisi));
                h3 = ara(oyuncu, new tas("kırmızı", tas.Sayisi));
            }
            if (tas.Rengi == "kırmızı")
            {
                h1 = ara(oyuncu, new tas("yeşil", tas.Sayisi));
                h2 = ara(oyuncu, new tas("mavi", tas.Sayisi));
                h3 = ara(oyuncu, new tas("siyah", tas.Sayisi));
            }

            if (h1 == 1 & h2 == 1 & h3 == 1)
            {
                esik += 80f;
            }

            else if (h1 == 1 & h2 == 1 || h3 == 1 & h2 == 1 || h1 == 1 & h3 == 1)
            {
                esik += 0.55f;
            }
            else if (h1 == 1 || h2 == 1 || h3 == 1)
            {
                esik += 0.15f;
            }

            return esik;

        }
        public float kontrol2sira(tas tas, oyuncu oyuncu)// sol taraftaki taşın elimdeki taşlara sıralı uyumu olup  olmadığını kontrol eder
        {

            int V = ara(oyuncu, new tas(tas.Rengi, tas.Sayisi));
            int k = ara(oyuncu, new tas(tas.Rengi, tas.Sayisi + 1));
            int h = ara(oyuncu, new tas(tas.Rengi, tas.Sayisi - 1));
            int k2 = ara(oyuncu, new tas(tas.Rengi, tas.Sayisi + 2));
            int h2 = ara(oyuncu, new tas(tas.Rengi, tas.Sayisi - 2));

            if (k == 1 & h == 1 & k2 == 1 & h2 == 1 & V != 1)
            {
                esik += 0.80f;
            }

            else if (k == 1 & h == 1 & V != 0)
            {
                esik += 0.55f;
            }
            else if (k == 1 & k2 == 1)
            {
                esik += 0.55f;
            }
            else if (h == 1 & h2 == 1)
            {
                esik += 0.55f;
            }
            else if (k == 1 || h == 1)
            {
                esik += 0.15f;
            }
            return esik;
        }


        private int ara(oyuncu oyuncu, tas tas)
        {
            int donecek = 0;
            for (int i = 0; i < oyuncu.taslari.Count; i++)
            {
                if (oyuncu.taslari[i].Rengi == tas.Rengi & oyuncu.taslari[i].Sayisi == tas.Sayisi)
                {
                    donecek = 1;
                    break;
                }
            }
            return donecek;
        }



    }
}
