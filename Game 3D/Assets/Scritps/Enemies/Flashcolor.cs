using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flashcolor : MonoBehaviour
{
    public MeshRenderer mesherenderer;

    [Header("ColorSetup")]
    public Color color = Color.red;
    public float duration = .1f;

    private Color defaultColor;

    private Tween _currTween;

    private void Start()
    {
        defaultColor = mesherenderer.material.GetColor("_EmissionColor"); // Inicia com a cor original;
    }

    [NaughtyAttributes.Button]

    public void Flash()
    {
        
        if(!_currTween.IsActive())  // Ele não toca; Ele pode perder a cor do personagem quando se faz rapido;
           _currTween = mesherenderer.material.DOColor(color, "_EmissionColor", duration).SetLoops(2, LoopType.Yoyo);
        //mesherenderer.material.DOColor(color, "_EmissionColor", duration).SetLoops(2, LoopType.Yoyo);
    }
}
