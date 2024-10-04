using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    [SerializeField] private float _x;
    [SerializeField] private float _y;

    private Rect _uvRect;
    private Vector2 _movement;

    void Start()
    {
        _uvRect = _img.uvRect;
        _movement = new Vector2(_x, _y);
    }

    void Update()
    {
        // Оновлюємо позицію у кожному кадрі
        _uvRect.position += _movement * Time.deltaTime;
        _img.uvRect = _uvRect;
    }
}
