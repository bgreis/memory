using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;

    private float timeInSec;

    void Start()
    {
        timeInSec = 60f;
    }

    void Update()
    {
        timeInSec -= Time.deltaTime;

        float minutes = Mathf.FloorToInt(timeInSec/60);
        float seconds = Mathf.FloorToInt(timeInSec%60);

        if (timeInSec > 0f)
        {
            timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
