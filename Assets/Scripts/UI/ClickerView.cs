using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickerView : MonoBehaviour
{
    [field: SerializeField] public Button ClickButton { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Currency { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Energy { get; private set; }
}
