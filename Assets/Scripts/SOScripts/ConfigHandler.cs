using UnityEngine;

namespace SOScripts
{
    public class ConfigHandler : MonoBehaviour
    {
        [field: SerializeField] public EnergyConfig EnergyConfig { get; private set; }
        [field: SerializeField] public AutoСurrencyСollection AutoСurrencyСollectionConfig { get; private set; }
        [field: SerializeField] public CurrencyConfig CurrencyConfig { get; private set; }
    }
}