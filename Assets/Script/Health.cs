using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10; // Maximum health value
    [SerializeField] private FloatValueSO currentHealth; // Current health stored in a ScriptableObject
    [SerializeField] private GameObject Gameover_Panel; // Reference to the Game Over UI panel

    private Animator animator; // Animator component to handle animations

    [SerializeField] private float flashTime = 0.2f; // Duration of the visual feedback when hit

    private void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
        currentHealth.Value = 1; // Initialize health as full (1 represents 100%)
    }

    // Method to reduce health when damage is taken
    public void Reduce(int damage)
    {
        // Decrease health based on damage and maximum health
        currentHealth.Value -= damage / maxHealth;
        CreateHitFeedback(); // Trigger hit feedback

        // If health drops below a threshold, trigger death
        if (currentHealth.Value < 0.05)
        {
            Die();
        }
    }

    // Method to add health (health boost or healing)
    public void AddHealth(int healthBoost)
    {
        // Convert current health from percentage to absolute value
        int health = Mathf.RoundToInt(currentHealth.Value * maxHealth);

        // Add health boost, but do not exceed maximum health
        int val = health + healthBoost;
        currentHealth.Value = (val > maxHealth ? maxHealth : val) / maxHealth;
    }

    // Method to trigger hit feedback
    private void CreateHitFeedback()
    {
        StartCoroutine(FlashFeedback()); // Start flashing feedback coroutine
    }

    // Coroutine to handle visual feedback when hit (e.g., flashing)
    private IEnumerator FlashFeedback()
    {
        // Flash for a short time
        yield return new WaitForSeconds(flashTime);
    }

    // Method to handle the death of the character
    private void Die()
    {
        // Disable the CharacterController to stop movement
        CharacterController characterController = GetComponent<CharacterController>();
        characterController.enabled = false;

        Debug.Log("Died");

        // Trigger death animation
        animator.SetBool("dead", true);

        // Display the Game Over panel
        Gameover_Panel.SetActive(true);
    }
}
