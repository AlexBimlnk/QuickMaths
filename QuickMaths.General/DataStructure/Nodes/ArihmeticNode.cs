using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuickMaths.General.Abstractions;

namespace QuickMaths.General.DataStructure.Nodes;

internal class ArihmeticNode : INode
{
    private IArithmeticable _arithmeticElement;

    public ArihmeticNode(IArithmeticable arithmeticElement)
    {
        if (arithmeticElement is null)
        {
            throw new ArgumentNullException("Arihmetic element cat'be null");
        }

        _arithmeticElement = arithmeticElement;
    }

    public double Calculate() => throw new NotImplementedException();
    public IArithmeticable GetDerivative() => throw new NotImplementedException();
    public int GetPriority() => 3;
    public void SetVariables(Dictionary<string, double> variables) => throw new NotImplementedException();

    public override string ToString() => _arithmeticElement.ToString();
}
