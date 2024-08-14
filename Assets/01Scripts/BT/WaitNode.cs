using UnityEngine;
namespace BT
{
    public class WaitNode : ActionNode
    {
        public float waitTime;
        private float _startTime;

        public override void OnStart()
        {
            _startTime = Time.time;
        }

        public override void OnStop()
        {
            
        }

        public override NodeState OnUpdate()
        {
            if(_startTime + waitTime < Time.time) 
                return NodeState.SUCCESS;
            
            return NodeState.RUNNING;
        }
    }

}
