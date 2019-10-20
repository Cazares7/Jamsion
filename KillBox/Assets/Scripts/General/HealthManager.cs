using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {
    public int maxHealth;
    float currentHealth;

    public float invincibiltyFrames = .1f;
    public GameObject hurtEffect;
    public GameObject deathEffect;
    float invinceTimer;

    bool hasDied;

    Animator anim;
    
    Rigidbody2D rb;

    bool hurting;
    float hurtFrames = 10/60f;
    float hurtTimer;
	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0)
        {
            if(!hasDied)
            {
                Death();
                hasDied = true;
            }
        }

        if (invinceTimer > 0)
            invinceTimer -= Time.deltaTime;

        if (hurtTimer <= 0)
        {
            hurting = false;
        }
        else
        {
            hurtTimer -= Time.deltaTime;
        }
	}

    public void TakeDamage(float damage)
    {
        if (invinceTimer <= 0)
        {
            currentHealth -= damage;
            if (currentHealth > 0)
            GameObject.FindGameObjectWithTag("Camera").GetComponent<Animator>().SetTrigger("Shake");
            else
                GameObject.FindGameObjectWithTag("Camera").GetComponent<Animator>().SetTrigger("Hard_Shake");

            anim.SetTrigger("Hurt");
            invinceTimer = invincibiltyFrames;
            Instantiate(hurtEffect, transform.position, Quaternion.identity);
           // StartCoroutine(Hitstop());
        }

    
    }

    public void TakeDamage(float damage, float knockBackForce, Transform origin)
    {
        if (invinceTimer <= 0)
        {
            hurting = true;
            hurtTimer = hurtFrames;
            currentHealth -= damage;
            GameObject.FindGameObjectWithTag("Camera").GetComponent<Animator>().SetTrigger("Shake");

            anim.SetTrigger("Hurt");
            invinceTimer = invincibiltyFrames;
            Instantiate(hurtEffect, transform.position, Quaternion.identity);

            Vector2 difference = transform.position - origin.position;
            difference = difference.normalized * knockBackForce;
            rb.AddForce(difference, ForceMode2D.Force);
            // StartCoroutine(Hitstop());
        }
    }

    public void Death()
    {
        Debug.Log("Dead");
        GameObject.FindGameObjectWithTag("Camera").GetComponent<Animator>().SetTrigger("Hard_Shake");
        GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().IncreaseEnemyKillCount();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    //IEnumerator Hitstop()

    //{

    //   // Time.timeScale = 0f;

    //   // float RealTimeOfTimestopStart = Time.realtimeSinceStartup;

    //   // float lengthOfTimestop = 5f / 60f;

    //   // //while (Time.realtimeSinceStartup < RealTimeOfTimestopStart + lengthOfTimestop)

    //   // //{

    //   // //    //  yield return new WaitForSeconds(lengthOfTimestop);
    //   // //    yield return null;
    //   // //}
    //   // while (int i = 5; int )

    //   // Time.timeScale = 1f;

    //   //// Time.timeScale = FindObjectOfType<GameManager>().GetTimeScale();

    //}

    public bool Hurting()
    {
        return hurting;
    }

    public bool IsDead()
    {
        return hasDied;
    }
}
