using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Specialized pooled class for objects of type MonoBehaviour,
/// because creation requires instantiation in Unity instead of using new, adding an object to the heap
/// </summary>
/// <typeparam name="T"></typeparam>
public class MonoObjectPool<T> : ObjectPool<T> where T : MonoBehaviour, IReusable
{
    /// <summary>
    /// The pool will manage the creation of this Prefab.
    /// </summary>
    private T m_goPrefab = null;

    /// <summary>
    /// The parent of the pooled game object
    /// </summary>
    private GameObject m_goParent = null;

    /// <summary>
    /// Constructor that specifies the prefab for which the pool manages
    /// Constructs a stack with the specified capacity
    /// </summary>
    /// <param name="a_Prefab"></param>
    /// <param name="a_iStartPoolCapacity"></param>
    public MonoObjectPool(T a_Prefab, GameObject a_Parent, int a_iStartSize = 0)
        :  base()
    {
        m_goPrefab = a_Prefab;
        m_goParent = a_Parent;

        for (int l_iIndex = 0; l_iIndex < a_iStartSize; l_iIndex++)
        {
            createObj();
        }
    }

    /// <summary>
    /// Creates object of type T and pushes into the pool
    /// </summary>
    protected override void createObj()
    {
        T l_CreatedObj = MonoBehaviour.Instantiate<T>(m_goPrefab);
        l_CreatedObj.transform.SetParent(m_goParent.transform);
        returnToPool(l_CreatedObj);
    }

    /// <summary>
    /// Returns gameobject
    /// </summary>
    /// <returns></returns>
    public override T getObject()
    {
        return base.getObject();
    }

    /// <summary>
    /// returns object to pool
    /// </summary>
    public override void returnToPool(T a_Obj)
    {
        a_Obj.gameObject.SetActive(false);
        a_Obj.transform.SetParent(m_goParent.transform);
        base.returnToPool(a_Obj);
    }
}