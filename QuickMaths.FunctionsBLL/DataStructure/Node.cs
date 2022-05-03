using QuickMaths.FunctionsBLL.Enums;
using QuickMaths.FunctionsBLL.Functions;

namespace QuickMaths.FunctionsBLL.DataStructure;

internal class Node
{
    public Node(IFunction data)
    {
        Data = data ?? throw new ArgumentNullException(nameof(data));
        Size = 1;
    }


    public Node? MultiplyWay { get; set; }
    public Node? PlusWay { get; set; }
    public IFunction Data { get; set; }
    public int Size { get; private set; }


    public void Add(Node data, NodeWayType wayType)
    {
        if (wayType == NodeWayType.MultiplyWay)
        {
            if (MultiplyWay is null)
                MultiplyWay = data;
            else
                MultiplyWay.Add(data, NodeWayType.MultiplyWay);
        }
        else
        {
            if (PlusWay is null)
                PlusWay = data;
            else
                PlusWay.Add(data, NodeWayType.PlusWay);
        }
        Size = 1 + ((MultiplyWay is null) ? 0 : MultiplyWay.Size) + ((PlusWay is null) ? 0 : PlusWay.Size);
    }
}
