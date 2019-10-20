using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public GameObject bullet;
    public float reloadTime;

	// Use this for initialization
	void Start () {
        Activate();
	}
	
	public void Activate()
    {
        StartCoroutine("Shoot");
    }

    public IEnumerator Shoot()
    {
        bool activated = true;
        while (activated) {
            yield return new WaitForSeconds(reloadTime);
            GameObject bullet1 = Instantiate(bullet, this.gameObject.GetComponent<Transform>().position + new Vector3(0f, -0.15f, 0f), Quaternion.identity);
            bullet1.GetComponent<Bullet>().SetDirection(0);
            GameObject bullet2 = Instantiate(bullet, this.gameObject.GetComponent<Transform>().position + new Vector3(0f, 0.15f, 0f), Quaternion.identity);
            bullet2.GetComponent<Bullet>().SetDirection(1);
            GameObject bullet3 = Instantiate(bullet, this.gameObject.GetComponent<Transform>().position + new Vector3(-0.15f, 0f, 0f), Quaternion.identity);
            bullet3.GetComponent<Bullet>().SetDirection(2);
            GameObject bullet4 = Instantiate(bullet, this.gameObject.GetComponent<Transform>().position + new Vector3(0.15f, 0f, 0f), Quaternion.identity);
            bullet4.GetComponent<Bullet>().SetDirection(3);
        }
    }
}
