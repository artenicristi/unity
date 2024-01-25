using MQTTnet;
using MQTTnet.Client;
using System;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class MqttService
{
    private static string broker = "9b7b323ee67e46d18f9317162c8e8841.s1.eu.hivemq.cloud";
    private static int port = 8883;
    private static string clientId = Guid.NewGuid().ToString();
    private static string username = "sergiu.doncila";
    private static string password = "QWEasd!@#123";

    private static MqttService instance;
    private IMqttClient mqttClient;
    public string specificTopicData;
    private static readonly object lockObject = new object();

    private const int LIGHT_CTRL_SENSOR_ID = 666;
    private const int AIR_PRESS_CTRL_SENSOR_ID = 555;

    public JObject LightCtrlData;
    public JObject AirPressCtrlData;

    private MqttService(){}

    [Obsolete]
    public static MqttService Instance
    {
        get
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new MqttService();
                    _ = instance.InitializeConnection(broker, port, clientId, username, password);
                }
                return instance;
            }
        }
    }

    [Obsolete]
    private async Task InitializeConnection(string broker, int port, string clientId, string username, string password)
    {
        await Connect();
    }

    [Obsolete]
    private async Task Connect()
    {
        var factory = new MqttFactory();
        mqttClient = factory.CreateMqttClient();

        var options = new MqttClientOptionsBuilder()
            .WithTcpServer(broker, port)
            .WithCredentials(username, password)
            .WithClientId(clientId)
            .WithTls()
            .Build();

        var connectResult = await mqttClient.ConnectAsync(options);

        if (connectResult.ResultCode == MqttClientConnectResultCode.Success)
        {
            Debug.Log("Connected to MQTT broker successfully.");

            await Subscribe("microlab/agro/green_house/light_ctrl");
            await Subscribe("microlab/agro/green_house/air_press_ctrl");

            mqttClient.ApplicationMessageReceivedAsync += e =>
            {
                HandleReceivedMessage(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
                return Task.CompletedTask;
            };

            //StartCoroutine(KeepRunning());
        }
        else
        {
            Debug.LogError($"Failed to connect to MQTT broker: {connectResult.ResultCode}");
        }
    }

    public async Task Subscribe(string topic)
    {
        if (mqttClient != null && mqttClient.IsConnected)
        {
            await mqttClient.SubscribeAsync(topic);
        }
    }

    public async Task Publish(string topic, string payload)
    {
        if (mqttClient != null && mqttClient.IsConnected)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .Build();

            await mqttClient.PublishAsync(message);
        }
    }

    private void HandleReceivedMessage(string message)
    {
        Debug.Log($"Message received: {message}");

        JObject jsonObject = JObject.Parse(message);

        if ((int)jsonObject["sensor_id"] == LIGHT_CTRL_SENSOR_ID)
        {
            LightCtrlData = jsonObject;
        } else if ((int)jsonObject["sensor_id"] == AIR_PRESS_CTRL_SENSOR_ID)
        {
            AirPressCtrlData = jsonObject;
        }
    }
}
