using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class CheckEnemyInRadius : Conditional
{
    public SharedLayerMask whatIsEnemy;
    public SharedTransform target;
    public SharedFloat sightRange;

    public int maxCollider = 1;

    private Collider[] _colliders;

    public override void OnAwake()
    {
        _colliders = new Collider[maxCollider];
    }

    public override TaskStatus OnUpdate()
    {
        int cnt = Physics.OverlapSphereNonAlloc(transform.position, sightRange.Value, _colliders, whatIsEnemy.Value);

        if(cnt > 0)
            return TaskStatus.Success;
        else 
            return TaskStatus.Failure;
    }
}
