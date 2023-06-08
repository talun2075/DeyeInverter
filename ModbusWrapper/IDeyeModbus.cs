using ModbusWrapper.Model;

namespace ModbusWrapper
{
    public interface IDeyeModbus
    {
        DeyeDto ReadData();
    }
}