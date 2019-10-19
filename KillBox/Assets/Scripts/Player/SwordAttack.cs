using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour {
    Animator anim;
    PlayerControllerTemplate controller;
    public Transform swordPos;

    bool attacking;
    public float attackFrames;
    float attackTimer;

    public bool player = false;

    Vector2 direction;
	// Use this for initialization
	void Start () {
        controller = GetComponent<PlayerControllerTemplate>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!attacking && player)
        UpdateSwordPos(controller.GetDirection());
        else if (!attacking && !player)
        {
            UpdateSwordPos(direction);
        }

        if (player)
        if (Input.GetButtonDown("Attack") && !attacking)
        {
            anim.SetTrigger("Attack");
            attacking = true;
            attackTimer = attackFrames;
        }

        if (attackTimer <= 0)
        {
            attacking = false;
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }
	}

    void UpdateSwordPos(Vector2 vector)
    {
        if (vector != Vector2.zero)
        {
            if (vector.y > 0)
                swordPos.localRotation = Quaternion.Euler(0, 0, 0);
            else if (vector.y < 0)
                swordPos.localRotation = Quaternion.Euler(0, 0, 180);
            else if (vector.y == 0 && vector.x > 0)
                swordPos.localRotation = Quaternion.Euler(0, 0, 270);
            else if (vector.y == 0 && vector.x < 0)
                swordPos.localRotation = Quaternion.Euler(0, 0, 90);
        }
    }

    public void Attack()
    {
        if (!attacking)
        {
            anim.SetTrigger("Attack");
            attacking = true;
            attackTimer = attackFrames;
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackFrames);
       // attacking = false;
    }

    public void SetDirection(Vector2 vector)
    {
        direction = vector;
    }
}
