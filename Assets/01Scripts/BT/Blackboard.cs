using System;
using UnityEngine;
using UnityEngine.AI;

namespace BT
{
    [Serializable]
    public class Blackboard
    {
        public Transform transform;
        public NavMeshAgent agent;
        public LayerMask whatIsEnemy;
        public Transform target;
    }

}
