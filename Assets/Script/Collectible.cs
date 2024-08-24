using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private FloatValueSO collected; // Reference to the ScriptableObject that tracks the collected count
    private bool isPlayerInRange = false; // Tracks if the player is in range of the collectible

    [SerializeField] private GameObject collectable; // Reference to the collectible object
    [SerializeField] private GameObject PreessE; // UI prompt that instructs the player to press "E"
    [SerializeField] private GameObject Collection_Complete; // UI display for when the collection is complete

    private void Update()
    {
        // Check if the player is in range and the "E" button is pressed
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Increment the collected value by 1
            collected.Value += 1;

            // Destroy the collectible object
            Destroy(collectable);

            // If the collected value reaches 10, show the completion UI
            if (collected.Value == 10)
            {
                Collection_Complete.SetActive(true);
            }

            // Hide the "Press E" prompt
            PreessE.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger range of a collectible
        if (other.CompareTag("collectable"))
        {
            isPlayerInRange = true; // Set the flag to true when the player is in range
            PreessE.SetActive(true); // Show the "Press E" prompt
        }

        // Assign the collectible object that triggered the event
        collectable = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the trigger range of a collectible
        if (other.CompareTag("collectable"))
        {
            isPlayerInRange = false; // Set the flag to false when the player leaves the range
            PreessE.SetActive(false); // Hide the "Press E" prompt
        }
    }
}
