using UnityEngine;

namespace TestTask
{
    public class RayCastManager
    {
        public readonly ReactiveValue<Vector3> Point = new ReactiveValue<Vector3>() {CurrentValue = new Vector3()};

        public GameObject GoReturn()
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 100))
            {
                Point.CurrentValue = hitInfo.point;
                
                return hitInfo.collider.gameObject;
            }
            
            return null;
        }
    }
}