using Cysharp.Threading.Tasks;
using UnityEngine;
using YGameTemplate.Infrastructure.AssetProviders;

namespace YGameTemplate.Infrastructure.Factory
{
    public class Factory<T> where T : MonoBehaviour
    {
        private readonly string _bundlePath;
        private IAssetProvider _assetProvider;

        public Factory(IAssetProvider assetProvider, string bundlePath)
        {
            _assetProvider = assetProvider;
            _bundlePath = bundlePath;
        }

        public async UniTask<T> Create()
        {
            GameObject resource = await _assetProvider.Load<GameObject>(_bundlePath);
            GameObject obj = GameObject.Instantiate(resource, new Vector3(0, 0, 0), Quaternion.identity);
            obj.TryGetComponent<T>(out var result);
            return result;
        }
    }
}
    
