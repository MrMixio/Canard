using System;
using UnityEngine;
using UnityEngine.UI;

public class ScreamBar : MonoBehaviour
{
    public GameObject _screamBarSprite;
    public GameObject _canvasBarObject;

    public void ToggeScreamBar(bool _isToggled)
    {
        _canvasBarObject.SetActive(_isToggled);
    }

    public void UpdateScreamBar(float _maxTimerScream, float _currentTimerScream)
    {
        _screamBarSprite.GetComponent<Image>().fillAmount = _currentTimerScream / _maxTimerScream; 
    }
}
