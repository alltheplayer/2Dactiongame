using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_godlin : MonoBehaviour
{

    public float speed;
    public float health;
    public float damage;
    private Vector2 direction;
    private bool ishit;


    private AnimatorStateInfo info;
    private Animator animator;

     private Rigidbody2D rid;

    // Start is called before the first frame update
    void Start()
    {
        rid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        info = animator.GetCurrentAnimatorStateInfo(0);
        if (ishit)
        {
            rid.velocity = direction * speed;
            if(info.normalizedTime>=0.6f)
            {
                ishit = false;
            }
        }
        if(health<0)
        {
            animator.SetTrigger("die");          
        }

    }
    public void GetHit(Vector2 direction)
    {
        transform.localScale = new Vector3(-direction.x*5, 5, 5);
        ishit= true;
        health -= damage;
        this.direction = direction;
        animator.SetTrigger("hit");
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
