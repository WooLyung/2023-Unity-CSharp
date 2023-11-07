using UnityEngine;

public class MyStateMachine 
    : StateMachine<MyStateMachine.State>
{
    public abstract class State : StateMachine<State>.State
    {
        public State(StateMachine<State> stateMachine) 
            : base(stateMachine) { }
        public override void Start() { }
        public override void Finish() { }
        public abstract void Update();
    }

    [SerializeField]
    private Movement movement;

    public void Start()
        => CurrState = new IdleState(this, movement);
    public void Update() 
        => CurrState?.Update();
}
