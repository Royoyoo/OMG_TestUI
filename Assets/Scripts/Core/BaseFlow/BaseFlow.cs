using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.BaseFlow
{
    public class BaseFlow
    {
        private List<FlowState> allStates = new();
        private FlowState currentState;
        private FlowState entryState;


        public virtual void Dispose()
        {
            foreach (FlowState state in allStates)
            {
                state.OnTransitionRequested -= ExecuteTransition;
            }

            allStates = new List<FlowState>();
            currentState = null;
            entryState = null;
        }


        public void Run()
        {
            currentState = entryState;
            entryState.OnEnter();
        }


        public void Stop()
        {
            currentState.OnExit();
        }


        public void ExecuteTransition(string transitionKey)
        {
            KeyValuePair<string, FlowState> targetTransition =
                currentState.Transitions.FirstOrDefault(transition => string.Equals(transition.Key, transitionKey));

            FlowState targetState = targetTransition.Value;

            if (targetState == null)
            {
                throw new Exception($"State {currentState} has no transition with key {transitionKey}");
            }

            DoTransition(targetState);
        }


        protected T CreateState<T>() where T : FlowState, new()
        {
            T state = new T();

            state.OnTransitionRequested += ExecuteTransition;

            allStates.Add(state);

            return state;
        }


        protected void SetEntryState(FlowState state)
        {
            entryState = state;
        }


        private void DoTransition(FlowState toState)
        {
            currentState.OnExit();
            currentState = toState;
            toState.OnEnter();
        }
    }
}
