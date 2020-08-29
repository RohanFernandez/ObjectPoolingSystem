# **Object Pooling System**

-------- A release of this Unity Package can be directly downloaded from the releases panel.

This asset will be used to get and return objects from and to the pool providing reusability and automatic creation of the object if the pool is empty.
You can use this asset for reusability of your objects.


-------- ObjectPool<T>

ObjectPool(int a_iStartSize = 0)

a_iStartSize is the size of the pooled objects

Pool.getObject() returns a object of type T from the pool and sets it to active.
Pool.returnToPool(T obj) to return the object to the pool and deactivates the object.
Pool.returnAll() to return all objects back into the pool and deactivates all the object.

-------- IReusable

The reusable object of type T should be derived from IReusable
-- T.onRetrievedFromPool()
will be called when the object is retrieved from the pool.
-- T.onReturnedToPool()
will be called when the object is returned to the pool.



-------- MonoObjectPool<T>
To use an object pool for MonoBehaviour objects, use 

MonoObjectPool<T>(T a_Prefab, GameObject a_Parent, int a_iStartSize = 0)

where T is the prefab to manage
a_Parent is the gameobject which will act as the parent gameobject of the instantiated gameobjects of type T
a_iStartSize is the amount of gameobjects of type T that will be instantiated on start
