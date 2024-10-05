using UnityEngine;

[CreateAssetMenu(fileName = "ClickerConfig",menuName = "ClickerConfig/EnergyConfig")]
public class EnergyConfig : ScriptableObject
{
    [field: SerializeField] public int CountEnergy { get; private set; }
    [field: SerializeField] public float TimeToRecoveryEnergy { get; private set; }
    [field: SerializeField] public int CountRecoveryEnergyInOneTime { get; private set; }
    [field: SerializeField] public int CountRemoveEnergyInClick { get; private set; }
}
