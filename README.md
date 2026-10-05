# Singletons

A Unity package providing reusable singleton abstractions for MonoBehaviours, ScriptableObjects, and plain C# classes, with initialization diagnostics, optional scene persistence, and bootstrap scene support.

## Features

- `MonoBehaviour` singletons
- `ScriptableObject` singletons
- Lazy plain C# singletons
- Generic and non-generic singleton interfaces
- Initialization state and events
- Duplicate instance diagnostics
- Optional scene persistence
- Optional Bootstrap Scene
- Editor tooling for creating the Bootstrap Scene

## Singleton Types

### Singleton

Use `Singleton<TInstance>` for scene-based `MonoBehaviour` singletons.

```csharp
using M320.Singletons;

public class GameManager : Singleton<GameManager>
{
}
```

Access the instance through:

```csharp
GameManager.Instance
```

Duplicate instances are detected during initialization.

### ScriptableObject Singleton

Use `SingletonSO<TInstance>` for `ScriptableObject` singletons.

```csharp
using M320.Singletons;

public class GameSettings : SingletonSO<GameSettings>
{
}
```

Access the instance through:

```csharp
GameSettings.Instance
```

### Lazy Singleton

Use `LazySingleton<TInstance>` for plain C# singleton classes that should be created when first accessed.

```csharp
using M320.Singletons;

public class GameService : LazySingleton<GameService>
{
}
```

The instance is created on first access:

```csharp
GameService.Instance
```

## Scene Persistence

A `MonoBehaviour` singleton can implement `IScenePersistentSingleton` to persist across scene loads.

```csharp
using M320.Singletons;

public class GameManager :
    Singleton<GameManager>,
    IScenePersistentSingleton
{
}
```

Persistent singleton GameObjects are automatically passed to `DontDestroyOnLoad` when initialized.

## Bootstrap Scene

The package supports an optional scene named:

```text
Bootstrap Scene
```

When included in the project and available to load, the scene is automatically loaded additively before the initial scene.

The Bootstrap Scene can be used to contain global singleton objects and other startup objects.

If the Bootstrap Scene is not available, the bootstrapper does nothing, allowing the package to be used without the bootstrap workflow.

An included editor tool can create the Bootstrap Scene when needed.

## Interfaces

Singleton implementations share common interfaces for working with singleton instances without requiring their concrete type.

```csharp
ISingleton
ISingleton<TInstance>

IDiagnosableSingleton
IDiagnosableSingleton<TInstance>
```

These can be used for diagnostics, tooling, and other systems that operate across multiple singleton types.

## Installation

Install through the Unity Package Manager using the Git repository URL and the desired version tag.

Example:

```text
https://github.com/M320-Dev/Singletons.git#v2.0.0
```
