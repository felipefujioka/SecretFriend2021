using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AutomaticScroll : MonoBehaviour
{
    public ScrollRect Scroll;
    
    void Start()
    {
        Scroll.verticalNormalizedPosition = 1;
        
        DOTween.To(() => Scroll.verticalNormalizedPosition, (value) =>
        {
            Scroll.verticalNormalizedPosition = value;
        }, 0, 60).Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
