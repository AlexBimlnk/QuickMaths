using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMathsBL
{
    public class Node
    {
        public enum Branch
        {
            Left,
            Right
        }

        public SimpleFunction ThisNode { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public string Data { get; set; }

        public Node(SimpleFunction _node)
        {
            ThisNode = _node;
        }

        //TODO
        public void Add(SimpleFunction _node, string _data)
        {
            
        }
    }
}
