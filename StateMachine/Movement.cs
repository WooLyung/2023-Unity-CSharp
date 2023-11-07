using UnityEngine;

public class Movement : MonoBehaviour
{
    public void Move()
    {
        transform.Translate(Vector3.right * Time.deltaTime);
    }
}

public class IdleState : MyStateMachine.State
{
    private float time = 0;
    private Movement movement;

    public IdleState(StateMachine<MyStateMachine.State> stateMachine,
        Movement movement) : base(stateMachine)
        => this.movement = movement;

    public override void Update()
    {
        time += Time.deltaTime;
        if (time > 1)
            stateMachine.CurrState = new MoveState(stateMachine, movement);
    }
}

public class MoveState : MyStateMachine.State
{
    private float time = 0;
    private Movement movement;

    public MoveState(StateMachine<MyStateMachine.State> stateMachine,
        Movement movement) : base(stateMachine)
        => this.movement = movement;

    public override void Update()
    {
        movement.Move();
        time += Time.deltaTime;
        if (time > 1)
            stateMachine.CurrState = new IdleState(stateMachine, movement);
    }
}