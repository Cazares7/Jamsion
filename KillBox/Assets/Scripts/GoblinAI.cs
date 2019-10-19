using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAI : MonoBehaviour {
    Rigidbody2D rb;
    public LayerMask enemyLayer;

    int x_input;
    int y_input;

    public float moveSpeed;
    public float attackCircle;
    bool facing_right;
    Animator anim;
    SpriteRenderer sprite;

    bool chasing;
    Transform target;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            float threshold = .5f;
            if (Mathf.Abs(x_input) > threshold || Mathf.Abs(y_input) > threshold)
                anim.SetBool("Moving", true);
            else
                anim.SetBool("Moving", false);

            FollowTarget();
            AttackTarget();
            SetSword();

            if (facing_right)
            {
                sprite.flipX = false;
            }
            else if (!facing_right)
            {
                sprite.flipX = true;
            }
        }
    }

    public void PressRight()
    {
        x_input = 1;
        y_input = 0;
        rb.velocity = new Vector2(moveSpeed, 0);
        if (!facing_right)
            Flip();
    }
    public void PressDownRight()
    {
        x_input = 1;
        y_input = -1;
        rb.velocity = new Vector2(moveSpeed, -moveSpeed);
        if (!facing_right)
            Flip();
    }
    public void PressDown()
    {
        x_input = 0;
        y_input = -1;
        rb.velocity = new Vector2(0, -moveSpeed);
    }
    public void PressDownLeft()
    {
        x_input = -1;
        y_input = -1;
        rb.velocity = new Vector2(-moveSpeed, -moveSpeed);
    }
    public void PressLeft()
    {
        x_input = -1;
        y_input = 0;
        rb.velocity = new Vector2(-moveSpeed, 0);
    }
    public void PressUpLeft()
    {
        x_input = -1;
        y_input = 1;
        rb.velocity = new Vector2(-moveSpeed, moveSpeed);
    }
    public void PressUp()
    {
        x_input = 1;
        y_input = 0;
        rb.velocity = new Vector2(0, moveSpeed);
    }
    public void PressUpRight()
    {
        x_input = 1;
        y_input = 1;
        rb.velocity = new Vector2(moveSpeed, moveSpeed);
        if (!facing_right)
            Flip();
    }
    public void PressNone()
    {
        x_input = 0;
        y_input = 0;
    }

    void Flip()
    {
        facing_right = !facing_right;
    }

    void FollowTarget()
    {
        if (target.position.x > transform.position.x && target.position.y > transform.position.y)
        {
            PressUpRight();
        }
        if (target.position.x > transform.position.x && target.position.y == transform.position.y)
        {
            PressRight();
        }
        if (target.position.x > transform.position.x && target.position.y < transform.position.y)
        {
            PressDownRight();
        }
        if (target.position.x == transform.position.x && target.position.y < transform.position.y)
        {
            PressDown();
        }
        if (target.position.x < transform.position.x && target.position.y < transform.position.y)
        {
            PressDownLeft();
        }
        if (target.position.x < transform.position.x && target.position.y == transform.position.y)
        {
            PressLeft();
        }
        if (target.position.x < transform.position.x && target.position.y > transform.position.y)
        {
            PressUpLeft();
        }
        if (target.position.x == transform.position.x && target.position.y > transform.position.y)
        {
            PressUp();
        }
    }

    void SetSword()
    {
        Vector2 vector = new Vector2(x_input, y_input);
        GetComponent<SwordAttack>().SetDirection(vector);
    }

    void AttackTarget()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, attackCircle, enemyLayer);

        if (hit)
        {
            GetComponent<SwordAttack>().Attack();
        }
    }
}
