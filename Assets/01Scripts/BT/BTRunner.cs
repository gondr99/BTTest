using System.Collections.Generic;
using BT;
using UnityEngine;

public class BTRunner : MonoBehaviour
{
    private BehaviourTree _tree;

    private void Start() {
        _tree = new BehaviourTree();

        DebugNode seq1Debug = new DebugNode();
        seq1Debug.message = "Sequnce1";
        DebugNode seq2Debug = new DebugNode();
        seq2Debug.message = "Sequnce2";
        DebugNode seq3Debug = new DebugNode();
        seq3Debug.message = "Sequnce3";

        WaitNode wait = new WaitNode();
        wait.waitTime = 1f;
        

        SequenceNode waitSeq = new SequenceNode();
        waitSeq.children = new List<Node>{
            seq1Debug, wait, seq2Debug, wait, seq3Debug
        };


        RepeatNode repeatNode = new RepeatNode();
        repeatNode.child = waitSeq;
        repeatNode.repeatCount = 3;

        _tree.rootNode = repeatNode;
    }

    private void Update() {
        _tree.Update();
    }
}
