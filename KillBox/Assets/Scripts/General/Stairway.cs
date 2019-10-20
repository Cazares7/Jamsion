using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairway : MonoBehaviour {

    

    // Use this for initialization
    bool isShown;
	void Start () {
        
        GetComponent<SpriteRenderer>().enabled = false;
        isShown = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ShowStairCase()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        isShown = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isShown)
        {
            GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().ImproveStats();
            isShown = false;
        }
    }
}
