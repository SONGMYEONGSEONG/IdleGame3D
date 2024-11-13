using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Xml;

public class DamageIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshPro damageText;
    [SerializeField] private float fadeDuration = 1f;   // 사라지는 데 걸리는 시간
    [SerializeField] private float moveDistance = 0.5f; // 위로 이동할 거리
    [SerializeField] private float moveDuration = 1.5f;   // 이동하는 데 걸리는 시간

    private void Awake()
    {
        if (damageText == null)
        {
            damageText = GetComponentInChildren<TextMeshPro>();
        }
        damageText.gameObject.SetActive(false);

    }

    public void PrintDamage(int damage)
    {
        DamagePrintSetting(damage);

        damageText.transform.DOMoveY(transform.position.y + moveDistance, moveDuration)
            .OnComplete(() => damageText.DOFade(0, fadeDuration));
        // 이동 애니메이션이 끝난 후 텍스트의 알파를 0으로 변경

    }

    private void DamagePrintSetting(int damage)
    {
        damageText.gameObject.SetActive(true);
        damageText.text = damage.ToString(); // 데미지 텍스트 설정
        damageText.alpha = 1; // 텍스트 초기화 (사라지지 않게)
        damageText.transform.position = transform.position;
    }

}
