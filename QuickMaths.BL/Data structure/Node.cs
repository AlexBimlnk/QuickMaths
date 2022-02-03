using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMaths.BL.Functions;
using QuickMaths.BL.Enums;

namespace QuickMaths.BL.DataStructure
{
    public class Node
    {
        public Node MultiplyWay { get; set; }
        public Node PlusWay { get; set; }
        public IFunction Data { get; set; }


        public Node(IFunction data)
        {
            Data = data;
        }

        public void Add(Node _data, NodeWayType wayType)
        {
            if (wayType == NodeWayType.MultiplyWay)
            {
                if (MultiplyWay == null)
                    MultiplyWay = _data;
                else
                    MultiplyWay.Add(_data, NodeWayType.MultiplyWay);
            }
            else
            {
                if (PlusWay == null)
                    PlusWay = _data;
                else
                    PlusWay.Add(_data, NodeWayType.PlusWay);
            }
        }
    }
}
