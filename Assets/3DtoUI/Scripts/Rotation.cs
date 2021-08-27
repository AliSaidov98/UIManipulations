using DG.Tweening;
using UnityEngine;

namespace _3DtoUI.Scripts
{
    public class Rotation : MonoBehaviour
    {
        //[SerializeField] private float _rotationSpeed;
        [SerializeField] private float _rotationAngle;
    
        private void Awake()
        {
            //transform.DOLocalRotate(Vector3.up * _rotationAngle,  _rotationSpeed).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
            InvokeRepeating(nameof(RotateObject), .1f, .1f);
        }

        private void RotateObject()
        {
            transform.localEulerAngles += Vector3.up * _rotationAngle;
        }
    }
}
