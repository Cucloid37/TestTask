using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TestTask
{
    [CreateAssetMenu(fileName = "Descriptions", menuName = "Descriptions/Descriptions")]
    public class Descriptions : ScriptableObject
    {
        [SerializeField] private AssetReference _rectangle;
        // [SerializeField] private AssetReference _startUI; 

        [SerializeField] private Color[] _colors;

        public AssetReference Rectangle => _rectangle;
        // public AssetReference StartUI => _startUI;
        
        public Color[] Colors => _colors;

        public async Task<GameObject> LoadView(AssetReference reference)
        {
            return await Addressables.LoadAssetAsync<GameObject>(reference).Task;
        }
    }
}