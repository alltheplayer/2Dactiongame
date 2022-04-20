using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_animation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    int fallID;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        fallID = Animator.StringToHash("Veloctiy");
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat(fallID, rb.velocity.y);
    }
}
