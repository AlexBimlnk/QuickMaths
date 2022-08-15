using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuickMaths.General.Enums;

namespace QuickMaths.General.Abstractions;
public interface IArithmeticOperator
{
    /// <summary>
    /// 
    /// </summary>
    public int Priority { get; }
    /// <summary>
    /// 
    /// </summary>
    public bool IsUnary { get; }
    /// <summary>
    /// 
    /// </summary>
    public bool IsBinary { get; }

    /// <summary>
    /// 
    /// </summary>
    public char CharView { get; }

    public bool IsSkipOnBeginInStringView { get; }

}
