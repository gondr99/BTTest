using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class Wandering : Action
{
    public SharedEnemy enemy;

    private Vector3 _destination;
    private NavMeshAgent _agent;

    private bool _isStarted;
    //같은 프레임에서 할당하면 isPathStale이 정상작동 안함.
    public override void OnAwake()
    {
        _agent = enemy.Value.Agent;
    }

    public override void OnStart()
    {
        _destination = enemy.Value.GetNextCheckPoint();
        enemy.Value.Agent.SetDestination(_destination);
        _isStarted = true;
    }

    public override TaskStatus OnUpdate()
    {
        if(_isStarted ){
            _isStarted = false;
            return TaskStatus.Running;
        }
        float threshold = _agent.stoppingDistance + 0.1f;
        
        if(!_agent.isPathStale && _agent.remainingDistance < threshold) 
        {
            Debug.Log("완료");
            return TaskStatus.Success;
        }
        return TaskStatus.Running;
    }
}
