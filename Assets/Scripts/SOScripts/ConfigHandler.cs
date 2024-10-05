using UnityEngine;

namespace SOScripts
{
    public class ConfigHandler : MonoBehaviour
    {
        [field: SerializeField] public ClickerConfig ClickerConfig { get; private set; }
    }
}