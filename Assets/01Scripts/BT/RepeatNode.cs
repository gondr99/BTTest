namespace BT
{
    public class RepeatNode : DecoratorNode
    {
        public int repeatCount;
        private int _currentRepeat;
        public override void OnStart()
        {
            _currentRepeat = 0;
        }

        public override void OnStop()
        {
            
        }

        public override NodeState OnUpdate()
        {
            NodeState childState = child.Update();
            _currentRepeat++;

            if(childState != NodeState.RUNNING){
                if(repeatCount > 0 && _currentRepeat > repeatCount) {
                    return NodeState.SUCCESS;
                }
            }
            return NodeState.RUNNING;
        }
    }
}
