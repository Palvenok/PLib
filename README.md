# Utility library for Unity
Tested and packed in Unity3D 2021.3.15f1
## Tablet
- [ObjectPool](#objectpool)
  - [Usage](#usage)
  - [Example](#poolexample)
- [Singleton](#singleton)
  - [Example](#singletonexample)

## ObjectPool
### Usage
#### Constructor
* Сreates an game object on the scene with `prefab.name + "PoolContainer"` name if the parent is not specified.
* Instantiate prefab copies under specified parrent object
  ```cs
  public ObjectPool(T objectPrefab, int count, string poolName = "PoolContainer")
  public ObjectPool(T objectPrefab, int count, Transform parent)
  ```
#### Methods
  * Current - return current item
  ```cs
  var item = pool.Current;
  ```
  * Count - return items count
  ```cs
  int count = pool.Count;
  ```
  * GetByIndex() - return item by index, set tis item as current
  ```cs
  var item = pool.GetByIndex(index);
  ```
  * GetNext() - return next item, increase index
  ```cs
  var item = pool.GetNext();
  ```
  * Clear() - just delete pool container game object, clear inner array
  ```cs
  pool.Clear();
  ```

<a name="poolexample"/>
<details>
  <summary>Example</summary>
    
```cs
using UnityEngine;
using PLib.Pool;

public class EnemyPoolContainer : MonoBehaviour
{
  [SerializeField] private Enemy _enemyPrefab;
  [SerializeField] private int _enemiesCount = 10;

  private ObjectPool<Enemy> _enemies;

  private void Awake()
  {
      _enemies = new ObjectPool<Enemy>(_enemyPrefab, _enemiesCount, transform);

      foreach(Enemy enemy in _enemies)
          enemy.transform.position = Random.insideUnitCircle * 5;
          
      for(int i = 0; i < 5; i++)
          _enemies.GetByIndex(i).gameObject.SetActive(false);
          
      _enemies.Current.SomeAction(); //Current enemy is  5
      
      _enemies.GetNext().SomeSecondAction(); //Current enemy is 6
      
      _enemies.Clear(); 
  }
}
```
      
</details>

## Singleton

<a name="singletonexample"/>
<details>
  <summary>Example</summary>
    
```cs
using UnityEngine;
using PLib.Singleton;

public class SomeClass : Singleton<SomeClass>
{
  // If you need Awake method
  private void Awake()
  {
    base.Awake();
    // Your code
  }
}
```
      
</details>
