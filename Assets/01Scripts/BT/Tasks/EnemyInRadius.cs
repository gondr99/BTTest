using BT;
using UnityEngine;

public class EnemyInRadius : ConditionNode
{
    public float radius;
    private Collider[] _colliders;

    public override void OnAwake()
    {
        _colliders = new Collider[1];
    }

    public override void OnStart()
    {
        
    }

    public override void OnStop()
    {
    }

    public override NodeState OnUpdate()
    {
        int cnt = Physics.OverlapSphereNonAlloc(blackboard.transform.position, radius, _colliders, blackboard.whatIsEnemy);

        if(cnt > 0)
        {
            blackboard.target = _colliders[0].transform;
            return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }
}
