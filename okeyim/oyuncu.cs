using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace okeyim
{
    class oyuncu
    {
        public int uyumlutassayisi=0;
        public int persayisi = 0;
        
       public  List<per> perleri = new List<per>();
        public int u_ts
        {
            set
            {
                uyumlutassayisi = value;
            }
            get
            {
                return uyumlutassayisi;
            }
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
        public oyuncu(string adi, int numara)
        {
            this._adi = adi;
            this._numara = numara;
            
        }
        

        public List<tas> taslari = new List<tas>();// oyuncuların taşları burada tutulur
        public List<tas> uyumdakitaslari = new List<tas>();
        
        public List<tas> uyumsuztaslari = new List<tas>();
        public void oyna()
        {
           
           
        }
        public void tasat( tas tas,oyuncu oyuncu, k_oyuncu koyuncu)
        {
            // taş atma
           
            oyuncu.taslari.Remove(tas);
            koyuncu.taslari.Add(tas);
        }
        public void tascek(tas tas, k_oyuncu koyuncu, oyuncu oyuncu)//taş çekme
        {
           
            oyuncu.taslari.Add(tas);
            koyuncu.taslari.Remove(tas);
        }

       
       
    }
    
}
