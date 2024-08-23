using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
 

    [SerializeField] private float attackInterval = 2;

    [SerializeField] private ThrowableWeapon weaponPrefab;

    [SerializeField] private Transform throwPoint;

   

    private void Start()
    {
        StartCoroutine(PerformAttack());
    }

    private IEnumerator PerformAttack()
    {
        yield return new WaitForSeconds(attackInterval);
        
        ThrowWeapon();
    }

    private void ThrowWeapon()
    {
        ThrowableWeapon throwable = Instantiate(weaponPrefab.gameObject, throwPoint.position, Quaternion.identity)
            .GetComponent<ThrowableWeapon>();
        throwable.ThrowInDirection(transform.forward * 1);
        
        StartCoroutine(PerformAttack());
    }
}
