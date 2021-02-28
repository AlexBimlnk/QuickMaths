using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMathsBL
{
    public class Node
    {

        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public SimpleFunction Data { get; set; }
        public Node(SimpleFunction _data)
        {
            Data = _data;
        }

        //TODO
        public void Add(SimpleFunction _data)
        {
            
        }
    }
}
