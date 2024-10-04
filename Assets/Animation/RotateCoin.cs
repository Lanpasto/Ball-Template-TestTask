using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateCoin : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAmount = new Vector3(0, 360, 0); // Обертання навколо осі Y
    [SerializeField] private float rotationDuration = 2f; // Тривалість обертання

    private void Start()
    {
        // Запускаємо безперервну анімацію обертання навколо осі Y
        RotateAroundY();
    }

    private void RotateAroundY()
    {
        transform.DORotate(rotationAmount, rotationDuration, RotateMode.FastBeyond360)
                 .SetLoops(-1, LoopType.Yoyo)
                 .SetEase(Ease.InOutSine);
    }
}
