# TedToolkit.Refly

[![Build](https://github.com/TedToolkit/TedToolkit.Refly/actions/workflows/build.yml/badge.svg)](https://github.com/TedToolkit/TedToolkit.Refly/actions/workflows/build.yml)
[![NuGet](https://img.shields.io/nuget/v/TedToolkit.Refly)](https://www.nuget.org/packages/TedToolkit.Refly)

A lightweight .NET library that wraps value types (structs) in heap-allocated classes, allowing you to hold mutable references to structs in contexts where `ref struct` cannot be used — such as storing in collections, fields, or across `async` boundaries.

## Installation

```shell
dotnet add package TedToolkit.Refly
```

## Usage

### Wrapping a struct with `Ref<T>`

```csharp
using TedToolkit.Refly;

var myStruct = new MyStruct { X = 10, Y = 20 };

// Wrap the struct in a Ref<T>
var wrapped = new Ref<MyStruct>(myStruct);

// Access the struct by reference
ref MyStruct value = ref wrapped.Value;
value.X = 42;

Console.WriteLine(wrapped.Value.X); // 42
```

### Using extension methods

```csharp
using TedToolkit.Refly;

var wrapped = new MyStruct { X = 10 }.ToRef();

wrapped.Value.X = 42;
```

### Wrapping a disposable struct with `DisposableRef<T>`

```csharp
using TedToolkit.Refly;

using var wrapped = new MyDisposableStruct().ToDisposableRef();

wrapped.Value.DoWork();
// Dispose() is called automatically on the wrapped struct
```

## Supported Frameworks

- .NET 6.0, 7.0, 8.0, 9.0, 10.0
- .NET Framework 4.7.2, 4.8
- .NET Standard 2.0, 2.1

## License

This project is licensed under the [LGPL-3.0](COPYING.LESSER) license.
