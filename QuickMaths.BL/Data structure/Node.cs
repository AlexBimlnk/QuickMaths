﻿using System;
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
        public Node(IFunction data)
        {
            Data = data;
            Size = 1;
        }


        public Node MultiplyWay { get; set; }
        public Node PlusWay { get; set; }
        public IFunction Data { get; set; }
        public int Size { get; private set; }


        public void Add(Node data, NodeWayType wayType)
        {
            if (wayType == NodeWayType.MultiplyWay)
            {
                if (MultiplyWay == null)
                    MultiplyWay = data;
                else
                    MultiplyWay.Add(data, NodeWayType.MultiplyWay);
            }
            else
            {
                if (PlusWay == null)
                    PlusWay = data;
                else
                    PlusWay.Add(data, NodeWayType.PlusWay);
            }
            Size = 1 + ((MultiplyWay == null)? 0: MultiplyWay.Size) + ((PlusWay == null)? 0: PlusWay.Size);
        }
    }
}
