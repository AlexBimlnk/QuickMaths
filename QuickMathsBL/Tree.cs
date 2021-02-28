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
        public SimpleFunction DataRoot { get; set; }

        public Tree(SimpleFunction _data)
        {
            RootNode = new Node(_data);
            DataRoot = _data;
        }

        public void Add(SimpleFunction _data)
        {
            RootNode.Add(_data);
        }
    }
}
