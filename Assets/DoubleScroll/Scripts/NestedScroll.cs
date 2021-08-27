using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DoubleScroll.Scripts
{
    public class NestedScroll : ScrollRect
    {
        [SerializeField]
        private ScrollRect _parentScrollRect;
        
        private ScrollSnap _scrollSnap;
        
        private bool _routeToParent = false;

        protected override void Awake()
        {
            base.Awake();
            _scrollSnap = _parentScrollRect.GetComponent<ScrollSnap>();
        }

        public override void OnInitializePotentialDrag(PointerEventData eventData)
        {
            if (_parentScrollRect != null)
            {
                ((IInitializePotentialDragHandler)_parentScrollRect).OnInitializePotentialDrag(eventData);
            }
            base.OnInitializePotentialDrag(eventData);
        }
        
 
        public override void OnDrag(PointerEventData eventData)
        {
            if (_routeToParent)
            {
                if (_parentScrollRect != null)
                {
                    ((IDragHandler)_parentScrollRect).OnDrag(eventData);
                }
            }
            else
            {
                base.OnDrag(eventData);
            }
        }
 
        public override void OnBeginDrag(PointerEventData eventData)
        {
            CheckRoute(eventData);

            if (_routeToParent)
            {
                if (_parentScrollRect != null)
                {
                    if(_scrollSnap != null)
                        _scrollSnap.Scrolling(true);
                    
                    ((IBeginDragHandler)_parentScrollRect).OnBeginDrag(eventData);
                }
            }
            else
            {
                base.OnBeginDrag(eventData);
            }
        }

        private void CheckRoute(PointerEventData eventData)
        {
            if (!horizontal && Math.Abs(eventData.delta.x) > Math.Abs(eventData.delta.y))
            {
                _routeToParent = true;
            }
            else if (!vertical && Math.Abs(eventData.delta.x) < Math.Abs(eventData.delta.y))
            {
                _routeToParent = true;
            }
            else
            {
                _routeToParent = false;
            }
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            if (_routeToParent)
            {
                if (_parentScrollRect != null)
                {
                    if(_scrollSnap != null)
                        _scrollSnap.Scrolling(false);
                    
                    ((IEndDragHandler)_parentScrollRect).OnEndDrag(eventData);
                }
            }
            else
            {
                base.OnEndDrag(eventData);
            }
            _routeToParent = false;
        }


    }
}
