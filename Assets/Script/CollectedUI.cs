using UnityEngine;
using UnityEngine.UI;

public class CollectedUI : MonoBehaviour
{
    [SerializeField] private FloatValueSO collected; // Reference to the ScriptableObject holding the collected value
    [SerializeField] private Text collectedText; // Reference to the UI Text component that displays the collected count

    private void OnEnable()
    {
        // Subscribe to the OnValueChange event when the UI is enabled
        collected.OnValueChange += UpdateCollectedText;
    }

    private void OnDisable()
    {
        // Unsubscribe from the event to avoid memory leaks when the UI is disabled
        collected.OnValueChange -= UpdateCollectedText;
    }

    private void Start()
    {
        collected.Value = 0f; // Initialize the collected value to 0 at the start
        // Update the UI with the initial value
        UpdateCollectedText(collected.Value);
    }

    private void UpdateCollectedText(float newValue)
    {
        // Update the UI text with the new collected value
        collectedText.text = newValue.ToString() + "/10";
    }
}
