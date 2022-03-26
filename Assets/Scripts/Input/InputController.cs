using System;
using UnityEngine;

namespace TestTask
{
    public class InputController : IExecute
    {
        public event Action OnClickMouseLeft;
        public event Action DoubleClickMouseLeft;

        private readonly KeysManager _inputKeys;

        public InputController()
        {
            _inputKeys = new KeysManager();
            
        }
        
        public void Execute(float deltaTime)
        {
            if (Time.timeScale == Mathf.Round(0)) return;           //ToAsk 

            _inputKeys.GetMouseRight(OnClickMouseLeft);
        }
        
    }
}