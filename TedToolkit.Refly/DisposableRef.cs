// -----------------------------------------------------------------------
// <copyright file="DisposableRef.cs" company="TedToolkit">
// Copyright (c) TedToolkit. All rights reserved.
// Licensed under the LGPL-3.0 license. See COPYING, COPYING.LESSER file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace TedToolkit.Refly;

/// <summary>
/// Disposable ref struct.
/// </summary>
/// <typeparam name="TStruct">struct.</typeparam>
/// <param name="value">value.</param>
public sealed class DisposableRef<TStruct>(scoped in TStruct value) : IDisposable
    where TStruct : struct, IDisposable
{
    private TStruct _value = value;

    /// <summary>
    /// Gets Value.
    /// </summary>
    public ref TStruct Value
        => ref _value;

    /// <inheritdoc />
    public void Dispose()
        => _value.Dispose();
}