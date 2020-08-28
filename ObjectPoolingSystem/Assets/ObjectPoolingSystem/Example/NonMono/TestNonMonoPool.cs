using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_YourNamespace;

    public class TestNonMonoPool : ObjectPool<TestNonMonoReusableObject>
    {
        public TestNonMonoPool(int a_iStartSize = 0)
            : base(a_iStartSize)
        {
        }
    }
