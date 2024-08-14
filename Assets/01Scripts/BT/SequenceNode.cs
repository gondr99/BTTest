using UnityEngine;

namespace BT
{
    public class SequenceNode : CompositeNode
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
                    return NodeState.FAILURE;
                case NodeState.SUCCESS:
                    _currentChildIdx++; //다음차일드
                    break;
            }

            //모든 차일드가 성공적으로 수행되었다면 Success 아니면 running
            return _currentChildIdx == children.Count ? NodeState.SUCCESS : NodeState.RUNNING; 
        }
    }
}

