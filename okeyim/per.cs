using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace okeyim
{
    class per
    {
        oyuncu oyuncu;
        public List<tas> pers;
        public per(oyuncu oyuncu)
        {
           
            this.oyuncu = oyuncu;
            pers = new List<tas>();
        }

        public void perolustur()
        {
            
        }
        public void pereekle(tas tas)
        {
            pers.Add(tas);
        }

    }
}
