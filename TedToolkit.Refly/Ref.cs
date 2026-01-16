// -----------------------------------------------------------------------
// <copyright file="Ref.cs" company="TedToolkit">
// Copyright (c) TedToolkit. All rights reserved.
// Licensed under the LGPL-3.0 license. See COPYING, COPYING.LESSER file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Runtime.CompilerServices;

namespace TedToolkit.Refly;

/// <summary>
/// Ref struct.
/// </summary>
/// <typeparam name="TStruct">struct.</typeparam>
/// <param name="value">value.</param>
public sealed class Ref<TStruct>(scoped in TStruct value)
    where TStruct : struct
{
    private TStruct _value = value;

    /// <summary>
    /// Gets Value.
    /// </summary>
    public ref TStruct Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _value;
    }
}