using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuickMaths.General.Abstractions;

namespace QuickMaths.General.DataStructure.Nodes;

internal interface INode
{
    public double Calculate();

    public IArithmeticable GetDerivative();

    public void SetVariables(Dictionary<string, double> variables);

    public int GetPriority();
}
