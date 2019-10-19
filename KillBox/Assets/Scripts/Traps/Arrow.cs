using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Transform>().position += new Vector3(0f, -0.01f, 0f);
    }

    public void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        collision.gameObject.GetComponent<HealthManager>().TakeDamage(1.0f);
        Destroy(this.gameObject);
    }
}
