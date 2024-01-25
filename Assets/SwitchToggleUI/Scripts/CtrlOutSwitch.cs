using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CtrlOutSwitch : MonoBehaviour
{
    [SerializeField] RectTransform uiHandleRectTransform;
    [SerializeField] Color backgroundActiveColor;
    [SerializeField] Color handleActiveColor;

    Image backgroundImage, handleImage;

    Color backgroundDefaultColor, handleDefaultColor;

    Toggle toggle;

    Vector2 handlePosition;

    private MqttService mqttService;

    [System.Obsolete]
    private void Start()
    {
        mqttService = MqttService.Instance;
        //toggle.isOn = true;
    }

    void Awake()
    {
        toggle = GetComponent<Toggle>();

        handlePosition = uiHandleRectTransform.anchoredPosition;

        backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();
        handleImage = uiHandleRectTransform.GetComponent<Image>();

        backgroundDefaultColor = backgroundImage.color;
        handleDefaultColor = handleImage.color;

        toggle.onValueChanged.AddListener(OnSwitch);

        if (toggle.isOn)
            OnSwitch(true);
    }

    void OnSwitch(bool on)
    {
        uiHandleRectTransform.anchoredPosition = on ? handlePosition * -1 : handlePosition;
        backgroundImage.color = on ? backgroundActiveColor : backgroundDefaultColor;
        handleImage.color = on ? handleActiveColor : handleDefaultColor;

        string topic = "microlab/agro/green_house/air_press_ctrl/set";
        string jsonPayload = $"{{\"sensor_id\": \"555\", \"cmd\": \"ctrl_out\", \"value\": \"{(on ? 1 : 0)}\"}}";
        _ = mqttService.Publish(topic, jsonPayload);

        Debug.Log($"Message sent: {jsonPayload}");

    }

    void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }
}