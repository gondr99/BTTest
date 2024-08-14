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
    }

}