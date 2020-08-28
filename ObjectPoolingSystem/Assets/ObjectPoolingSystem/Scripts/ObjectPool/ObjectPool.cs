using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pool to manage objects,
/// it will create objects by using the new keyword
/// When the pool is empty and a 'getObject' is called a new object is created in the pool and retrieved at that time
/// When you are done using an object return it to the pool for future use
/// </summary>
/// <typeparam name="T"></typeparam>
[System.Serializable]
public class ObjectPool<T> where T : class, IReusable
{
    /// <summary>
    /// The stack that contains the objects of the pool.
    /// </summary>
    protected Stack<T> m_Pool = null;

    /// <summary>
    /// The type of the pooled object
    /// </summary>
    private System.Type m_Type = null;

    /// <summary>
    /// List of all the unpooled game objects
    /// </summary>
    private List<T> m_lstActivePooledObjects = new List<T>(5);

    /// <summary>
    /// Constructor.
    /// Sets the Prefab from which the objects in the pool are generated
    /// </summary>
    /// <param name="a_ObjPrefab"></param>
    public ObjectPool(int a_iStartSize = 0)
    {
        m_Type = typeof(T);
        m_Pool = new Stack<T>(a_iStartSize);

        for (int l_iIndex = 0; l_iIndex < a_iStartSize; l_iIndex++)
        {
            createObj();
        }
    }

    /// <summary>
    /// Creates object of type T and pushes into the pool
    /// </summary>
    protected virtual void createObj()
    {
        T l_CreatedObj = System.Activator.CreateInstance(m_Type) as T;
        returnToPool(l_CreatedObj);
    }

    /// <summary>
    /// Returns back into the pool for reuse in the future
    /// </summary>
    /// <param name="a_Obj"></param>
    public virtual void returnToPool(T a_Obj)
    {
        a_Obj.onReturnedToPool();
        m_lstActivePooledObjects.Remove(a_Obj);
        m_Pool.Push(a_Obj);
    }

    /// <summary>
    /// Gets object of type from the pool
    /// sets the task variables
    /// </summary>
    public virtual T getObject()
    {
        if (m_Pool.Count == 0)
        {
            createObj();
        }
        T l_ReturnObj = m_Pool.Pop();
        m_lstActivePooledObjects.Add(l_ReturnObj);
        l_ReturnObj.onRetrievedFromPool();
        return l_ReturnObj;
    }

    /// <summary>
    /// Returns all active game objects back into the pool
    /// </summary>
    public virtual void returnAll()
    {
        int l_iActiveCount = m_lstActivePooledObjects.Count;
        for (int l_iActiveObjIndex = l_iActiveCount - 1; l_iActiveObjIndex >= 0; l_iActiveObjIndex--)
        {
            returnToPool(m_lstActivePooledObjects[l_iActiveObjIndex]);
        }
    }

    /// <summary>
    /// Returns list of all active game objects
    /// </summary>
    /// <returns></returns>
    public virtual List<T> getActiveList()
    {
        return m_lstActivePooledObjects;
    }

    /// <summary>
    /// Returns list of all active game objects
    /// </summary>
    /// <returns></returns>
    public virtual List<T> getPooledList()
    {
        return new List<T>( m_Pool.ToArray());
    }
}