using UnityEngine;

public abstract class StateMachine<T>
    : MonoBehaviour
    where T : StateMachine<T>.State
{
    public abstract class State
    {
        protected StateMachine<T> stateMachine;
        public State(StateMachine<T> stateMachine) 
            => this.stateMachine = stateMachine;
        public abstract void Start();
        public abstract void Finish();
    }

    private T state = null;
    public T CurrState
    {
        get => state; 
        set
        {
            state?.Finish();
            state = value;
            state?.Start();
        }
    }
}
