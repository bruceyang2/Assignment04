using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public TextMeshProUGUI TimerText;

    private void Start()
    {
        TimerOn = true;
        updateTimer(TimeLeft);
    }

    private void Update()
    {
        updateTimer(TimeLeft);
        TimeLeft += Time.deltaTime;
    }

    void updateTimer(float currentTime)
    {
        //currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = string.Format("{00:00} : {01:00}", minutes, seconds);
    }
}
