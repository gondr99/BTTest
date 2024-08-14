namespace BT
{
    public class SelectorNode : CompositeNode
    {
        private int _currentChildIdx;

        public override void OnStart()
        {
            _currentChildIdx = 0;  
        }

        public override void OnStop()
        {
            
        }

        public override NodeState OnUpdate()
        {
            var child = children[_currentChildIdx];
            
            switch (child.Update())
            {
                case NodeState.RUNNING:
                    return NodeState.RUNNING;
                case NodeState.FAILURE :
                    _currentChildIdx++; //다음차일드
                    break;
                case NodeState.SUCCESS:
                    return NodeState.SUCCESS;
            }

            //맨 끝까지와도 Success를 리턴하지 못했다면 FAIL, 그렇지 않다면 Running
            return _currentChildIdx == children.Count ? NodeState.FAILURE : NodeState.RUNNING; 
        }
    }

}
