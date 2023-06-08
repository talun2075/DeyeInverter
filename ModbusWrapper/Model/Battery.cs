using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusWrapper.Model
{
    public class Battery
    {
        public String FilledInPercent { get; set; } = String.Empty;
        public String Temperatur { get; set; } = String.Empty;
        public int CurrentPower { get; set; } = 0;
    }
}
