using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMonoReusableObject : MonoBehaviour, IReusable
{
    public Text m_txtObjNumber = null;

    public void onRetrievedFromPool()
    {
        gameObject.SetActive(true);
    }

    public void onReturnedToPool()
    {
        gameObject.SetActive(false);
    }
}
