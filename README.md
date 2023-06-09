# Overview
This project reads Realdata from a DEYE Inverter SUN-(5k,6k,8k,10k,12K)-SG04LP3-EU.
I have attached a Waveshare RS485 to RJ45 (B) to read the ModBus data directly.
I use the https://github.com/samuelventura/SharpModbus for reading the ModBus data.

The ModBusWrapper from me give you all needed registers into an object.

I use Visual Studio 2022 and .Net6

# Configuration
In the appsetting.json you need to add the IP and the port for communication.
If you want to use the Ui you can change the language in this json to. 


