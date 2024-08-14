using System.Collections.Generic;

namespace BT
{    
    public abstract class CompositeNode : Node
    {
        public List<Node> children = new List<Node>();
    }
}

