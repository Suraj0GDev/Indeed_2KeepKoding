using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float attackInterval = 2; // Time interval between enemy attacks

    [SerializeField] private ThrowableWeapon weaponPrefab; // Prefab of the throwable weapon

    [SerializeField] private Transform throwPoint; // Point from where the weapon is thrown

    private void Start()
    {
        StartCoroutine(PerformAttack()); // Start the attack loop when the enemy is initialized
    }

    private IEnumerator PerformAttack()
    {
        // Wait for the specified interval before attacking
        yield return new WaitForSeconds(attackInterval);

        ThrowWeapon(); // Perform the weapon throw attack
    }

    private void ThrowWeapon()
    {
        // Instantiate the weapon prefab at the throw point position
        ThrowableWeapon throwable = Instantiate(weaponPrefab.gameObject, throwPoint.position, Quaternion.identity)
            .GetComponent<ThrowableWeapon>();

        // Throw the weapon in the forward direction
        throwable.ThrowInDirection(transform.forward * 1);

        // Restart the attack loop after throwing the weapon
        StartCoroutine(PerformAttack());
    }
}
