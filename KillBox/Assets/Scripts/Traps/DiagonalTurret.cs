using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalTurret : MonoBehaviour {
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
        while (activated)
        {
            yield return new WaitForSeconds(reloadTime);
            GameObject bullet1 = Instantiate(bullet, this.gameObject.GetComponent<Transform>().position + new Vector3(0.15f, 0.15f, 0f), Quaternion.identity);
            bullet1.GetComponent<Bullet>().SetDirection(4);
            GameObject bullet2 = Instantiate(bullet, this.gameObject.GetComponent<Transform>().position + new Vector3(0.15f, -0.15f, 0f), Quaternion.identity);
            bullet2.GetComponent<Bullet>().SetDirection(5);
            GameObject bullet3 = Instantiate(bullet, this.gameObject.GetComponent<Transform>().position + new Vector3(-0.15f, 0.15f, 0f), Quaternion.identity);
            bullet3.GetComponent<Bullet>().SetDirection(6);
            GameObject bullet4 = Instantiate(bullet, this.gameObject.GetComponent<Transform>().position + new Vector3(-0.15f, -0.15f, 0f), Quaternion.identity);
            bullet4.GetComponent<Bullet>().SetDirection(7);
        }
    }
}
