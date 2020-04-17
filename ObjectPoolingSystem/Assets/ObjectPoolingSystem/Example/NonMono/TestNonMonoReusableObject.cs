using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ns_YourNamespace
{
    public class TestNonMonoReusableObject : IReusable
    {
        public void onRetrievedFromPool()
        {
            Debug.Log("Retrieved: " + typeof(TestNonMonoReusableObject).ToString());
        }

        public void onReturnedToPool()
        {
            Debug.Log("Returned: " + typeof(TestNonMonoReusableObject).ToString());
        }
    }
}