using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMesh timerText;
    public float startTime = 5f;

    private float timeRemaining;
    private bool isRunning = true;

    void Start()
    {
        timeRemaining = startTime;
        UpdateTimerText();
    }

    void Update()
    {
        if (!isRunning) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            isRunning = false;
        }

        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + timeRemaining.ToString("F2") + "s";
    }

    public bool IsRunning() => isRunning;

    public void ResetTimer()
    {
        timeRemaining = 3f;
        isRunning = true;
    }

}
