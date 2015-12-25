using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace okeyim
{
    class siralama
    {
        oyuncu oyuncu;
        public siralama(oyuncu oyuncu)
        {
            this.oyuncu = oyuncu;
        }
        public void bubble_sort()
        {
            for (int i = 0; i < oyuncu.taslari.Count - 1; i++)
            {
                for (int j = 1; j < oyuncu.taslari.Count - i; j++)
                {
                    if (oyuncu.taslari[j].Sayisi < oyuncu.taslari[j - 1].Sayisi)
                    {
                        tas gecici = oyuncu.taslari[j - 1];
                        oyuncu.taslari[j - 1] = oyuncu.taslari[j];
                        oyuncu.taslari[j] = gecici;
                    }
                }
            }
        }
    }
}
