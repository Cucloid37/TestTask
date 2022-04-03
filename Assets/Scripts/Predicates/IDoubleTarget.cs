using System.Collections.Generic;
using UnityEngine;

namespace TestTask
{
    public interface IDoubleTarget : IFactoryTarget
    {
        int countClick { get; }
        
        float timeSinceTheLastClick { get; set; }

        GameObject toComparer { get; set; }

        EqualityComparer<GameObject> comparer { get; }

        void countPlus();

        void Reset();
    }
}