using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {
    public Animator anim;
    public BoxCollider2D hitCollider;

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
        anim.SetBool("IsActive", true);
        yield return new WaitForSeconds(0.5f);
        hitCollider.enabled = true;
        yield return new WaitForSeconds(1.5f);
        hitCollider.enabled = false;
        anim.SetBool("IsActive", false);
    }

    public void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        collision.gameObject.GetComponent<HealthManager>().TakeDamage(1.0f);
    }
}
