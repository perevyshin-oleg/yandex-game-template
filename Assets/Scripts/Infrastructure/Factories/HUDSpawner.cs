using Cysharp.Threading.Tasks;
using YGameTemplate.Infrastructure.AssetProviders;
using YGameTemplate.Infrastructure.Factory;
using YGameTemplate.UI;

namespace YGameTemplate.Infrastructure.Factories
{
    public class HUDSpawner : IHUDSpawner
    {
        private Factory<HUDRoot> _factory;

        public HUDSpawner(IAssetProvider assetProvider)
        {
            _factory = new Factory<HUDRoot>(assetProvider ,BundlePath.HUD);
        }

        public async UniTask<HUDRoot> SpawnHUD()
            => await _factory.Create();
    }
}