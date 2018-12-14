using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    public bool isActive = false;
    public Collider2D existing;

    void Update()
    {
        if (isActive)
        {
            Debug.Log("Attack");

            StartCoroutine(Attack());
        }

    }

    IEnumerator Attack()
    {
        // do startup sequence
        existing.enabled = true;
        isActive = false;

        // wait for 1 sec(or more if needed later)
        yield return new WaitForSeconds(0.2f);
        // do endup sequence 
        existing.enabled = false;
        
    }

}
