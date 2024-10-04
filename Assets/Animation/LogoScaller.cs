using TMPro;
using UnityEngine;
using DG.Tweening;

public class LogoScaler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text; // Посилання на TextMeshProUGUI
    [SerializeField] private float _scaleAmount = 1.5f; // Коефіцієнт масштабування
    [SerializeField] private float _duration = 0.5f; // Тривалість анімації

    private Vector3 _originalScale; // Зберігаємо початковий розмір тексту

    void Start()
    {
        _originalScale = _text.transform.localScale; // Зберігаємо початковий розмір
        ScaleText(); // Запускаємо анімацію
    }

    private void ScaleText()
    {
        // Анімуємо масштаб тексту
        _text.transform.DOScale(_originalScale * _scaleAmount, _duration)
            .OnComplete(() => 
            {
                // Повертаємося до початкового розміру після завершення анімації
                _text.transform.DOScale(_originalScale, _duration)
                    .OnComplete(ScaleText); // Викликаємо ScaleText для повторення анімації
            });
    }
}
