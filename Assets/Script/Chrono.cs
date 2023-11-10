using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chrono : MonoBehaviour
{
    public TextMeshProUGUI _chronoText;
    private float _elapsedTime;

    void Update()
    {
        _elapsedTime += Time.deltaTime;

        int _minutes = Mathf.FloorToInt(_elapsedTime / 60);
        int _seconds = Mathf.FloorToInt(_elapsedTime % 60);

        _chronoText.text = string.Format("{0:00}:{1:00}", _minutes, _seconds);
    }
}
