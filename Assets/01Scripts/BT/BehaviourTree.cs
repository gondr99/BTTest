using System;
using System.Collections.Generic;

namespace BT
{
    public class BehaviourTree
    {
        public Node rootNode;
        public NodeState treeState = NodeState.RUNNING;

        private bool _isEnd = false;

        public NodeState Update()
        {
            if(_isEnd) return treeState;

            treeState = rootNode.Update();
            if(treeState != NodeState.RUNNING){
                _isEnd = true;
            }
            return treeState;
        }

        public void Traverse(Node node, Action<Node> visitor)
        {
            //노드를 순회하면서 각 노드들을 tree.nodes 리스트에 넣어주는 함수
            if (node != null)
            {
                visitor.Invoke(node);
                var children = GetChildren(node);
                children.ForEach(n => Traverse(n, visitor));
            }
        }

        public List<Node> GetChildren(Node parent)
        {
            List<Node> children = new List<Node>();
            
            var composite = parent as CompositeNode;
            if (composite != null) //콤포짓 노드라면
            {
                return composite.children;
            }
            
            var decorator = parent as DecoratorNode;
            if (decorator != null && decorator.child != null) //데코레이터 노드라면
            {
                children.Add(decorator.child);
            }
            return children;
        }
    }

}