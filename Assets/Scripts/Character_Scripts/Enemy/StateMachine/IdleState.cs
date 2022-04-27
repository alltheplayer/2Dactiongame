using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private FSM manger;
    private Parameter parameter;

    private float timer;
    public IdleState(FSM manager)
    {
        this.manger = manager;
        this.parameter=manger.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Goblin_idle");
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;

        if(parameter.gethit)
        {
            manger.TranstionState(StateType.Gethit);
        }

        if(parameter.target!= null&&
            parameter.target.position.x>=parameter.chasePoints[0].position.x&&
            parameter.target.position.x<=parameter.chasePoints[1].position.x)
        {
            manger.TranstionState(StateType.Chase);
        }



        if (timer >= parameter.idleTime)
        {
            manger.TranstionState(StateType.Run);
        }
    }


    public void OnExit()
    {
        timer = 0;
    }

    
}


public class RunState : IState
{
    private FSM manger;
    private Parameter parameter;

    private int partrolPosition;

    public RunState(FSM manager)
    {
        this.manger = manager;
        this.parameter = manger.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Goblin_run");
    }

    public void OnUpdate()
    {

        if (parameter.gethit)
        {
            manger.TranstionState(StateType.Gethit);
        }

        manger.FlipTo(parameter.patrolPoints[partrolPosition]);

        manger.transform.position = Vector2.MoveTowards(manger.transform.position,
            parameter.patrolPoints[partrolPosition].position,parameter.moveSpeed*Time.deltaTime);

        if(Vector2.Distance(manger.transform.position,parameter.patrolPoints[partrolPosition].position)<1f)
        {
            manger.TranstionState(StateType.Idle);
        }

        if(parameter.target!=null)
        {
            manger.TranstionState(StateType.Chase);
        }
    }

    public void OnExit()
    {
        partrolPosition++;
        if(partrolPosition>=parameter.patrolPoints.Length)
        {
            partrolPosition = 0;
        }

    }

    
}


public class ChaseState : IState
{
    private FSM manger;
    private Parameter parameter;

    public ChaseState(FSM manager)
    {
        this.manger = manager;
        this.parameter = manger.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Goblin_run");
    }

    public void OnUpdate()
    {
        if (parameter.gethit)
        {
            manger.TranstionState(StateType.Gethit);
        }

        manger.FlipTo(parameter.target);
        if(parameter.target!=null)
        {
            manger.transform.position=Vector2.MoveTowards(manger.transform.position,
                parameter.target.position,parameter.chaseSpeed*Time.deltaTime);
        }
        if(parameter==null||manger.transform.position.x>parameter.chasePoints[0].position.x
            ||manger.transform.position.x<parameter.chasePoints[1].position.x)
        {
            manger.TranstionState(StateType.Idle);
        }
        if (Physics2D.OverlapCircle(parameter.circle_AttackPoint.position, parameter.attackarea, parameter.layerMask))
        {
            manger.TranstionState(StateType.Attack);
        }
    }

    public void OnExit()
    {
        
    }


}


public class AttackState : IState
{
    private FSM manger;
    private Parameter parameter;
    private float timer;

    private AnimatorStateInfo info;

    public AttackState(FSM manager)
    {
        this.manger = manager;
        this.parameter = manger.parameter;
    }
    public void OnEnter()
    {   

        parameter.animator.Play("Goblin_attack1");
    }

    public void OnUpdate()
    {

        if (parameter.gethit)
        {
            manger.TranstionState(StateType.Gethit);
        }

        info = parameter.animator.GetCurrentAnimatorStateInfo(0);
        if(info.normalizedTime>=0.95)
        {
            manger.TranstionState(StateType.Run);
        }
    }

    public void OnExit()
    {
        
    }

    
}

public class GethitState : IState
{
    private FSM manger;
    private Parameter parameter;

    private AnimatorStateInfo info;

    public GethitState(FSM manager)
    {
        this.manger = manager;
        this.parameter = manger.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Goblin_hit");
    }

    public void OnUpdate()
    {
        if (parameter.gethit)
        {
            manger.TranstionState(StateType.Gethit);
        }
        info = parameter.animator.GetCurrentAnimatorStateInfo(0);
      

        if (parameter.gethit)
        {
            parameter.rid.velocity = parameter.direction * 2f;
            if (info.normalizedTime >= 0.6f)
            {
                parameter.gethit = false;
            }
        }

        if (parameter.health<=0)
        {
            manger.TranstionState(StateType.Die);
        }else
        {
            parameter.target = GameObject.FindWithTag("Player").transform;
            if (info.normalizedTime >= 0.95f)
            {
                manger.TranstionState(StateType.Chase);
            }
            
        }
    }

    public void OnExit()
    {
        parameter.gethit = false;
    }


}

public class DieState : IState
{
    private FSM manger;
    private Parameter parameter;

    public DieState(FSM manager)
    {
        this.manger = manager;
        this.parameter = manger.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Godlin_die");
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {

    }


}

