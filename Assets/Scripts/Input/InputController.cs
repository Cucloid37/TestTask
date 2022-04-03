using System;
using UnityEngine;

namespace TestTask
{
    public class InputController : IExecute
    {
        public event Action OnClickMouseLeft;

        private readonly KeysManager _inputKeys;

        public InputController()
        {
            _inputKeys = new KeysManager();
            
        }
        
        public void Execute(float deltaTime)
        {
            Debug.Log($"{Time.timeScale}");
            if (Time.timeScale == Mathf.Round(0)) return;           //По идее эта проверка  

            _inputKeys.GetMouseRight(OnClickMouseLeft);
        }
        
    }
}