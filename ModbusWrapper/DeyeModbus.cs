using Microsoft.Extensions.Options;
using ModbusWrapper.Config;
using ModbusWrapper.Enums;
using ModbusWrapper.Model;
using SharpModbus;

namespace ModbusWrapper
{

    public class DeyeModbus : IDeyeModbus
    {
        private readonly IOptionsMonitor<ModbusOptions> _options;

        public DeyeModbus(IOptionsMonitor<ModbusOptions> options)
        {
            _options = options;
        }

        public DeyeDto ReadData()
        {
            DeyeDto retval = new DeyeDto();
            try
            {
                using (var master = ModbusMaster.TCP(_options.CurrentValue.Server, _options.CurrentValue.Port))
                {
                    #region Serial
                    //SerialNumber
                    var data = master.ReadHoldingRegisters(1, 3, 5);
                    string serial = String.Empty;
                    byte[] byteArray;
                    foreach (var reg in data)
                    {
                        byteArray = BitConverter.GetBytes(reg);
                        serial += String.Format("{0:d}{1:d}", System.Convert.ToChar(byteArray[1]).ToString(), System.Convert.ToChar(byteArray[0]).ToString());
                    }
                    retval.Serial = serial;
                    #endregion Serial
                    #region Battery
                    //Battery %
                    var batteryper = master.ReadHoldingRegister(1, 588);
                    retval.Battery.FilledInPercent = batteryper.ToString();

                    //Batterie Ussage
                    var batterycurrentpower = master.ReadHoldingRegister(1, 590);
                    // var hex = singledata2.ToString("X");//todo: nötig bei minus?
                    //Console.WriteLine("Batterie Ladestatus (Hex convert): " + Convert.ToInt16(hex, 16));
                    int intValue = batterycurrentpower - ((batterycurrentpower > 32767) ? 65536 : 0);//convert to signed int
                    retval.Battery.CurrentPower = intValue;
                    var batterytemp = master.ReadHoldingRegister(1, 586);
                    retval.Battery.Temperatur = (Convert.ToDecimal(batterytemp - 1000) / 10).ToString();
                    #endregion Battery
                    #region Inverter
                    var deyestate = master.ReadHoldingRegister(1, 500);
                    if (Enum.TryParse(deyestate.ToString(), out DeyeState ds))
                    {
                        retval.Deye.State = ds;
                    }
                    
                    var deyestemp = master.ReadHoldingRegister(1, 541);
                    retval.Deye.InverterTemperature = (Convert.ToDecimal(deyestemp - 1000) / 10).ToString();
                    var powerstate = master.ReadHoldingRegister(1, 551);
                    retval.Deye.PowerOn = powerstate == 1;
                    #endregion Inverter
                    #region Home
                    retval.HomeUse.Daily = master.ReadHoldingRegister(1, 526);
                    retval.HomeUse.Total = master.ReadHoldingRegister(1, 527);
                    retval.HomeUse.Current = master.ReadHoldingRegister(1, 643);
                    #endregion Home
                    #region Grid


                    //Grid
                    retval.Grid.GridCurrent = master.ReadHoldingRegister(1, 607);
                    retval.Grid.DailyBuy = master.ReadHoldingRegister(1, 520);
                    retval.Grid.DailySell = master.ReadHoldingRegister(1, 521);
                    retval.Grid.TotalBuy = master.ReadHoldingRegister(1, 522);
                    retval.Grid.TotalSell = master.ReadHoldingRegister(1, 524);
                    #endregion Grid
                    #region Photovoltaics
                    //PV Produktion
                    var pv = master.ReadHoldingRegisters(1, 672, 4);
                    retval.Photovoltaics.PV1CurrentPower = pv[0];
                    retval.Photovoltaics.PV2CurrentPower = pv[1];
                    retval.Photovoltaics.PV3CurrentPower = pv[2];
                    retval.Photovoltaics.PV4CurrentPower = pv[3];
                    retval.Photovoltaics.Daily = master.ReadHoldingRegister(1, 529);
                    retval.Photovoltaics.Total = master.ReadHoldingRegister(1, 534);
                    #endregion Photovoltaics
                }
            }
            catch (Exception ex)
            {
               retval.CommunicationErrors = ex.Message;
            }
            return retval;
        }
    }
}