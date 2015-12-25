using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace okeyim
{
    class tasat
    {
        oyuncu oyuncu;
        public tasat(oyuncu oyuncu)
        {
            this.oyuncu = oyuncu;
        }


        public tas enazyarayantas()
        {
            tas tas=oyuncu.taslari[0];
            float esik=10f;
            for (int i = 0; i < oyuncu.taslari.Count-1; i++)
            {
                if(oyuncu.taslari[i].esik<esik & uyumdantas(oyuncu.taslari[i])==0){
                    tas = oyuncu.taslari[i];
                    esik = oyuncu.taslari[i].esik;
                }
            }

            return tas;

        }

        public int uyumdantas(tas tas)
        {
            int kontrol = 0;
            for (int i = 0; i < oyuncu.uyumdakitaslari.Count; i++)
            {
                if (oyuncu.uyumdakitaslari[i].Rengi == tas.Rengi & oyuncu.uyumdakitaslari[i].Sayisi == tas.Sayisi)
                {
                    kontrol = 1;
                }
            }
            return kontrol;
        }
    }
}
