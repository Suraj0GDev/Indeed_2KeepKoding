using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private FloatValueSO collected; // Reference to the ScriptableObject
    private bool isPlayerInRange = false; // Tracks if the player is in range of the collectible
    [SerializeField]
    private GameObject collectable;
    [SerializeField]
    private GameObject PreessE;

    [SerializeField]
    private GameObject Collection_Complete;

    private void Update()
    {
        // Check if the player is in range and the "C" button is pressed
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Increment the collected value by 1
            collected.Value += 1;
            // Destroy the collectible object
            Destroy(collectable);

            if(collected.Value == 10)
            {
                Collection_Complete.SetActive(true);
            }

            PreessE.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger range
        if (other.CompareTag("collectable"))
        {
            isPlayerInRange = true; // Set the flag to true
            PreessE.SetActive(true);
        }
        collectable = other.gameObject;
       
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the trigger range
        if (other.CompareTag("collectable"))
        {
            isPlayerInRange = false; // Set the flag to false
            PreessE.SetActive(false);
        }
        
    }
}