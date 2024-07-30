using UnityEngine;

namespace YGameTemplate.StaticDatas
{
    public abstract class StaticData: ScriptableObject
    {
        public abstract string StaticDataID { get; }
    }
}