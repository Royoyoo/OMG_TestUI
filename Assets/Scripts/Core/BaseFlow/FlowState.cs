using System;
using System.Collections.Generic;

namespace Core.BaseFlow
{
    [Serializable]
    public class FlowState
    {
        public event Action<string> OnTransitionRequested;

        private List<KeyValuePair<string, FlowState>> transitions = new();

        public IReadOnlyList<KeyValuePair<string, FlowState>> Transitions => transitions;


        public virtual void OnEnter() { }


        public virtual void OnExit() { }


        public void AddTransition(string transitionKey, FlowState targetState)
        {
            transitions.Add(new KeyValuePair<string, FlowState>(transitionKey, targetState));
        }


        protected void RequestTransition(string transitionKey)
        {
            OnTransitionRequested?.Invoke(transitionKey);
        }
    }
}
