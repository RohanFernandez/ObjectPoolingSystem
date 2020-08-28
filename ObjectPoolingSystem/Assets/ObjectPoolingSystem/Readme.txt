//Created by Rohan Fernandez
//Contact fretbuzz31f@gmail.com for any details.

Object Pooling System

-Instantiation of gameobjects or creating objects require time to create and processing each time.
-Using an object pool you can reuse the objects.
-This asset will be used to get and return objects from and to the pool.
-On creating the pool for the first time you can set the size of the pool, so that the pool is instantiated with the total amount of object you require at max. This prevents from instantiating/creating objects after that.
-You can specialize the pool to act specifically for different types of objects, a MonoObjectPool is included in this asset for pooling of GameObjects(MonoBehaviour).
-Gameobjects managed by the MonoObjectPool can be set to have a specific parent gameobject.
-You can use this asset for reusability of your objects and automatic creation of the object if the pool is empty.
-If the pool is empty and you call getObject(), the pool will automatically create an object.
-One completed using an object return the object back into the pool.


-------- ObjectPool<T>

ObjectPool(string a_strObjectType, int a_iStartSize = 0)

where a_strObjectType is the typeof(T)
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
