using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace okeyim
{
    class k_oyuncu
    {
        public k_oyuncu(string adi, int numara)// atış taşların bulunduğu bölmeler
        {
            this._adi = adi;
            this._numara = numara;
        }
         string _adi;
        int _numara;
        public int Numara
        {
            set
            {
                _numara = value;
            }
            get
            {
                return _numara;
            }
        }
        public string Adi
        {
            set
            {
                _adi = value;
            }
            get
            {
                return _adi;
            }
        }
        public List<tas> taslari = new List<tas>();



    }
}
