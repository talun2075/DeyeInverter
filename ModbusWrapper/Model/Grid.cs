namespace ModbusWrapper.Model
{
    public class Grid
    {
        public int GridCurrent { get; set; } = 0;
        public int DailyBuy { get; set; } = 0;
        public int DailySell { get; set; } = 0;
        public int TotalBuy { get; set; } = 0;
        public int TotalSell { get; set; } = 0;
    }
}
