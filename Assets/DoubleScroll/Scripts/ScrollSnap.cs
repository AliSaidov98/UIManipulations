using System;
using System.Collections.Generic;
using DoubleScroll.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollSnap : MonoBehaviour
{
    [SerializeField] private float _snapSpeed;
    
    private ScrollRect _scroll;
    private RectTransform _contentRect;
    private Vector2 _contentVector;

    private List<Vector2> _itemsPos = new List<Vector2>();
    
    private int _nearestItemId;
    private bool _isScrolling;
    
    private void Awake()
    {
        _scroll = GetComponent<ScrollRect>();
        _contentRect = _scroll.content.GetComponent<RectTransform>();
        InitItemsPositions();
    }

    private void InitItemsPositions()
    {
        for (int i = 0; i < _scroll.content.childCount; i++)
        {
            _itemsPos.Add(-_scroll.content.GetChild(i).transform.localPosition);
        }
    }

    private void FixedUpdate()
    {
        FindTheNearestItem();

        if(_isScrolling) return;
        
        GoToItem();
    }

    private void FindTheNearestItem()
    {
        float nearestPos = float.MaxValue;

        for (int i = 0; i < _scroll.content.childCount; i++)
        {
            float distance = 0;
            
            if(_scroll.vertical)
                distance = Mathf.Abs(_contentRect.anchoredPosition.y - _itemsPos[i].y);

            if(_scroll.horizontal)
                distance = Mathf.Abs(_contentRect.anchoredPosition.x - _itemsPos[i].x);
            
            
            if (distance < nearestPos)
            {
                nearestPos = distance;
                _nearestItemId = i;
            }
        }
    }

    private void GoToItem()
    {
        if(_scroll.vertical)
            _contentVector.y = Mathf.SmoothStep(_contentRect.anchoredPosition.y, _itemsPos[_nearestItemId].y,
                _snapSpeed * Time.fixedDeltaTime);

        if(_scroll.horizontal)
            _contentVector.x = Mathf.SmoothStep(_contentRect.anchoredPosition.x, _itemsPos[_nearestItemId].x,
            _snapSpeed * Time.fixedDeltaTime);
        
        _contentRect.anchoredPosition = _contentVector;
    }

    public void Scrolling(bool isScroll)
    {
        _isScrolling = isScroll;
    }
    
}
