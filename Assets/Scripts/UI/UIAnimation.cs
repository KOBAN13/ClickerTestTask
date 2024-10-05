using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIAnimation
    {
        public void PunchAnimation(TextMeshProUGUI text)
        {
            text.rectTransform.DOPunchScale(new Vector3(0.2f, 0.2f, 0f), 0.2f, 10, 1f);
        }
    }
}