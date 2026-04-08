// -----------------------------------------------------------------------
// <copyright file="Ref.cs" company="TedToolkit">
// Copyright (c) TedToolkit. All rights reserved.
// Licensed under the LGPL-3.0 license. See COPYING, COPYING.LESSER file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Runtime.CompilerServices;

namespace TedToolkit.Refly;

/// <summary>
/// A heap-allocated wrapper that holds a mutable reference to a struct value.
/// </summary>
/// <typeparam name="TStruct">The type of the struct to wrap.</typeparam>
/// <param name="value">The struct value to wrap.</param>
public sealed class Ref<TStruct>(scoped in TStruct value)
    where TStruct : struct
{
    private TStruct _value = value;

    /// <summary>
    /// Gets a mutable reference to the wrapped struct value.
    /// </summary>
    public ref TStruct Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref _value;
        }
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string? ToString()
    {
        return _value.ToString();
    }
}