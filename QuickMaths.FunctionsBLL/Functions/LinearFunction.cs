using System.Text;

namespace QuickMaths.FunctionsBLL.Functions;

/// <summary>
/// Линейная функция.
/// <list type="bullet">
///     <item>
///         <term>x</term>
///         <description>Является линейной функцией.</description>
///     </item>
///     <item>
///         <term>4*y</term>
///         <description>Является линейной функцией.</description>
///     </item>
/// </list>
/// </summary>
public class LinearFunction : IFunction
{
    private string _stringFunction = string.Empty;


    public LinearFunction(IFunction argument) => Argument = argument ?? throw new ArgumentNullException(nameof(argument));
    public LinearFunction(IFunction argument, IFunction koef)
    {
        Argument = argument ?? throw new ArgumentNullException(nameof(argument));
        Koef = koef ?? throw new ArgumentNullException(nameof(koef));
    }
    public LinearFunction(string stringFunction, IFunction argument, IFunction? koef = null)
    {
        Argument = argument ?? throw new ArgumentNullException(nameof(argument));
        Koef = koef ?? new NumberFunction(1);
        _stringFunction = stringFunction;
    }


    public IFunction Koef { get; init; } = new NumberFunction(1);
    public IFunction Argument { get; init; }


    public double Calculate() => throw new NotImplementedException();
    public IFunction Derivative() => throw new NotImplementedException();

    public override bool Equals(object? obj)
    {
        if (obj is IFunction function)
            return Equals(function);
        return false;
    }
    public bool Equals(IFunction? other) => other is LinearFunction linearFunction && 
        Koef.Equals(linearFunction.Koef) && Argument.Equals(linearFunction.Argument);
    public override int GetHashCode() => HashCode.Combine(_stringFunction, Koef, Argument);
    public override string ToString() //Todo: ToString in LF
    {
        if (_stringFunction == String.Empty)
        {
            var strFuncBuilder = new StringBuilder();


        }

        return _stringFunction;
    }
}
