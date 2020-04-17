using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonoReusableObject : MonoBehaviour, IReusable
{
    public void onRetrievedFromPool()
    {
        gameObject.SetActive(true);
    }

    public void onReturnedToPool()
    {
        gameObject.SetActive(false);
    }
}
