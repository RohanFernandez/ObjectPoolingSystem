using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface to be implemented on the type to be managed by an object pool
/// This interface informs the object when it is retrieved from the pool or returned back into the pool
/// </summary>
public interface IReusable
{
    void onReturnedToPool();
    void onRetrievedFromPool();
}
