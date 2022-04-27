using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{ 
    Idle,Run,Chase,Attack,Gethit,Die
}

[Serializable]
public class Parameter
{
    public int health;
    public float moveSpeed;
    public float chaseSpeed;
    public float idleTime;
    public Transform[] patrolPoints;
    public Transform[] chasePoints;
    public Transform target;
    public LayerMask layerMask;
    public Transform circle_AttackPoint;
    public float attackarea;
    public Animator animator;
    public float attacktime;
    public bool gethit;
    public Vector2 direction;
    public Rigidbody2D rid;
}

public class FSM : MonoBehaviour
{   
    public Parameter parameter;
    private IState currentState;
    private Dictionary<StateType,IState> states=new Dictionary<StateType,IState>();


     void Start()
    {
        states.Add(StateType.Idle, new IdleState(this));
        states.Add(StateType.Run, new RunState(this));
        states.Add(StateType.Attack, new AttackState(this));
        states.Add(StateType.Gethit, new GethitState(this));
        states.Add(StateType.Chase, new ChaseState(this));  
        states.Add(StateType.Die, new DieState(this));
        parameter.animator = GetComponent<Animator>();
        parameter.rid = GetComponent<Rigidbody2D>();
        TranstionState(StateType.Idle);

        
    }

     void Update()
    {
        currentState.OnUpdate();
    }

    public void TranstionState(StateType type)
    {
        if(currentState!=null)
        {
            currentState.OnExit();
        }
        currentState=states[type];
        currentState.OnEnter();
    }

    public void FlipTo(Transform target)
    {
        if(target!=null)
        {
            if(transform.position.x>target.position.x)
            {
                transform.localScale=new Vector3(-5,5,5);
            }else if(transform.position.x < target.position.x)
            {
                transform.localScale = new Vector3(5, 5, 5);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("¹¥»÷");
            parameter.target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            parameter.target = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(parameter.circle_AttackPoint.position, parameter.attackarea);
    }


    public void GetHit(Vector2 direction,int damage)
    {
        transform.localScale = new Vector3(-direction.x * 5, 5, 5);
        parameter.gethit = true;
        parameter.health -= damage;
        parameter.direction = direction;
    }
}
