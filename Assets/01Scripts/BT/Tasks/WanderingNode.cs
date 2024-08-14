using BT;
using UnityEngine;

public class WanderingNode : ActionNode
{
    private float _startTimr;

    public override void OnStart()
    {
        _startTimr = Time.time;    
        Debug.Log("배회중");
    }

    public override void OnStop()
    {
        Debug.Log("배회 종료");
    }

    public override NodeState OnUpdate()
    {
        if(_startTimr + 1f < Time.time)
        {
            return NodeState.SUCCESS;
        }
        
        return NodeState.RUNNING;
    }
}
