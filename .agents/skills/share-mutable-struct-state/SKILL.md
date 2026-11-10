---
name: share-mutable-struct-state
description: >-
  Use TedToolkit.Refly when a mutable C# struct needs shared heap identity or an owned disposable struct needs a heap wrapper.
---

# Share Mutable Struct State

- Use `Ref<T>` or `ToRef()` when a value needs stable shared storage across fields, collections, or asynchronous calls. Wrapping an existing struct copies its current value into the wrapper.
- Mutate the wrapper’s value by reference when the update must be visible to all holders. Avoid assigning the underlying value to a local copy before mutation.
- Use `ToDisposableRef()` for an owned disposable struct and dispose the wrapper at the ownership boundary. Verify shared updates and the expected disposal behavior.
