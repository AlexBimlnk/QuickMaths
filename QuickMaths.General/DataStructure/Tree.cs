using QuickMaths.General.Abstractions;
using QuickMaths.General.DataStructure.Nodes;
using QuickMaths.General.Enums;

namespace QuickMaths.General.DataStructure;

public class Tree
{
    private INode _head;

    public Tree(IArithmeticable arithmeticElement) => 
        _head = new ArihmeticNode(arithmeticElement ?? throw new ArgumentNullException(nameof(arithmeticElement)));

    public void AddAriphmeticElement(MathOperator @operator, IArithmeticable arithmeticElement)
    {
        var nodeForConnect = new ArihmeticNode(arithmeticElement ?? throw new ArgumentNullException(nameof(arithmeticElement)));

        _head = new OperatorNode(@operator, _head, nodeForConnect);
    }

    public void SetHeadElement(IArithmeticable arihmeticElement) => 
        _head = new ArihmeticNode(arihmeticElement ?? throw new ArgumentNullException(nameof(arihmeticElement)));
}