namespace  BT
{
    public enum NodeState
    {
        SUCCESS = 1, FAILURE = 2, RUNNING = 3
    }

    public abstract class Node 
    {
        protected NodeState _nodeState;
        public NodeState NodeState => _nodeState;
        public Blackboard blackboard;

        protected bool _isStarted = false;

        public Node()
        {
            OnAwake();
        }

        public NodeState Update()
        {
            if(!_isStarted) {
                OnStart();
                _isStarted = true;
            }

            _nodeState = OnUpdate();

            if(_nodeState == NodeState.FAILURE || _nodeState == NodeState.SUCCESS) 
            {
                OnStop();
                _isStarted = false;
            }

            return _nodeState;
        }

        public virtual void OnAwake(){

        }

        public abstract NodeState OnUpdate();
        public abstract void OnStart();
        public abstract void OnStop();

    }
}
