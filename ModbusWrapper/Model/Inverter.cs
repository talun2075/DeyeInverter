using ModbusWrapper.Enums;

namespace ModbusWrapper.Model
{
    public class Inverter
    {
        public DeyeState State { get; set; } = DeyeState.NotSet;
        public String InverterTemperature { get; set; } = String.Empty;
        public Boolean PowerOn { get; set; }
    }
}
