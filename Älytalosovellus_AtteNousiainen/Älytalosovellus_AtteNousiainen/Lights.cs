using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Älytalosovellus_AtteNousiainen
{
    public class Lights
    {
        public bool Switched { get; set; }
        public string Dimmer { get; set; }

        public void Kirkas()
        {
            Switched = true;
            Dimmer = "100";
        }

        public void Puolivalot()
        {
            Switched = true;
            Dimmer = "66";
        }

        public void Hamara()
        {
            Switched = true;
            Dimmer = "33";
        }

        public void Stop()
        {
            Switched = false;
            Dimmer = "0";
        }
    }
}
