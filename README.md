# Siphoin Helpers

This repository contains helpers for everyday work on Unity Enviroment or .NET

 ## Simple Pool System for Unity
 
This is a simple pool object system for Unity:

It can create prefabs at the start of the game, instantiate them into a special specified root and have an expandable or non-expandable type

## Example

``` C#

GameObject rootPool = new GameObject("root_VFX_Points_Movement_Player");

_poolPoints = new PoolMono<PointTargetMovementPlayer>(_pointEffectPrefab, rootPool.transform, _settings.CountPoolObjects, _settings.IsExpand);

```

## Syntax:

``` C#

PoolMono<T> pool = new PoolMono<T>(prefab, rootTransform, countObjects, isExpand);

```

## Where:

prefab - The object that will be installed

rootTransform - The object that will be the parent of the created objects in the pool

countObjects - How many objects do I need to create when initializing the pool

isExpand - Will the pool expand if all objects are occupied, but a new one is needed, if isExpand is false, then there will be an exception


# Adaptive Builder for Unity Editor

It is used for easier assembly of projects in the Unity environment, especially if you need to build as a Dedicated Server or as a Desktop Application.

## Requirements

Windows Dedicated Server Support Molude

Linux Dedicated Server Support Molude


# Handler Type GameObject

 Handler for checking an object for its essence. It is a replacement for checking an object through a tag. Eliminates errors in which errors may occur when changing tags. Is an extension for GameObject

### Example

``` C#
   gameObject.HandleComponent<Enemy>(component) => component.Method(arguments);
```

# Assets Finder

 Find a assets on Unity Project


 # Addressables Helpers

 Find a assets on Addressables
 ##
If you not using DOTween on your Unity Project, delete DOTween extensions

If you not using Addressables on your Unity Project, delete Addressables helpers

If you not using Xnode on your Unity Project, delete folber XNodeExtensions and xNode

If you not using UniTask on your Unity Project, delete folber UniTask
