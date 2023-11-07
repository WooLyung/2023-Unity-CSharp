public abstract class StateMachine<T> where T : StateMachine<T>.State
{
    private T? state;

    public abstract class State
    {
        protected StateMachine<T> stateMachine;
        public State(StateMachine<T> stateMachine) => this.stateMachine = stateMachine;
        public abstract void Start();
        public abstract void Finish();
    }

    public T CurrState
    {
        get => state;
        set
        {
            state?.Finish();
            state = value;
            state.Start();
        }
    }
}

public class MyStateMachine : StateMachine<MyStateMachine.State>
{
    public abstract class State : StateMachine<State>.State
    {
        public State(StateMachine<State> stateMachine) : base(stateMachine) { }
        public override abstract void Start();
        public override abstract void Finish();
        public abstract void Update();
    }

    public void Update() => CurrState?.Update();
}

public class StateA : MyStateMachine.State
{
    public StateA(MyStateMachine stateMachine) : base(stateMachine) { }
    public override void Start() => Console.WriteLine("StateA : Start");
    public override void Finish() => Console.WriteLine("StateA : Finish");
    public override void Update() => Console.WriteLine("StateA : Update");
}

public class StateB : MyStateMachine.State
{
    public StateB(MyStateMachine stateMachine) : base(stateMachine) { }
    public override void Start() => Console.WriteLine("StateB : Start");
    public override void Finish() => Console.WriteLine("StateB : Finish");
    public override void Update() => Console.WriteLine("StateB : Update");
}

public class Program
{
    public static void Main()
    {
        MyStateMachine stateMachine = new MyStateMachine();
        stateMachine.CurrState = new StateA(stateMachine);
        stateMachine.Update();
        stateMachine.CurrState = new StateB(stateMachine);
        stateMachine.Update();
    }
}