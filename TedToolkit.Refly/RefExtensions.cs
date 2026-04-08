// -----------------------------------------------------------------------
// <copyright file="RefExtensions.cs" company="TedToolkit">
// Copyright (c) TedToolkit. All rights reserved.
// Licensed under the LGPL-3.0 license. See COPYING, COPYING.LESSER file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Runtime.CompilerServices;

namespace TedToolkit.Refly;

/// <summary>
/// Extension methods for wrapping structs in <see cref="Ref{TStruct}"/> and <see cref="DisposableRef{TStruct}"/>.
/// </summary>
public static class RefExtensions
{
    /// <summary>
    /// Wraps the struct in a <see cref="Ref{TStruct}"/>.
    /// </summary>
    /// <param name="this">The struct value to wrap.</param>
    /// <typeparam name="TStruct">The type of the struct to wrap.</typeparam>
    /// <returns>A new <see cref="Ref{TStruct}"/> wrapping the value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ref<TStruct> ToRef<TStruct>(this TStruct @this)
        where TStruct : struct
    {
        return new(@this);
    }

    /// <summary>
    /// Wraps the disposable struct in a <see cref="DisposableRef{TStruct}"/>.
    /// </summary>
    /// <param name="this">The disposable struct value to wrap.</param>
    /// <typeparam name="TStruct">The type of the disposable struct to wrap.</typeparam>
    /// <returns>A new <see cref="DisposableRef{TStruct}"/> wrapping the value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DisposableRef<TStruct> ToDisposableRef<TStruct>(this TStruct @this)
        where TStruct : struct, IDisposable
    {
        return new(@this);
    }
}