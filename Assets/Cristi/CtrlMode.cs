using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CtrlMode : MonoBehaviour, IPointerClickHandler, IEndDragHandler, IPointerExitHandler
{
    public Slider temperatureSlider;
    public Slider visualEnergySlider;
    public int tempValue;
    private MqttService mqttService;
    private bool sliderValueChanged = false;

    private float currentEnergyValue;
    private float maxEnergyValue = 2;
    public TMP_Text energyText;
    private int ctrlModeSwitchValue = -1;
    private int ctrlOutSwitchValue = -1;

    [System.Obsolete]
    private void Start()
    {
        energyText.text = "0";
        visualEnergySlider.minValue = 0;
        visualEnergySlider.maxValue = 2;

        mqttService = MqttService.Instance;
        
        temperatureSlider.minValue = 0;
        temperatureSlider.maxValue = 50;

        temperatureSlider.onValueChanged.AddListener(OnSliderValueChanged);

        Update();
    }

    private void Update()
    {
        //AdjustEnergyValue((float)mqttService.LightCtrlData["cur_lum"]);
        if (mqttService != null && mqttService.AirPressCtrlData != null)
        {
            AdjustEnergyValue((float)(mqttService.AirPressCtrlData["cur_press"]));
        }
    }

    public void SendMessageCtrl()
    {
        Debug.Log("Subscribe");
        mqttService.Subscribe("microlab/agro/green_house/light_ctrl");
    }

    public void AdjustEnergyValue(float currentEnergyValue = 0)
    {
        //Debug.Log("Value" + currentEnergyValue);
        visualEnergySlider.value = currentEnergyValue;
        currentEnergyValue = Mathf.Clamp(currentEnergyValue, 0f, maxEnergyValue);
        energyText.text = "" + currentEnergyValue.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Check if the click event occurred on the slider
        if (RectTransformUtility.RectangleContainsScreenPoint(temperatureSlider.GetComponent<RectTransform>(), eventData.position, eventData.enterEventCamera))
        {
            Debug.Log("Click on the slider. Value: " + temperatureSlider.value);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Check if the slider value has changed during dragging
        if (sliderValueChanged)
        {
            Debug.Log("Slider released. Value: " + temperatureSlider.value);
            sliderValueChanged = false;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Deselection logic can be added here
       // Debug.Log("Slider deselected");
    }

    private void OnSliderValueChanged(float value)
    {
        // Set a flag indicating that the slider value has changed
        sliderValueChanged = true;
    }


}
