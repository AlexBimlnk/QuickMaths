using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMathsBL
{
    public class Tree //where T : IComparable
    {

        public Node RootNode { get; set; }
        public string DataRoot { get; set; }

        public Tree(SimpleFunction _node)
        {
            RootNode = new Node(_node);
            DataRoot = _node.GetKofFunction.ToString();
        }

        public void Add(SimpleFunction _node, string _data)
        {
            RootNode.Add(_node, _data);
        }
    }
}
