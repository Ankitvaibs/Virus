# Smart Building Simulator #
The purpose of the Smart Building Simulator is to send data to Azure IoT Hub in the format that would be sent by a 
typical building sensor. More precisely, it sends data in the format that is sent by an on-premise gateway that polls
typical compliant BACnet devices such as Variable Air Volume (VAV) systems, Air Handling Units (AHUs), etc. The simulator 
can be used to push traffic into an existing Building Management System (BMS) or Building Automation System (BAS), or into 
a home-grown infrastructure based upon IoT Hub and various other Azure services such as Azure Stream Analytics, SQL Azure, and 
Azure Machine Learning.

## Software prerequisites ##
To build and run the Smart Building Simulator, you need to have addressed a portion of the Prerequisites in the PCS [readme.md](../readme.md). Specifically, you need to have everything listed
except SQL Server Management Studio:

* A Microsoft Azure subscription ([MSDN](https://msdn.microsoft.com/en-us/default.aspx) or the [free trial subscription](http://azure.microsoft.com/en-us/pricing/free-trial/) is sufficient) 
* Visual Studio 2013 or above installed if you are going to modify the Simulator. [Community Edition](http://www.visualstudio.com/downloads/download-visual-studio-vs) is sufficient. If you are planning only to run 
the simulator, not modify it, you can download the [binaries]() and do not need Visual Studio.
* The latest build of [Device Explorer](https://github.com/Azure/azure-iot-sdks/releases/download/2016-11-17/SetupDeviceExplorer.msi) installed. Check for more recent builds at [Azure IoT SDKs](https://github.com/Azure/azure-iot-sdks/releases). 
* Joined the [Azure-Samples](https://repos.opensource.microsoft.com/Azure-Samples) organization in GitHub
* Successfully requested joining the smartbuildings team in the Azure Samples organization


## Data structure ##
The simulator sends data in a prescribed JSON format. Here is a sample record:

```
{
	"GatewayName":"Spyros",
	"Timestamp":"2017-01-16T14:39:42.0048083Z",
	"Asset": {
		"DeviceName":"209101",
		"ObjectType":"AI",
		"Instance":"1",
		"PresentValue":10.0},
	"EventProcessedUtcTime":"2017-01-16T14:39:43.0427457Z",
	"PartitionId":2,
	"EventEnqueuedUtcTime":"2017-01-16T14:39:43.9530000Z",
	"IoTHub": {
		"MessageId":null,
		"CorrelationId":null,
		"ConnectionDeviceId":"SpyrosDevice1",
		"ConnectionDeviceGenerationId":"636185594611186461",
		"EnqueuedTime":"0001-01-01T00:00:00.0000000",
		"StreamId":null
    }
}
```

For the purposes of analyzing the data stream, the elements that are primarily of interest are the following:

```
{
	"GatewayName":"Spyros",
	"Timestamp":"2017-01-16T14:39:42.0048083Z",
	"Asset": {
		"DeviceName":"209101",
		"ObjectType":"AI",
		"Instance":"1",
		"PresentValue":10.0
	}
}
```
This would be interpreted as follows:
- **GatewayName**: the device sending data, for example, an on-premise IoT BACnet Gateway
- **Timestamp**: the time that the device is polled by the gateway. The simulator sends the timestamp in ISO 8601 format because that 
is the format that is supported by Azure Stream Analytics in a TIMESTAMP BY clause.
- **Asset.DeviceName**: the device the Gateway is polling, for example a building controller or a VAV
- **Asset.ObjectType**: the top level category of what the Gateway is polling on the physical device, such as the Analog 
Input or Analog Output ports
- **Asset.Instance**: the next level category of what the Gateway is polling, such as 1, 2, or 3, to represent Analog Input 1, Analog Input 2, etc
- **Asset.PresentValue**: the value sent by the device at the time that it is polled

## Building the Smart Building Simulator ##
To build the simulator you need to do the following:

1. Clone or copy the project to your desktop
2. From the Simulator folder, open `SimulatedSensors.sln` in Visual Studio
3. Build either a Release or Debug version


## Running the Smart Building Simulator ##
To run the simulator, execute `SimulatedSensors.Windows.exe.` (It can be found in /bin/release or /bin/debug of the project file if you have built it yourself.) 

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<img src="Images/SmartBuildingSimulator.PNG" alt="Building sensor simulator" width="320"/>

You can launch multiple instances of the simulator, for example if you wish to simulate multiple devices sending to the same 
IoT Hub simultaneously. They can all use the same or different values for the various fields.

## Using the Smart Building Simulator ##
There are several mandatory fields you need to fill:

1. Connection String (of IoT Hub)
2. Device Id (IotHub registered device)
3. GatewayName (name of on premise IoT gateway)
4. DeviceName (name of on premise device sending to gateway)
5. ObjectType
6. Instance

These are described briefly below.

### Connection String ###
This simulator mimics real devices output and sends data to the IoTHub. To start working with it, 
you need to register a device in the IoT Hub that you will target, and get the Connection String for the IoT Hub itself. You will find all the instructions 
to create device IDs and retrieve connection strings [here](https://github.com/Azure/azure-iot-sdk-csharp/tree/master/tools/DeviceExplorer). 
Specifically, you should install and run the graphical Device Explorer tool to connect to 
your IoT Hub and create/register one or more devices in IoT Hub.

You can find connection information for managing the IoT Hub instance in the [Azure portal](http://portal.azure.com). 

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<img src="Images/IoTHubConnectionString.png" alt="IoTHub Connection String" width= "800"/>

Once you have entered the IoT Hub Connection String, click "Get IoTHub Devices" to query the IoTHub for registered devices. (Note 
that the device Id retrieved is specifically the Id of the objects registered in IoTHub, and have no necessary relation to 
the DeviceName of the devices polled by the Gateway.) The simulator will then display a list of registered devices in the Device Id drop-down list. Pick any
of these - it does not particularly matter, as it simply allows the simulator to talk to the IoTHub and does not 
affect the data packet being transmitted by the simulator.


### Device Id ###

If you are deploying an Azure Smart Building infrastructure as outlined in the simulator's parent project, in addition to the IoTHub connection string, you optionally can enter the Connection String to the SQL Azure 
database where telemetry data will be saved. 
When Get IoTHub Devices button is pressed the simulator will connect to the IoTHub and download list of devices associated with it, as before. 
However, the simulator will also retrieve a list of known GatewayNames, DeviceNames, ObjectTypes, and Instances, and populate the corresponding 
drop down lists. This is strictly optional, as the you can enter whatever text you want in those text boxes, and the simulator 
will send that text. The value of retrieving known devices from the SQL Azure database is only that the subsequent event processing 
code in the Azure Smart Building infrastructure will be able to recognize the sender of the data and perform lookups and analyses on 
those devices.

*Note* In order for the simulator to be able to query the SQL database, you must first configure the Firewall rules for the database to allow your laptop to access the server. 
To do this, select the SQL database in the portal, then `Set server firewall` as shown below:

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<img src="Images/SQLServerSetFirewallRule.PNG" alt="SQL Firewall rule" width= "800"/>

In the Firewall Settings pane, click `Add Client IP` and then `Save`.


### GatewayName, DeviceName, ObjectType, and Instance ###

When "Send Data" button is pressed the simulator starts to send 2 messages per second to the IoTHub with the values of the fields GatewayName, DeviceName, ObjectType, and Instance being as typed in 
the text boxes. In addition, the similator sends a PresentValue field with a value as specified by the Value label set by the Trackbar slider position. You can 
also check the box "Add 10% variation" to vary the PresentValue by a random number between -10% and +10% of the Trackbar value. The Trackbar value can 
be changed when data are being sent to the IoTHub without stopping and restarting the transmission. To stop the transmission, click the "Sending telemetry button".

### Send Data text box ###

The text box below the "Send Data" button displays selected messages as they are sent by the simulator. This is useful for checking
whether the data is going out, and also whether the format is as you expected, particularly if you are trying to 
debug why data might not be coming in to IoT Hub as expected. Here is sample message sent by the simulator, as seen in the Send Data text box:

`[{"GatewayName":"RedWestVirtualGateway","Timestamp":"2017-01-20T06:59:42.5289781Z","Asset":{"DeviceName":"3210","ObjectType":"AI","Instance":"4","PresentValue":69.0}}]`

### View data received by IoT Hub ###

If you now launch Device Explorer, you can see the messages coming in to IoT Hub from your device:

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<img src="Images/DeviceExplorer.PNG" alt="DeviceExplorer" width="500"/>

At this stage, you can start working with the data streaming into IoT Hub.

## Stress Test Simulator ##
You can launch as many instances of the Smart Building Simulator as you want on your desktop. However, if
you want to send data from dozens or even hundreds of devices to really stress test your solution, you can launch
the [Stress test simulator](stresstest_simulator.md). However, be forewarned - this will generate a huge amount of traffic to your solution, with
technical and cost implications. 
