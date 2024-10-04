using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RotateAnimation : MonoBehaviour
{
    [SerializeField] private float animationTime;
    [SerializeField] private int startAngle;
    [SerializeField] private float rotationAngle;
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, startAngle);

        transform.DORotate(new Vector3(0, 0, rotationAngle), animationTime, RotateMode.LocalAxisAdd)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }
}
