using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;


public class ThrowableWeapon : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float speed = 2;
    [SerializeField] private float selfDestructionDistance = 3;
    [SerializeField] private LayerMask hittable;
    [SerializeField] private int damage = 1;

    public void ThrowInDirection(Vector3 direction)
    {
        rb.velocity = direction * speed;

        StartCoroutine(DestroyAfterDistance());
    }

    private IEnumerator DestroyAfterDistance()
    {
        yield return new WaitForSeconds(selfDestructionDistance);
        DestroyThrowable();
    }

    private void DestroyThrowable()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit only");
        if ((hittable & 1 << other.gameObject.layer) != 0)
        {

            Debug.Log("hit and damage");
            Health health = other.GetComponent<Health>();
            if (health)
            {
                health.Reduce(damage);
            }

            DestroyThrowable();
        }

    }


}
