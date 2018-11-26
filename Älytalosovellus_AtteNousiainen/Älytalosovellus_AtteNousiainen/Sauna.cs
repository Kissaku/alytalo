using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Älytalosovellus_AtteNousiainen
{
    public class Sauna
    {
        public bool Switched { get; set; }
        public string SaunaText { get; set; }
        public int SaunaLampo { get; set; }

        public void SaunaOn()
        {
            Switched = true;
            SaunaText = "SAUNA PÄÄLLÄ";
            
        }
        public void SaunaOff()
        {
            Switched = false;
            SaunaText = "";
        }
    }
}
