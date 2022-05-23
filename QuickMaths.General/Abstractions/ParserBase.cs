using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMaths.General.Abstractions;

/// <summary xml:lang = "ru">
/// Базовый класс парсера.
/// </summary>
/// <typeparam name="TEntity" xml:lang = "ru">
/// Сущность, которую парсер должен вернуть после разбора строки.
/// </typeparam>
public abstract class ParserBase<TEntity> where TEntity : IArithmeticable
{
    // Вариативно, сигнатура может быть другая
    // Метод разбивающий строку по операторам общий для всех парсеров
    protected void SplitOnOperators() => throw new NotImplementedException();

    /// <summary xml:lang = "ru">
    /// Разбирает входную строку и пытается привести её к объекту типа <typeparamref name="TEntity"/>.
    /// </summary>
    /// <param name="inputString" xml:lang = "ru">
    /// Входная строка, которую нужно распарсить.
    /// </param>
    /// <exception cref="FormatException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <returns xml:lang = "ru">
    /// Объект типа <typeparamref name="TEntity"/>.
    /// </returns>
    public abstract TEntity Parse(string inputString);

    /// <summary xml:lang = "ru">
    /// Разбирает входную строку и пытается привести её к объекту типа <typeparamref name="TEntity"/>.
    /// Не генерирует исключений, сообщая результат попытки конвертации.
    /// </summary>
    /// <param name="inputString" xml:lang = "ru">
    /// Входная строка, которую нужно распарсить.
    /// </param>
    /// <param name="result" xml:lang = "ru">
    /// Объектом типа <typeparamref name="TEntity"/>, являющийся результатом парсинга.
    /// </param>
    /// <returns xml:lang = "ru">
    /// <see langword="true"/> если операция успешно выполнена, 
    /// <see langword="false"/> когда конвертирование не удалось.
    /// </returns>
    public abstract bool TryParse(string inputString, out TEntity result);

    /// <summary xml:lang = "ru">
    /// Запускает метод <see cref="Parse(string)"/>, передавая ему входную строку, на пуле потоков.
    /// </summary>
    /// <param name="inputString" xml:lang = "ru">
    /// Входная строка, которую нужно распарсить.
    /// </param>
    /// <param name="token" xml:lang = "ru">
    /// Токен отмены операции.
    /// </param>
    /// <returns xml:lang = "ru">
    /// Задача типа <see cref="Task{TResult}"/>.
    /// </returns>
    public virtual Task<TEntity> ParseAsync(string inputString, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        return Task.Run(() => Parse(inputString));
    }
}
