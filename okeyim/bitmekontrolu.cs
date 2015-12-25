using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace okeyim
{
    class bitmekontrolu
    {
        oyuncu oyuncu;
        public bitmekontrolu(oyuncu oyuncu)
        {
            this.oyuncu = oyuncu;
        }
        public Boolean bitebilirmikontrol()// el bitik mi kontrolü
        {
            int count = 0;
            for (int i = 0; i < oyuncu.taslari.Count - 1; i++)
            {

                if (oyuncu.taslari[i].esik >= 0.54)
                {
                    count += 1;
                }
            }
            if (count == 14)
                return true;
            else
            {


              

                return false;
            }
        }

    }
}
