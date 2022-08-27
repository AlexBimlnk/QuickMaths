using QuickMaths.FunctionsBLL.Functions;
using QuickMaths.General.Abstractions;

using Xunit;

namespace QuickMaths.FunctionsBLL.Tests.Functions;

public class VariableFunctionTestsData
{
    public static TheoryData<VariableFunction, IFunction, bool> EqualsVFAndOtherFunctionData = new()
    {
        // VariableFunction
        {
            new VariableFunction("x"),
            new VariableFunction("x"),
            true
        },
        {
            new VariableFunction("x", 1),
            new VariableFunction("x", 1),
            true
        },
        {
            new VariableFunction("x", 1),
            new VariableFunction("x", 2),
            false
        },
        {
            new VariableFunction("x1", 1),
            new VariableFunction("x", 1),
            false
        },
        {
            new VariableFunction("x"),
            new VariableFunction("x", 1),
            false
        },
        // LinearFunction
        {
            new VariableFunction("x"),
            new LinearFunction(new VariableFunction("x"), new NumberFunction(1)),
            true
        },
        {
            new VariableFunction("x"),
            new LinearFunction(new VariableFunction("x"), new NumberFunction(2)),
            false
        },
        {
            new VariableFunction("x"),
            new LinearFunction(new VariableFunction("y"), new NumberFunction(1)),
            false
        }
    };
}