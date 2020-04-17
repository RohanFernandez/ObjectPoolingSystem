using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReusable
{
    void onReturnedToPool();
    void onRetrievedFromPool();
}
