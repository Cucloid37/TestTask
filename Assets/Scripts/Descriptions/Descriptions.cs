using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TestTask
{
    [CreateAssetMenu(fileName = "Descriptions", menuName = "Descriptions/Descriptions")]
    public class Descriptions : ScriptableObject
    {
        [SerializeField] private AssetReference _rectangle;

        [SerializeField] private Color[] _colors;
        
        // временная заглушка
        [SerializeField] private GameObject emptyBox;

        public AssetReference Rectangle => _rectangle;
        
        public Color[] Colors => _colors;
        public GameObject EmptyBox => emptyBox;

        public async Task<GameObject> LoadView(AssetReference reference)
        {
            return await Addressables.LoadAssetAsync<GameObject>(reference).Task;
        }
    }
}