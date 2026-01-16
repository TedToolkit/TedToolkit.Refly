// -----------------------------------------------------------------------
// <copyright file="RefExtensions.cs" company="TedToolkit">
// Copyright (c) TedToolkit. All rights reserved.
// Licensed under the LGPL-3.0 license. See COPYING, COPYING.LESSER file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Runtime.CompilerServices;

namespace TedToolkit.Refly;

/// <summary>
/// The extensions for the Ref types.
/// </summary>
public static class RefExtensions
{
    /// <summary>
    /// To the reference.
    /// </summary>
    /// <param name="this">the struct.</param>
    /// <typeparam name="TStruct">struct type.</typeparam>
    /// <returns>ref.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ref<TStruct> ToRef<TStruct>(this TStruct @this)
        where TStruct : struct
    {
        return new(@this);
    }

    /// <summary>
    /// To the disposable reference.
    /// </summary>
    /// <param name="this">the struct.</param>
    /// <typeparam name="TStruct">struct type.</typeparam>
    /// <returns>ref.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DisposableRef<TStruct> ToDisposableRef<TStruct>(this TStruct @this)
        where TStruct : struct, IDisposable
    {
        return new(@this);
    }
}