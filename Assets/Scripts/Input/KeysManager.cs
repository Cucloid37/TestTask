using System;
using UnityEngine;

namespace TestTask
{
    public class KeysManager
    {
        public void GetMouseRight(Action action)
        {
            if (Input.GetMouseButtonDown(0))
            {
                action?.Invoke();
            }
        }
        
    }
}