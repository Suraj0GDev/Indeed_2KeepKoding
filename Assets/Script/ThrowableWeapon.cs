using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class ThrowableWeapon : MonoBehaviour
{
    [SerializeField] private Rigidbody rb; // Rigidbody for controlling the weapon's physics

    [SerializeField] private float speed = 2; // Speed of the throwable weapon
    [SerializeField] private float selfDestructionDistance = 3; // Time before self-destruction
    [SerializeField] private LayerMask hittable; // Layer mask to define hittable objects
    [SerializeField] private int damage = 1; // Damage dealt by the weapon

    // Method to throw the weapon in a specified direction
    public void ThrowInDirection(Vector3 direction)
    {
        rb.velocity = direction * speed; // Set the weapon's velocity based on the direction and speed

        StartCoroutine(DestroyAfterDistance()); // Start coroutine to destroy the weapon after traveling a certain distance
    }

    // Coroutine to destroy the weapon after a specified distance (time delay)
    private IEnumerator DestroyAfterDistance()
    {
        yield return new WaitForSeconds(selfDestructionDistance);
        DestroyThrowable(); // Destroy the weapon
    }

    // Method to stop all coroutines and destroy the weapon object
    private void DestroyThrowable()
    {
        StopAllCoroutines(); // Stop all active coroutines to avoid potential issues
        Destroy(gameObject); // Destroy the weapon object
    }

    // Method triggered when the weapon collides with another object
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit only");

        // Check if the collided object is in the hittable layer
        if ((hittable & 1 << other.gameObject.layer) != 0)
        {
            Debug.Log("hit and damage");

            // Try to get the Health component from the collided object
            Health health = other.GetComponent<Health>();
            if (health)
            {
                health.Reduce(damage); // Reduce the health of the collided object if it has a Health component
            }

            DestroyThrowable(); // Destroy the weapon after hitting a target
        }
    }
}
