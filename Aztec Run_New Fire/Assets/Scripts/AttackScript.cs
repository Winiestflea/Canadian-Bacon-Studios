using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    private bool isActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isActive = true;
            StartCoroutine(Attack());
        }

        if (isActive == true)
        {
            Debug.Log("Attack");
        }

    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1);
        isActive = false;
    }

}
