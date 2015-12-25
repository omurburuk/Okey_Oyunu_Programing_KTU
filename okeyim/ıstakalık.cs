using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace okeyim
{
    class ıstakalık
    {
        oyuncu oyuncu;
        public ıstakalık(oyuncu oyuncu)
        {
            this.oyuncu = oyuncu;
        }

        public int  dos(){

            oyuncu.perleri = new List<per>();
            taskontrol();
            tasrenkkontrol();
            int count=0;
            for (int i = 0; i < oyuncu.uyumdakitaslari.Count-1; i++)
            {
                count++;
            }
            return count;
        }

        public void tasrenkkontrol()// taşları renk uyumuna göre per yapar 
        {
            for (int i = 0; i < oyuncu.taslari.Count - 1; i++)
            {
                tas kontrol1;
                tas kontrol2;
                tas kontrol3;
                tas kontrol4; 
                    kontrol4 = ara(oyuncu, new tas("yeşil", oyuncu.taslari[i].Sayisi));
                    kontrol1 = ara(oyuncu, new tas("mavi", oyuncu.taslari[i].Sayisi));
                    kontrol2 = ara(oyuncu, new tas("siyah", oyuncu.taslari[i].Sayisi));
                    kontrol3 = ara(oyuncu, new tas("kırmızı", oyuncu.taslari[i].Sayisi));
                    if (kontrol1.Rengi != "o" & kontrol2.Rengi != "o" & kontrol3.Rengi != "o")
                    {
                        
                        per per = new per(oyuncu);
                        per.pers.Add(kontrol1);
                        per.pers.Add(kontrol2);
                        per.pers.Add(kontrol3);
                       // per.pers.Add(kontrol4);
                        oyuncu.perleri.Add(per);
                        if (uyumdaara(oyuncu, oyuncu.taslari[i]) == 0)
                            oyuncu.uyumdakitaslari.Add(oyuncu.taslari[i]);
                        if (uyumdaara(oyuncu, kontrol1) == 0)
                            oyuncu.uyumdakitaslari.Add(kontrol1);
                        if (uyumdaara(oyuncu, kontrol2) == 0)
                            oyuncu.uyumdakitaslari.Add(kontrol2);
                        if (uyumdaara(oyuncu, kontrol3) == 0)
                            oyuncu.uyumdakitaslari.Add(kontrol3);
                    }
                    if (kontrol1.Rengi != "o" & kontrol2.Rengi != "o" & kontrol4.Rengi != "o")
                    {
                        if (uyumdaara(oyuncu, oyuncu.taslari[i]) == 0)
                            oyuncu.uyumdakitaslari.Add(oyuncu.taslari[i]);
                        if (uyumdaara(oyuncu, kontrol1) == 0)
                            oyuncu.uyumdakitaslari.Add(kontrol1);
                        if (uyumdaara(oyuncu, kontrol2) == 0)
                            oyuncu.uyumdakitaslari.Add(kontrol2);
                        if (uyumdaara(oyuncu, kontrol4) == 0)
                            oyuncu.uyumdakitaslari.Add(kontrol4);
                    }
                    if (kontrol1.Rengi != "o" & kontrol3.Rengi != "o" & kontrol4.Rengi != "o")
                    {
                        per per = new per(oyuncu);
                        per.pers.Add(kontrol1);
                        //per.pers.Add(kontrol2);
                        per.pers.Add(kontrol3);
                        per.pers.Add(kontrol4);
                        oyuncu.perleri.Add(per);
                        if (uyumdaara(oyuncu, oyuncu.taslari[i]) == 0)
                            oyuncu.uyumdakitaslari.Add(oyuncu.taslari[i]);
                        if (uyumdaara(oyuncu, kontrol1) == 0)
                            oyuncu.uyumdakitaslari.Add(kontrol1);
                        if (uyumdaara(oyuncu, kontrol3) == 0)
                            oyuncu.uyumdakitaslari.Add(kontrol3);
                        if (uyumdaara(oyuncu, kontrol4) == 0)
                            oyuncu.uyumdakitaslari.Add(kontrol4);
                    }
                    if (kontrol2.Rengi != "o" & kontrol3.Rengi != "o" & kontrol4.Rengi != "o")
                    {
                        per per = new per(oyuncu);
                        //per.pers.Add(kontrol1);
                        per.pers.Add(kontrol2);
                        per.pers.Add(kontrol3);
                        per.pers.Add(kontrol4);
                        oyuncu.perleri.Add(per);
                        if (uyumdaara(oyuncu, oyuncu.taslari[i]) == 0)
                            oyuncu.uyumdakitaslari.Add(oyuncu.taslari[i]);
                        if (uyumdaara(oyuncu, kontrol3) == 0)
                            oyuncu.uyumdakitaslari.Add(kontrol3);
                        if (uyumdaara(oyuncu, kontrol2) == 0)
                            oyuncu.uyumdakitaslari.Add(kontrol2);
                        if (uyumdaara(oyuncu, kontrol4) == 0)
                            oyuncu.uyumdakitaslari.Add(kontrol4);
                    }
               

            }
        }
        public void taskontrol()// taşların sıralıya uyumuna göre eşik değeri verir
        {
            for (int i = 0; i < oyuncu.taslari.Count - 1; i++)
            {
                tas kontrol1;
                tas kontrol2 ;
                kontrol1 = ara(oyuncu, new tas(oyuncu.taslari[i].Rengi, oyuncu.taslari[i].Sayisi + 1));
                kontrol2 = ara(oyuncu, new tas(oyuncu.taslari[i].Rengi, oyuncu.taslari[i].Sayisi - 1));
                tas kontrol11 = ara(oyuncu, new tas(oyuncu.taslari[i].Rengi, oyuncu.taslari[i].Sayisi + 2));
                tas kontrol22 = ara(oyuncu, new tas(oyuncu.taslari[i].Rengi, oyuncu.taslari[i].Sayisi - -2));
                if (kontrol1.Rengi != "o" & kontrol2.Rengi !="o")
                {
                    if (uyumdaara(oyuncu, oyuncu.taslari[i]) == 0)
                        oyuncu.uyumdakitaslari.Add(oyuncu.taslari[i]);
                    if (uyumdaara(oyuncu, kontrol1) == 0)
                         oyuncu.uyumdakitaslari.Add(kontrol1);
                    if (uyumdaara(oyuncu, kontrol2) == 0)
                        oyuncu.uyumdakitaslari.Add(kontrol2);
                }
                else if (kontrol1.Rengi != "o" & kontrol11.Rengi != "o" )
                {
                    if (uyumdaara(oyuncu, oyuncu.taslari[i]) == 0)
                        oyuncu.uyumdakitaslari.Add(oyuncu.taslari[i]);
                    if( uyumdaara(oyuncu, kontrol1) == 0 )
                        oyuncu.uyumdakitaslari.Add(kontrol1);
                    if (uyumdaara(oyuncu, kontrol11) == 0)
                         oyuncu.uyumdakitaslari.Add(kontrol11);
                }
                else if (kontrol2.Rengi != "o" & kontrol22.Rengi != "o" )
                {
                    if (uyumdaara(oyuncu, oyuncu.taslari[i]) == 0)
                        oyuncu.uyumdakitaslari.Add(oyuncu.taslari[i]);
                    if (uyumdaara(oyuncu, kontrol2) == 0)
                    oyuncu.uyumdakitaslari.Add(kontrol2);
                    if (uyumdaara(oyuncu, kontrol2) == 0)
                    oyuncu.uyumdakitaslari.Add(kontrol22);
                }
             

            }

            string b = "";
        }


        public tas ara(oyuncu oyuncu ,tas tas){

            tas varolan = new tas("o", 61); 
            for (int i = 0; i < oyuncu.taslari.Count-1; i++)
            {
                if (oyuncu.taslari[i].Rengi == tas.Rengi & tas.Sayisi == oyuncu.taslari[i].Sayisi)
                {
                    varolan = oyuncu.taslari[i];
                }
            }
            return varolan;
        }

        public int uyumdaara(oyuncu oyuncu, tas tas)
        {

            int varolan = 0;
            for (int i = 0; i < oyuncu.uyumdakitaslari.Count - 1; i++)
            {
                if (oyuncu.uyumdakitaslari[i].Rengi == tas.Rengi & tas.Sayisi == oyuncu.uyumdakitaslari[i].Sayisi)
                {
                    varolan = 1;
                }
            }
            return varolan;
        }



        public int perdeara(per per )
        {
            int kontrol=0;
            for (int i = 0; i < oyuncu.perleri.Count-1; i++)
			{
                if (oyuncu.perleri[i] == per)
                {
                    kontrol = 1;
                }
			}
            return kontrol;
        }
    }
}
