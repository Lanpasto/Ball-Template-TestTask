using TMPro;
using UnityEngine;
using DG.Tweening;

public class LogoScaler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text; 
    [SerializeField] private float _scaleAmount = 1.5f; 
    [SerializeField] private float _duration = 0.5f; 

    private Vector3 _originalScale; 

    void Start()
    {
        _originalScale = _text.transform.localScale; 
        ScaleText(); 
    }

    private void ScaleText()
    {
        _text.transform.DOScale(_originalScale * _scaleAmount, _duration)
            .OnComplete(() => 
            {
                _text.transform.DOScale(_originalScale, _duration)
                    .OnComplete(ScaleText); 
            });
    }
}
