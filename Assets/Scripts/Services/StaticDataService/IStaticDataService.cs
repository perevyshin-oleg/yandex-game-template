using YGameTemplate.StaticDatas;

namespace YGameTemplate.Services
{
    public interface IStaticDataService
    {
        StaticData GetStaticData(string staticDataName, out StaticData itemStaticData);
        void LoadStaticDatas();
    }
}