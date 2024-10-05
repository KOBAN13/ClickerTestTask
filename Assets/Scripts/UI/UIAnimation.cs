using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIAnimation : MonoBehaviour
    {
        public void PunchAnimation(RectTransform transform)
        {
            transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0f), 0.05f, 10, 1f).OnComplete(() => transform.localScale = Vector3.one);
        }
        
        public void ShowFloatingText(GameObject textPrefab, Vector3 positionButton, float amount, Canvas canvas)
        {
            var floatingText = Instantiate(textPrefab, positionButton, Quaternion.identity);
            var textComponent = floatingText.GetComponent<TextMeshProUGUI>();
            
            textComponent.transform.SetParent(canvas.transform, false);
            textComponent.text = $"+ {amount}";

            var randomOffset = new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
            textComponent.transform.position = positionButton + randomOffset;
            
            var moveDuration = Random.Range(1f, 1.5f);
            var targetYPosition = floatingText.transform.position.y + Random.Range(1.5f, 3f);
            
            var waypoints = new Vector3[3];
            waypoints[0] = textComponent.transform.position;
            waypoints[1] = new Vector3(textComponent.transform.position.x + Random.Range(-0.5f, 0.5f), targetYPosition, textComponent.transform.position.z);
            waypoints[2] = new Vector3(textComponent.transform.position.x + Random.Range(-0.5f, 0.5f), 0, textComponent.transform.position.z);
            
            textComponent.transform.DOPath(waypoints, moveDuration, PathType.CatmullRom)
                .SetEase(Ease.OutCubic)
                .OnComplete(() => Destroy(floatingText.gameObject));
            textComponent.DOFade(0,1F).OnComplete(() => Destroy(floatingText.gameObject));
        }
    }
}