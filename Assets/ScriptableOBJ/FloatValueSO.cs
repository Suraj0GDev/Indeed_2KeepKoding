using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/FloatData")]
public class FloatValueSO : ScriptableObject
{
    [SerializeField]
    private float _value; // Serialized float value stored in the ScriptableObject

    // Public property to get and set the value
    public float Value
    {
        get => _value;
        set
        {
            _value = value; // Update the value
            OnValueChange?.Invoke(_value); // Invoke the event when the value changes
        }
    }

    // Event triggered when the value changes
    public event Action<float> OnValueChange;
}
