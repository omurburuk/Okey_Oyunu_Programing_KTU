using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace okeyim
{
    class perler
    {
        oyuncu oyuncu;
        List<per> perleri;
        public perler(oyuncu oyuncu )
        {
            perleri = new List<per>();
            this.oyuncu = oyuncu;
        }

        public void perekle(per per)
        {
            perleri.Add(per);
        }
    }
}
