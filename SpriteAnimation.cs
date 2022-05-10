using UnityEngine;
using UnityEngine.Events;


    [RequireComponent(typeof(SpriteRenderer))]   // для автоматического довабления SpriteRenderer

    public class SpriteAnimation : MonoBehaviour
    {

        [SerializeField] private int _frameRate;
        [SerializeField] private bool _loop;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private UnityEvent _onComplete;    // ивент по прошествии анимации

        private SpriteRenderer _renderer;
        private float _secondsPerFrame;
        private int _curentSpriteIndex;         // порядок текущего спрайта
        private float _nextFrameTime;           // время, когда нужно обновить спрайт
        private bool _isPlaying = true;         // флаг остановки проигрывания анимации

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            _secondsPerFrame = 1f / _frameRate;           //инициализация переменной 
            _nextFrameTime = Time.time + _secondsPerFrame;
            _curentSpriteIndex = 0;
        }

        private void Update()
        {
            if (!_isPlaying || _nextFrameTime > Time.time) return;

            if (_curentSpriteIndex >= _sprites.Length)
            {
                if (_loop)
                {
                    _curentSpriteIndex = 0;
                }
                else
                {
                    _isPlaying = false;
                    _onComplete?.Invoke();
                    return;                 // выход из цикла если не зажат флаг loop
                }
            }

            _renderer.sprite = _sprites[_curentSpriteIndex];
            _nextFrameTime += _secondsPerFrame;
            _curentSpriteIndex++;

        }
    }