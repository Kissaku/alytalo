using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Älytalosovellus_AtteNousiainen
{
    public class Thermostat
    {
        public int Temperature { get; set; }
        public string TemperatureSet { get; set; }

        public void SetTemperature()
        {
            
            try
            {
                Temperature = int.Parse(TemperatureSet);
                if (Temperature >= 18 && Temperature <= 31)
                {
                    TemperatureSet = Temperature.ToString();
                }
                else
                {
                    TemperatureSet = "ERROR!";
                }
            }
            catch
            {
                TemperatureSet = "ERROR!";
            }
        }
    }
}
