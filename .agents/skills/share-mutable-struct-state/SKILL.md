---
name: share-mutable-struct-state
description: >-
  Use TedToolkit.Refly when a mutable C# struct needs shared heap identity or an owned disposable struct needs a heap wrapper.
---

# Share Mutable Struct State

Choose a wrapper when multiple consumers need to observe updates to one mutable struct or when the wrapper should own disposal.

## Workflow

- Use `Ref<T>` or `ToRef()` when a value needs stable shared storage across fields, collections, or asynchronous calls. Wrapping an existing struct copies its current value into the wrapper.
- Mutate the wrapper’s value by reference when the update must be visible to all holders. Avoid assigning the underlying value to a local copy before mutation.
- Use `ToDisposableRef()` for an owned disposable struct and dispose the wrapper at the ownership boundary. Verify shared updates and the expected disposal behavior.

## Example

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

```csharp
using TedToolkit.Refly;

using var wrapped = new MyDisposableStruct().ToDisposableRef();

wrapped.Value.DoWork();
// Dispose() is called automatically on the wrapped struct
```

## Check the result

Exercise two holders of the same wrapper and check that each observes a by-reference mutation. For a disposable value, verify ownership at the disposal boundary and check that callers are not separately disposing a copied struct.
