using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ns_YourNamespace
{
    public class TestNonMonoPool : ObjectPool<TestNonMonoReusableObject>
    {
        public TestNonMonoPool(int a_iStartSize = 0)
            : base(typeof(TestNonMonoReusableObject).ToString(), a_iStartSize)
        {
        }
    }
}
