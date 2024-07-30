using Cysharp.Threading.Tasks;
using YGameTemplate.UI;
namespace YGameTemplate.Infrastructure.Factories
{
    public interface IHUDSpawner
    {
        public UniTask<HUDRoot> SpawnHUD();
    }
}