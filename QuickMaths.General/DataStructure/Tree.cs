using QuickMaths.General.Abstractions;
using QuickMaths.General.DataStructure.Nodes;
using QuickMaths.General.Enums;

namespace QuickMaths.General.DataStructure;

public class Tree
{
    /*public Tree(IArithmeticable arithmeticElement) => 
        Head = new ArithmeticNode(arithmeticElement ?? throw new ArgumentNullException(nameof(arithmeticElement)));

    internal INode Head { get; private set; }

    public void AddArithmeticElement(ArithmeticOperator @operator, IArithmeticable arithmeticElement)
    {
        var nodeForConnect = new ArithmeticNode(arithmeticElement ?? throw new ArgumentNullException(nameof(arithmeticElement)));
        Head = new OperatorNode(@operator, Head, nodeForConnect);
    }

    public void AddArithmeticElement(ArithmeticOperator @operator, Tree tree) => 
        Head = new OperatorNode(@operator, Head, tree?.Head ?? throw new ArgumentNullException(nameof(tree)));*/
}