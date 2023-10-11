# Pool Mono v1.1f
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

