using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {
    public Animator anim;
    public BoxCollider2D hitCollider;
    public float reloadTime;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        hitCollider = this.GetComponent<BoxCollider2D>();
        hitCollider.enabled = false;
        Activate();
	}
	
	public void Activate()
    {
        StartCoroutine("UpAndDown");
    }

    public IEnumerator UpAndDown()
    {
        bool activated = true;
        while (activated) {
            yield return new WaitForSeconds(reloadTime);
            anim.SetBool("IsActive", true);
            yield return new WaitForSeconds(1f);
            hitCollider.enabled = true;
            yield return new WaitForSeconds(1f);
            hitCollider.enabled = false;
            anim.SetBool("IsActive", false);
        }
    }

    public void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        collision.gameObject.GetComponent<HealthManager>().TakeDamage(1.0f);
    }
}
