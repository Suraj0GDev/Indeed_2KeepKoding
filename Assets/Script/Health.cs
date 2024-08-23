using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10;
    [SerializeField] private FloatValueSO currentHealth;
    [SerializeField] private GameObject Gameover_Panel;

    private Animator animator;

    [SerializeField] private float flashTime = 0.2f;

    private void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
        currentHealth.Value = 1;
    }

    public void Reduce(int damage)
    {
        currentHealth.Value -= damage / maxHealth;
        CreateHitFeedback();
        if (currentHealth.Value < 0.05)
        {
            Die();
        }
    }

    public void AddHealth(int healthBoost)
    {
        int health = Mathf.RoundToInt(currentHealth.Value * maxHealth);
        int val = health + healthBoost;
        currentHealth.Value = (val > maxHealth ? maxHealth : val / maxHealth);
    }

    private void CreateHitFeedback()
    {
        
        StartCoroutine(FlashFeedback());
    }

    private IEnumerator FlashFeedback()
    {
        
        yield return new WaitForSeconds(flashTime);
        
    }

    private void Die()
    {
        CharacterController characterController = GetComponent<CharacterController>();
        characterController.enabled = false;
        Debug.Log("Died");
        animator.SetBool("dead", true);
        Gameover_Panel.SetActive(true);
    }
}

