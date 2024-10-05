using UnityEngine;

[CreateAssetMenu(fileName = "ClickerConfig",menuName = "ClickerConfig/Parameters")]
public class ClickerConfig : ScriptableObject
{
    [field: SerializeField] public float CountCurrencyValueInClick { get; private set; }
    [field: SerializeField] public int CountEnergy { get; private set; }
    [field: SerializeField] public float TimeToRecoveryEnergy { get; private set; }
    [field: SerializeField] public float CountRecoveryEnergyInOneTime { get; private set; }
    [field: SerializeField] public int CountRemoveEnergyInClick { get; private set; }
}
