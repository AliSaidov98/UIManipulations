using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _3DtoUI.Scripts
{
    public class OutlineAnim : MonoBehaviour
    {
        [SerializeField] private float _speedOfAnimation;
        [SerializeField] private Outline _outline;

        private Color _color = Color.black;

        /*
        private void Awake()
        {
            _outline.DOFade(0, _speedOfAnimation).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        }*/

        private void Update()
        {
            _color.a = Mathf.PingPong(Time.time * _speedOfAnimation, 1);
            _outline.effectColor = _color;
        }
    }
}
