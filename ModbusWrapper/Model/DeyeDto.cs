namespace ModbusWrapper.Model
{
    public class DeyeDto
    {
        public String Serial { get; set; } = String.Empty;
        public Battery Battery { get; set; } = new();
        public Inverter Deye { get; set; } = new();
        public PV Photovoltaics { get; set; } = new();
        public Grid Grid { get; set; } = new();
        public PowerUse HomeUse { get; set; } = new();
        public String CommunicationErrors { get; set; }= String.Empty;
    }
}
