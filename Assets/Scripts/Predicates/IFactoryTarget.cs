using UnityEngine;

namespace TestTask
{
    public interface IFactoryTarget : ITarget
    {
        GameObject targetObject { get; }

        bool IsOverlap();

    }
}