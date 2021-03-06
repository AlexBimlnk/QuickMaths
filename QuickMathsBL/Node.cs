using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMathsBL
{
    public class Node
    {

        public Node MultyWay { get; set; }
        public Node PlusWay { get; set; }
        public Tree SubFuncTree { get; set; }
        public SimpleFunction Data { get; set; }
        public Node(SimpleFunction _data)
        {
            Data = _data;
        }

        //TODO
        public void Add(SimpleFunction _data, bool forMultyWay)
        {
            if (forMultyWay)
            {
                if (MultyWay == null)
                    MultyWay = new Node(_data);
                else
                    MultyWay.Add(_data, forMultyWay);
            }
            else
            {
                if (PlusWay == null)
                    PlusWay = new Node(_data);
                else
                    PlusWay.Add(_data, forMultyWay);
            }
        }
    }
}
