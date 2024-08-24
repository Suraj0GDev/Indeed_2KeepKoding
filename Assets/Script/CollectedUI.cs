using UnityEngine;
using UnityEngine.UI;


public class CollectedUI : MonoBehaviour
{
    [SerializeField] private FloatValueSO collected; // Reference to the ScriptableObject
    [SerializeField] private Text collectedText; // Reference to the UI Text component

    private void OnEnable()
    {
        // Subscribe to the event when the UI is enabled
        collected.OnValueChange += UpdateCollectedText;
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        collected.OnValueChange -= UpdateCollectedText;
    }

    private void Start()
    {
        collected.Value = 0f;
        // Initialize the UI with the current value
        UpdateCollectedText(collected.Value);
    }

    private void UpdateCollectedText(float newValue)
    {
        // Update the UI text with the new value
        collectedText.text = newValue.ToString() + "/10";
    }
}
