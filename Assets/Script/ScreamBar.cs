using System;
using UnityEngine;
using UnityEngine.UI;

public class ScreamBar : MonoBehaviour
{
    public GameObject _screamBarSprite;
    public GameObject _foreGroundSprite;

    private void Start()
    {
        _screamBarSprite.SetActive(false);
    }

    public void ToggleScreamBar(bool _isToggled)
    {
        _screamBarSprite.SetActive(_isToggled);
    }

    public void UpdateScreamBar(float _maxTimerScream, float _currentTimerScream)
    {
        _foreGroundSprite.GetComponent<Image>().fillAmount = _currentTimerScream / _maxTimerScream; 
    }
}
