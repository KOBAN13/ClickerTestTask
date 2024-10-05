using UnityEngine;

namespace SOScripts
{
    [CreateAssetMenu(fileName = "ClickerConfig",menuName = "ClickerConfig/CurrencyConfig")]
    public class CurrencyConfig : ScriptableObject
    {
        [field: SerializeField] public float CountCurrencyValueInClick { get; private set; }
    }
}