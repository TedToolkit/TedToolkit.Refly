# TedToolkit.Refly

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

## API Reference

### `Ref<TStruct>` where `TStruct : struct`

| Member | Description |
|--------|-------------|
| `Ref(scoped in TStruct value)` | Creates a new wrapper around the given struct value. |
| `ref TStruct Value { get; }` | Returns a mutable reference to the wrapped struct. |
| `string? ToString()` | Returns the string representation of the wrapped struct. |

### `DisposableRef<TStruct>` where `TStruct : struct, IDisposable`

Implements `IDisposable`. Disposes the wrapped struct when disposed.

| Member | Description |
|--------|-------------|
| `DisposableRef(scoped in TStruct value)` | Creates a new wrapper around the given disposable struct value. |
| `ref TStruct Value { get; }` | Returns a mutable reference to the wrapped struct. |
| `void Dispose()` | Disposes the wrapped struct. |
| `string? ToString()` | Returns the string representation of the wrapped struct. |

### `RefExtensions`

| Method | Description |
|--------|-------------|
| `Ref<TStruct> ToRef<TStruct>(this TStruct)` | Extension method to wrap any struct in a `Ref<T>`. |
| `DisposableRef<TStruct> ToDisposableRef<TStruct>(this TStruct)` | Extension method to wrap any disposable struct in a `DisposableRef<T>`. |

## Supported Frameworks

- .NET 6.0, 7.0, 8.0, 9.0, 10.0
- .NET Framework 4.7.2, 4.8
- .NET Standard 2.0, 2.1

## License

This project is licensed under the [LGPL-3.0](https://www.gnu.org/licenses/lgpl-3.0.html) license.
