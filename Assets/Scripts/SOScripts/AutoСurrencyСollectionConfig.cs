using UnityEngine;

namespace SOScripts
{
    [CreateAssetMenu(fileName = "ClickerConfig",menuName = "ClickerConfig/AutoСurrencyСollection")]
    public class AutoСurrencyСollection : ScriptableObject
    {
        [field: SerializeField] public float CurrentAutoCurrency { get; private set; }
        [field: SerializeField] public float CurrencyCollectionTimeInSecond { get; private set; }
        [field: Range(0.01f, 1f)]
        [field: SerializeField] public float ModificatorBoostCurrencyInPresent { get; private set; }
    }
}