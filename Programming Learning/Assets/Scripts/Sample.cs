using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour {

    public string MyName;
    public int MyNumber;
    public long MyBigLong;
    public float MyDecimal;
    public bool ShowHello;
    public double MyDoubleDecimal;
    public char MyCharacter;

    void Run()
    {
        Debug.Log("Run, "+MyName+"!");
        Debug.Log(MyName + ", " + MyNumber + ", " + MyBigLong + ", " + MyDecimal + ", " + ShowHello + ", " + MyDoubleDecimal + ", " + MyCharacter);
    }

	// Use this for initialization
	void Start () {
        if (MyNumber != 10) {
            string otherName = "Bob";
            Debug.Log("Hello " + otherName + " and " + MyName);
        }
        else if (MyNumber > 5)
            Debug.Log("No message to show");
        else if (MyNumber == 2)
            Debug.Log("end");
	}
	
	/* Update is called once per frame
	void Update () {
        Debug.Log("Hi");
	}
    */
}
