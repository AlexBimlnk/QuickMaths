using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMaths.BL
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

        //TODO: Доделать "узел" дерева, уже не помню что тут делать надо, но метка стояла
        public void Add(Node _data, bool forMultyWay)
        {
            if (forMultyWay)
            {
                if (MultyWay == null)
                    MultyWay = _data;
                else
                    MultyWay.Add(_data, forMultyWay);
            }
            else
            {
                if (PlusWay == null)
                    PlusWay = _data;
                else
                    PlusWay.Add(_data, forMultyWay);
            }
        }
    }
}
