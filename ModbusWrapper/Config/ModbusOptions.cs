namespace ModbusWrapper.Config
{
    public class ModbusOptions
    {
        public const string ConfigSection = "ModbusConnection";
        public String Server { get; set; }
        public int Port { get; set; }
    }
}
