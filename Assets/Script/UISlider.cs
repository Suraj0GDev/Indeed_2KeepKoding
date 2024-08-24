using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlider : MonoBehaviour
{
    [SerializeField] private Image sliderImage; // Reference to the UI Image component used as the slider

    [SerializeField] private FloatValueSO floatValue; // Reference to the ScriptableObject that holds the float value

    private void OnEnable()
    {
        // Subscribe to the OnValueChange event when the UI is enabled
        floatValue.OnValueChange += SetValue;
    }

    private void OnDisable()
    {
        // Unsubscribe from the event to avoid memory leaks when the UI is disabled
        floatValue.OnValueChange -= SetValue;
    }

    // Method to update the slider's fill amount based on the current value
    public void SetValue(float currentValue)
    {
        // Clamp the value between 0 and 1 and update the slider's fill amount
        sliderImage.fillAmount = Mathf.Clamp01(currentValue);
    }
}
