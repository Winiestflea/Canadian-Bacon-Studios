using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {

    public float velocity = 1;
    public bool active = true;
    public bool direction = true; // left is false right is true
    public Transform self;


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate( )
    {
        if ( active )
        {
            if ( direction )
            {
                self.position = new Vector3(self.position.x + velocity / 100, self.position.y, self.position.z);
            }
            else
            {
                self.position = new Vector3(self.position.x - velocity / 100, self.position.y, self.position.z);
            }
        }
    }
}
