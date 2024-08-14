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
            Debug.Log($"대기 시작 : {waitTime}");
        }

        public override void OnStop()
        {
            Debug.Log("대기 끝");
        }

        public override NodeState OnUpdate()
        {
            if(_startTime + waitTime < Time.time) 
                return NodeState.SUCCESS;
            
            return NodeState.RUNNING;
        }
    }

}
