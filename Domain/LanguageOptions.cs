namespace Domain
{
    public class LanguageOptions
    {
        public const string ConfigSection = "Language";

        public String Battery { get; set; } = String.Empty;
        public String ToDay { get; set; } = String.Empty;
        public String Total { get; set; } = String.Empty;
        public String Grid { get; set; } = String.Empty;
        public String Temperature { get; set; } = String.Empty;
        public String Production { get; set; } = String.Empty;
        public String Consumption { get; set; } = String.Empty;
        public String State { get; set; } = String.Empty;
        public String Inverter { get; set; } = String.Empty;
        public String Photovoltaics { get; set; } = String.Empty;
        public String Buy { get; set; } = String.Empty;
        public String Sell { get; set; } = String.Empty;
        public String PowerOn { get; set;} = String.Empty;

    }
}
