using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private Descriptions _descriptions;
        [SerializeField] private Transform _canvas;

        private UpdateController _updateController;
        private MainController _mainController;
        private GameInitialization _initialization;

        private void Start()
        {
            var prefabsManager = new PrefabsManager(_descriptions);
            _updateController = new UpdateController();
            _mainController = new MainController(_descriptions, _canvas, _updateController);
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            _updateController.Execute(deltaTime);
        }

        private void OnDisable()
        {
            
        }
    }    
}

