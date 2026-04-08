// -----------------------------------------------------------------------
// <copyright file="DisposableRef.cs" company="TedToolkit">
// Copyright (c) TedToolkit. All rights reserved.
// Licensed under the LGPL-3.0 license. See COPYING, COPYING.LESSER file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Runtime.CompilerServices;

namespace TedToolkit.Refly;

/// <summary>
/// A heap-allocated wrapper that holds a mutable reference to a disposable struct value.
/// Disposing this wrapper disposes the wrapped struct.
/// </summary>
/// <typeparam name="TStruct">The type of the disposable struct to wrap.</typeparam>
/// <param name="value">The disposable struct value to wrap.</param>
public sealed class DisposableRef<TStruct>(scoped in TStruct value) : IDisposable
    where TStruct : struct, IDisposable
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
    public void Dispose()
    {
        _value.Dispose();
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string? ToString()
    {
        return _value.ToString();
    }
}