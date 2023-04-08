using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMaths.General.Abstractions;

/// <summary>
/// Базовый класс парсера.
/// </summary>
/// <typeparam name="TEntity">
/// Сущность, которую парсер должен вернуть после разбора строки.
/// </typeparam>
public abstract class ParserBase<TEntity>
{
    // Вариативно, сигнатура может быть другая
    // Метод разбивающий строку по операторам общий для всех парсеров
    protected void SplitOnOperators() => throw new NotImplementedException();

    /// <summary>
    /// Создает дерево выражений с сущностями типа <typeparamref name="TEntity"/> по входной строке.
    /// </summary>
    /// <param name="input">
    /// Входная строка, которую нужно распарсить.
    /// </param>
    /// <returns>
    /// Дерево выражений, наполненное сущностями типа <typeparamref name="TEntity"/>.
    /// </returns>
    /// <exception cref="FormatException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract ITreeExpression<TEntity> BuildExpression(string input);

    /// <summary>
    /// Разбирает входную строку и пытается привести её к объекту типа <typeparamref name="TEntity"/>.
    /// </summary>
    /// <param name="inputString">
    /// Входная строка, которую нужно распарсить.
    /// </param>
    /// <returns>
    /// Объект типа <typeparamref name="TEntity"/>.
    /// </returns>    
    /// <exception cref="FormatException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract TEntity Parse(string inputString);

    /// <summary>
    /// Разбирает входную строку и пытается привести её к объекту типа <typeparamref name="TEntity"/>.
    /// Не генерирует исключений, сообщая результат попытки конвертации.
    /// </summary>
    /// <param name="inputString">
    /// Входная строка, которую нужно распарсить.
    /// </param>
    /// <param name="result">
    /// Объектом типа <typeparamref name="TEntity"/>, являющийся результатом парсинга.
    /// </param>
    /// <returns>
    /// <see langword="true"/> если операция успешно выполнена, 
    /// <see langword="false"/> когда конвертирование не удалось.
    /// </returns>
    public abstract bool TryParse(string inputString, out TEntity result);

    /// <summary>
    /// Асинхронно разбирает входную строку и пытается привести её к объекту типа <typeparamref name="TEntity"/>.
    /// </summary>
    /// <param name="inputString">
    /// Входная строка, которую нужно распарсить.
    /// </param>  
    /// <param name="token">
    /// Токен отмены операции.
    /// </param>
    /// <returns>
    /// Задача типа <see cref="Task{TResult}"/>, результат которой
    /// является объект типа <typeparamref name="TEntity"/>.
    /// </returns>
    /// <exception cref="FormatException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="OperationCanceledException"/>
    public abstract Task<TEntity> ParseAsync(string inputString, CancellationToken token);
}
