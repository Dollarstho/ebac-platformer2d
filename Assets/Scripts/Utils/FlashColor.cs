using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers;
    public UnityEngine.Color flashColor = UnityEngine.Color.red;
    public float duration = 0.3f;

    private Tween _currentTween;


    private void OnValidate()
    {
        spriteRenderers = new List<SpriteRenderer>();
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(child);
            
        }
    }

    public void Update()
    {
       
    }

    public void Flash()
    {
        if(_currentTween != null)
        {
            _currentTween.Kill();
            spriteRenderers.ForEach(i => i.color = Color.white);
        }
        foreach (var s in spriteRenderers)
        {
           _currentTween = s.DOColor(flashColor, duration).SetLoops(2, LoopType.Yoyo);
        }
    }

}
