using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSlit : MonoBehaviour {
    public Animator anim;
    public BoxCollider2D hitCollider;
    public GameObject arrow;
    public bool playerHit;


	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        hitCollider = this.GetComponent<BoxCollider2D>();
        hitCollider.enabled = false;
        playerHit = false;
        Activate();
    }

    public void Activate()
    {
        StartCoroutine("Shoot");
    }

    public IEnumerator Shoot()
    {
        anim.SetBool("IsActive", true);
        yield return new WaitForSeconds(0.1f);
        hitCollider.enabled = true;
        yield return new WaitForSeconds(0.2f);
        hitCollider.enabled = false;
        if (!playerHit) {
            Instantiate(arrow, this.gameObject.GetComponent<Transform>().position + new Vector3(0f, -0.15f, 0f), Quaternion.identity);
        }
        anim.SetBool("IsActive", false);
    }

    public void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        collision.gameObject.GetComponent<HealthManager>().TakeDamage(1.0f);
        playerHit = true;
    }
}
