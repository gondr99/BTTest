using UnityEngine;

namespace BT
{
    public class DebugNode : ActionNode
    {
        public string message;

        public override void OnStart()
        {
            Debug.Log($"Start : {message}");
        }

        public override NodeState OnUpdate()
        {
            Debug.Log($"Update : {message}");
            return NodeState.SUCCESS;
        }

        public override void OnStop()
        {
            Debug.Log($"End : {message}");
        }
    }

}
