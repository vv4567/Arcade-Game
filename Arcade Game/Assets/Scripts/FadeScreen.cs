using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    public enum FadeType { FadeIn, FadeOut }

    public FadeType fadeType;
    protected float _targetAlpha;
    protected float _aDelta = 0;

    public Color FadeToColor = Color.black;
    public float FadeDuration = 1f;
    public float FadeSpeed = 60;

    public float InitialAlpha = -1;
    protected float _currentAlpha;

    public bool fade = false;

    protected Image image;

    private void OnEnable()
    {
        image = GetComponentInChildren<Image>();
    }

    private void Start()
    {
        Initialize();
    }

    public void StartFade()
    {
        fade = true;
    }

    public void StopFade()
    {
        fade = false;
    }

    public void Fade(FadeType type)
    {
        fadeType = type;
        Initialize();

        fade = true;
    }

    public void FadeTo(Color color)
    {
        FadeToColor = color;
        Fade(FadeType.FadeIn);
    }

    public void Initialize()
    {
        if (InitialAlpha == -1)
        {
            switch (fadeType)
            {
                case FadeType.FadeIn:
                    _currentAlpha = 0;
                    break;
                case FadeType.FadeOut:
                    _currentAlpha = 1;
                    break;
            }
        }

        switch (fadeType)
        {
            case FadeType.FadeIn:
                _targetAlpha = 1;
                break;
            case FadeType.FadeOut:
                _targetAlpha = 0;
                break;
        }

        _aDelta = (_targetAlpha - _currentAlpha) / 255;

        if (image != null)
        {
            image.color = new Color(FadeToColor.r, FadeToColor.g, FadeToColor.b, _currentAlpha);
        }
    }

    private void Update()
    {
        if (!fade || image == null) { return; }

        if (_currentAlpha != _targetAlpha && Mathf.Abs(_currentAlpha - _targetAlpha) > _aDelta)
        {
            _currentAlpha += (_aDelta * FadeSpeed * Time.deltaTime) / FadeDuration;
        }
        else
        {
            _currentAlpha = _targetAlpha;
            fade = false;
        }

        image.color = new Color(FadeToColor.r, FadeToColor.g, FadeToColor.b, _currentAlpha);
    }
}
