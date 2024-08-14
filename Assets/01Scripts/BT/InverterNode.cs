namespace BT
{
    public class InverterNode : DecoratorNode
    {
        public override void OnStart()
        {
            
        }

        public override void OnStop()
        {
            
        }

        public override NodeState OnUpdate()
        {
            _nodeState = child.Update();
            
            if(_nodeState == NodeState.SUCCESS)
                _nodeState = NodeState.FAILURE;
            else if(_nodeState == NodeState.FAILURE)
                _nodeState = NodeState.SUCCESS;

            return _nodeState;
        }
    }

}

