using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    int count = 0;
    public int lifetime;
    public int direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 moveVector= new Vector3(0f, 0f, 0f);
        switch (direction)
        {
            case 0:
                moveVector = new Vector3(0f, -0.01f, 0f);
                break;
            case 1:
                moveVector = new Vector3(0f, 0.01f, 0f);
                break;
            case 2:
                moveVector = new Vector3(-0.01f, 0f, 0f);
                break;
            case 3:
                moveVector = new Vector3(0.01f, 0f, 0f);
                break;
            case 4:
                moveVector = new Vector3(0.01f, 0.01f, 0f);
                break;
            case 5:
                moveVector = new Vector3(0.01f, -0.01f, 0f);
                break;
            case 6:
                moveVector = new Vector3(-0.01f, 0.01f, 0f);
                break;
            case 7:
                moveVector = new Vector3(-0.01f, -0.01f, 0f);
                break;
        }
        this.GetComponent<Transform>().position += moveVector;
        count++;
        if (count > lifetime)
        {
            Destroy(this.gameObject);
        }
	}

    public void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        collision.gameObject.GetComponent<HealthManager>().TakeDamage(1.0f);
        Destroy(this.gameObject);
    }

    public void SetDirection(int direction)
    {
        this.direction = direction;
    }
}
