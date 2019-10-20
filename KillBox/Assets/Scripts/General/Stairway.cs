using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairway : MonoBehaviour {

    public LayerMask playerLayer;
    public BoxCollider2D bc;
    // Use this for initialization
    bool isShown;
	void Start () {
        bc = GetComponent<BoxCollider2D>();
        GetComponent<SpriteRenderer>().enabled = false;
        isShown = false;
	}
	
	// Update is called once per frame
	void Update () {
        Collider2D hit = Physics2D.OverlapBox(bc.bounds.center,bc.bounds.extents,0,playerLayer);
        if (hit)
        {
            StartNextLevel();
        }
	}
    public void ShowStairCase()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        isShown = true;
        Debug.Log("Staircase");
    }
    public void StartNextLevel()
    {
        if (isShown)
        {
            GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().ImproveStats();
            Debug.Log("New Level");
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i =0; i < enemies.Length; i++)
            {

            }
            isShown = false;
        }
    }
    
}
