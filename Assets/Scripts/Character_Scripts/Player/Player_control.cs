using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour
{
    [Header("补偿速度")]
    public float lightSpeed;
    public float heavySpeed;
    private float filp = 1;
    [Space]

    [Header("打击感")]
    public float shakeTime;
    public int lightPause;
    public float lightStrength;
    public int heavyPause;
    public float heavyStrength;

   


    private int comboStep;
    public float interval=2f;
    private float timer;
    private static bool isAttack;
    private string attackType;


    public float runSpeed = 5f;
    private Rigidbody2D rigidPlay;
    private Animator animPlay;


    

    
    // Start is called before the first frame update
    void Start()
    {
        rigidPlay = GetComponent<Rigidbody2D>();
        animPlay = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        Run();
        Attack();

    }

   
    void Run()
    {
        if (!isAttack)
        {
            
            float move = Input.GetAxis("Horizontal");
            Vector2 playerVel = new Vector2(move * runSpeed, rigidPlay.velocity.y);
            rigidPlay.velocity = playerVel;
        }
        else
        {
            
            if (attackType=="Light")
            {
                rigidPlay.velocity=new Vector2(transform.localScale.x*lightSpeed*filp, rigidPlay.velocity.y);   
            }else if(attackType=="Heavy")
            {
                rigidPlay.velocity = new Vector2(transform.localScale.x * heavySpeed*filp, rigidPlay.velocity.y);
            }

        }
            
            bool playRunState = Mathf.Abs(rigidPlay.velocity.x) > Mathf.Epsilon;
            animPlay.SetBool("run", playRunState);

        
    }

    void Attack()
    {  

        //轻攻击
        if(Input.GetKeyDown(KeyCode.J)&&!isAttack)
        {
            isAttack = true;
            attackType = "Light";
            comboStep++;
            if(comboStep>2)
            {
                comboStep = 1;
            }
            timer = interval;
            animPlay.SetTrigger("LightAttack");
            animPlay.SetInteger("ComboStep",comboStep);
            
        }

        if (Input.GetKeyDown(KeyCode.K) && !isAttack)
        {
            isAttack = true;
            attackType = "Heavy";
            comboStep++;
            if (comboStep > 1)
            {
                comboStep = 1;
            }
            timer = interval;
            animPlay.SetTrigger("HeavyAttack");
            animPlay.SetInteger("ComboStep", comboStep);

        }

        if (timer!=0)
        {
            timer-=Time.deltaTime;
            if(timer<=0)
            {
                timer = 0;
                comboStep = 0;
            }
        }
    }

    void AttackOver()
    {
        isAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
          if(collision.CompareTag("Enemy"))
        {  
            if(attackType=="Light")
            {
                AttackScence.GetInstance().HitPause(lightPause);
                AttackScence.GetInstance().CameraShake(shakeTime, lightStrength);
            }else if(attackType=="Heavy")
            {
                AttackScence.GetInstance().HitPause(heavyPause);
                AttackScence.GetInstance().CameraShake(shakeTime, heavyStrength);
            }


            if(filp==1)
            {
                collision.GetComponent<Enemy_godlin>().GetHit(Vector2.right);
            }else if(filp==-1)
            {
                collision.GetComponent<Enemy_godlin>().GetHit(Vector2.left);
            }
        }
    }

    void Flip()
    {
        bool playRunState = Mathf.Abs(rigidPlay.velocity.x) > Mathf.Epsilon;
        if (playRunState)
        {
            if (rigidPlay.velocity.x > 0.01f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                filp = 1;
            }
            if (rigidPlay.velocity.x < -0.01f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                filp = -1;
            }
        }
    }

}
