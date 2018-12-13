using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICollisionHelper : MonoBehaviour {
    public Collider2D self;
    public enemyAI enemy;
    public bool activateDeactivate;

    private void OnTriggerExit2D( Collider2D collision )
    {
        enemy.direction = activateDeactivate;
    }
}
