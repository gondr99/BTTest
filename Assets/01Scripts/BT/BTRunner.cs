using System.Collections.Generic;
using BT;
using UnityEngine;

public class BTRunner : MonoBehaviour
{
    public Blackboard blackboard;

    private BehaviourTree _tree;

    private void Start() {
        _tree = new BehaviourTree();

        
        EnemyInRadius checkInRadius = new EnemyInRadius();
        checkInRadius.radius = 5;
        InverterNode inverter = new InverterNode();
        inverter.child = checkInRadius; //거리체크 반전
        WanderingNode wandering = new WanderingNode();
        SequenceNode wanderingSeq = new SequenceNode();
        wanderingSeq.children = new List<Node>{inverter, wandering};

        EnemyInRadius checkInRadius1 = new EnemyInRadius();
        checkInRadius1.radius = 1; //사거리 1이내
        InverterNode inverter1 = new InverterNode();
        inverter1.child = checkInRadius1;
        WaitNode chaseWait = new WaitNode();
        chaseWait.waitTime = 1f;
        SequenceNode chaseingSeq = new SequenceNode();
        chaseingSeq.children = new List<Node>{inverter1, chaseWait};

        SelectorNode selector = new SelectorNode();
        selector.children = new List<Node>{ wanderingSeq, chaseingSeq};
        

        RepeatNode repeatNode = new RepeatNode();
        repeatNode.child = selector;
        

        _tree.rootNode = repeatNode;

        _tree.Traverse(_tree.rootNode, (node) => {
            node.blackboard = blackboard;
        });
    }

    private void Update() {
        _tree.Update();
    }
}
