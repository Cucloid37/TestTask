using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TestTask
{
    public class PrefabsManager : IDisposable
    {
        // Я здесь слишком переусложнил, кажись
        // Вернусь к проверенному
        
        private Task<GameObject> _rectangle;
        private Task<GameObject> _startUI;

        private readonly Descriptions descriptions;

        public GameObject Rectangle => _rectangle.Result;
        public GameObject StartUI => _startUI.Result;
        
        public PrefabsManager(Descriptions descriptions)
        {
            this.descriptions = descriptions;

            _rectangle = LoadGameObject(descriptions.Rectangle);
            
            
        }

        private async Task<GameObject> LoadGameObject(AssetReference reference)
        {
            var task = await Addressables.LoadAssetAsync<GameObject>(reference).Task;
            
            return task;
        }

        public void Dispose()
        {
            Addressables.Release(_rectangle);
            Addressables.Release(_startUI);
        }
    }
}