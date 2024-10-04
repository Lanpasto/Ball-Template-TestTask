using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateCoin : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAmount = new Vector3(0, 360, 0); 
    [SerializeField] private float rotationDuration = 2f; 

    private void Start()
    {
        RotateAroundY();
    }

    private void RotateAroundY()
    {
        transform.DORotate(rotationAmount, rotationDuration, RotateMode.FastBeyond360)
                 .SetLoops(-1, LoopType.Yoyo)
                 .SetEase(Ease.InOutSine);
    }
}
