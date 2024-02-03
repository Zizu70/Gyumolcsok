using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyumolcsok
{
    internal class Gyumolcs
    {
        ulong termekkod;
        string gyumolcsneve;
        int mennyiseg;

        public ulong Termekkod { get => termekkod; set => termekkod = value; }
        public string Gyumolcsneve { get => gyumolcsneve;  set => gyumolcsneve = value; }
        public int Mennyiseg { get => mennyiseg; set => mennyiseg = value; }

        public Gyumolcs(ulong termekkod, string gyumolcsneve, int mennyiseg)
        {
            Termekkod = termekkod;
            Gyumolcsneve = gyumolcsneve;
            Mennyiseg = mennyiseg;
            
        }
     
        public override string ToString()
        {
            return $"{this.termekkod} - {this.gyumolcsneve} - {this.mennyiseg}";
        }        

        public string toTxt()
        {
            return $"{this.termekkod};{this.gyumolcsneve};{this.mennyiseg}";
        }



    }



}
