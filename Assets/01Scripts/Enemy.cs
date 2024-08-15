using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent Agent{get; private set;}
    [SerializeField] private List<Transform> _checkPoints;
    private int _checkPointIdx;
    
    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        BehaviorTree  tree = GetComponent<BehaviorTree>();
        SharedEnemy enemy = tree.GetVariable("Enemy") as SharedEnemy;

        enemy.Value = this;
    }

    public Vector3 GetNextCheckPoint()
    {
        _checkPointIdx++;
        if(_checkPointIdx >= _checkPoints.Count) 
        {
            _checkPointIdx = 0;
        }
        Debug.Log(_checkPointIdx);
        return _checkPoints[_checkPointIdx].position;
    }
}
