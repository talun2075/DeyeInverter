using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusWrapper.Enums
{
    public enum DeyeState
    {
        Standby = 0,
        SelfCheck = 1,
        Normal = 2,
        Alarm = 3,
        Fault = 4,
        NotSet = 99

    }
}
