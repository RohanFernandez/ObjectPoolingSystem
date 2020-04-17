using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_YourNamespace;

public class TestPoolManager : MonoBehaviour
{
    #region MONO
    [SerializeField]
    private TestMonoReusableObject m_ReusablePrefab = null;

    [SerializeField]
    private UnityEngine.UI.Text m_txtMonoPooledCount = null;

    [SerializeField]
    private UnityEngine.UI.Text m_txtMonoActiveCount = null;

    private MonoObjectPool<TestMonoReusableObject> m_MonoObjectPool = null;

    [SerializeField]
    private int m_iMonoObjPoolStartSize = 8;

    public void monoReturnAll()
    {
        m_MonoObjectPool.returnAll();
        updateCount();
    }

    public void monoGetObjectFromPool()
    {
        TestMonoReusableObject l_ReusableObject = m_MonoObjectPool.getObject();
        updateCount();
    }

    public void monoReturnObjectToPool()
    {
        List<TestMonoReusableObject> l_lstTestReusable = m_MonoObjectPool.getActiveList();
        TestMonoReusableObject l_ReusableObject = l_lstTestReusable.Count > 0 ? l_lstTestReusable[0] : null;
        if (l_ReusableObject == null)
        {
            Debug.LogError("TestManager::ReturnObjectToPool:: Active object list is empty. Count ==  0");
        }
        else
        {
            m_MonoObjectPool.returnToPool(l_ReusableObject);
        }

        updateCount();
    }

    #endregion MONO




    #region NON_MONO

    private TestNonMonoPool m_NonMonoObjectPool = null;

    [SerializeField]
    private UnityEngine.UI.Text m_txtNonMonoPooledCount = null;

    [SerializeField]
    private UnityEngine.UI.Text m_txtNonMonoActiveCount = null;

    /// <summary>
    /// The start number of objects to be set into the pooled list
    /// </summary>
    [SerializeField]
    private int m_iNonMonoPooledStartCount = 10;

    public void nonmonoReturnAll()
    {
        m_NonMonoObjectPool.returnAll();
        updateCount();
    }

    public void nonmonoGetObjectFromPool()
    {
        TestNonMonoReusableObject l_NonMonoReusableObject = m_NonMonoObjectPool.getObject();
        updateCount();
    }

    public void nonmonoReturnObjectToPool()
    {
        List<TestNonMonoReusableObject> l_lstNonMonoReusable = m_NonMonoObjectPool.getActiveList();
        TestNonMonoReusableObject l_NonMonoReusableObject = l_lstNonMonoReusable.Count > 0 ? l_lstNonMonoReusable[0] : null;
        if (l_NonMonoReusableObject == null)
        {
            Debug.LogError("TestManager::ReturnObjectToPool:: Active object list is empty. Count ==  0");
        }
        else
        {
            m_NonMonoObjectPool.returnToPool(l_NonMonoReusableObject);
        }

        updateCount();
    }

    #endregion NON_MONO





    void Awake()
    {
        m_MonoObjectPool = new MonoObjectPool<TestMonoReusableObject>(m_ReusablePrefab, gameObject, m_iMonoObjPoolStartSize);
        m_NonMonoObjectPool = new TestNonMonoPool(m_iNonMonoPooledStartCount);

        updateCount();
    }

    private void updateCount()
    {
        m_txtMonoActiveCount.text = m_MonoObjectPool.getActiveList().Count.ToString();
        m_txtMonoPooledCount.text = m_MonoObjectPool.getPooledList().Count.ToString();

        m_txtNonMonoActiveCount.text = m_NonMonoObjectPool.getActiveList().Count.ToString();
        m_txtNonMonoPooledCount.text = m_NonMonoObjectPool.getPooledList().Count.ToString();
    }

    void Destroy()
    {
        monoReturnAll();
        nonmonoReturnAll();
    }
}
