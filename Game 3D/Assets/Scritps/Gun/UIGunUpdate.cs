using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIGunUpdate : MonoBehaviour
{
    public Image uiImage;

    [Header("Animation UI")]
    public float duration = .1f;
    public Ease ease = Ease.OutBack;

    private Tween _crrTeween;

    private void OnValidate()
    {
        if (uiImage == null) uiImage = GetComponent<Image>();
    }

    public void UpdateValue(float f)
    {
        uiImage.fillAmount = f;
    }

    public void UpdateValue(float max, float current)
    {
        //uiImage.fillAmount = 1 - (max / current); // Para funcionar a linha abaixo precisa tirar esta;
        if(_crrTeween != null) _crrTeween.Kill();
        _crrTeween = uiImage.DOFillAmount(1 - (max / current), duration).SetEase(ease);
    }
}
