
namespace ModbusWrapper.Model
{
    public class PV
    {
        public int PV1CurrentPower { get; set; } = 0;
        public int PV2CurrentPower { get; set; } = 0;
        public int PV3CurrentPower { get; set; } = 0;
        public int PV4CurrentPower { get; set; } = 0;
        public int Daily { get; set; } = 0;
        public int Total { get; set; } = 0;

        public int TotalCurrentPower { get {
                return PV1CurrentPower + PV2CurrentPower + PV3CurrentPower + PV4CurrentPower;
            } }
    }
}
