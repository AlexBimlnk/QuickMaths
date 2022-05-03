using QuickMaths.FunctionsBLL.DataStructure;

namespace QuickMaths.FunctionsBLL.Functions;

//TODO: Класс "Функция"
/// <summary>
/// Составная функция.
/// </summary>
public class CompositeFunction : IFunction
{
    private Tree _functionTree = null!;


    internal CompositeFunction(Tree? tree) => _functionTree = tree ?? throw new ArgumentNullException(nameof(tree));
    public CompositeFunction(string? function)
    {
        if (string.IsNullOrEmpty(function))
            throw new ArgumentException(null, nameof(function));

        //TODO Рефакторинг ошибки
        //Либо уберем после рефакторинга возможность возраста null дерева в билдере
        //Или делаем свой кастомный эксепшен
        _functionTree = TreeBuilder.BuildTree(function) ?? throw new ArgumentNullException();
    }


    /// <inheritdoc/>
    public double Calculate() => throw new NotImplementedException();
    public IFunction Derivative() => new CompositeFunction(_functionTree.GetDerivative());
    public override bool Equals(object? obj)
    {
        if (obj is IFunction function)
            return Equals(function);
        return false;
    }
    public bool Equals(IFunction? other) => throw new NotImplementedException();
    public override int GetHashCode() => throw new NotImplementedException();
    public override string ToString() => $"({_functionTree})";
}
