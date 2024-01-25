/*using System;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using MQTTnet;
using MQTTnet.Client;
using Unity.VisualScripting;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
public class Mqtt : MonoBehaviour
{
    private MqttService mqttService;
    private void Start()
    {
        StartCoroutine(TestConnection());
    }

    private IEnumerator TestConnection()
    {
        mqttService = MqttService.Instance;

        while (true)
        {
            yield return new WaitForSeconds(1f); 

            if (mqttService != null && mqttService.LightCtrlData != null)
            {

                JObject data = mqttService.LightCtrlData;

                // Access values using keys
                int sensorId = (int)data["sensor_id"];
                float curLum = (float)data["cur_lum"];
                int setPoint = (int)data["set_point"];
                int ctrlMode = (int)data["ctrl_mode"];
                int ctrlOut = (int)data["ctrl_out"];

                Debug.Log($"{sensorId}, {curLum}, {setPoint}, {ctrlMode}, {ctrlOut}");
            
            }
            else
            {
                Debug.Log("NULL VALUE");
            }
        }
    }
}
*/