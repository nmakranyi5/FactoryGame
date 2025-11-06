using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ChangeShape shapeController;
    public Timer timerController;
    public TextMesh targetText;

    private string[] shapeNames = { "Cube", "Sphere", "Capsule", "Cylinder", "Plane" };
    private int targetIndex = 0;
    private bool gameOver = false;

    void Start()
    {
        PickNewTarget();
        UpdateTargetText();
    }

    void Update()
    {
        if (gameOver) return;

        if (!IsTimerRunning())
        {
            GameOver();
            return;
        }

        if (shapeController.GetCurrentIndex() == targetIndex)
        {
            PickNewTarget();
            ResetTimer();
        }

        UpdateTargetText();
    }

    void PickNewTarget()
    {
        int newIndex;
        do
        {
            newIndex = Random.Range(0, shapeNames.Length);
        } while (newIndex == targetIndex);

        targetIndex = newIndex;
    }

    void ResetTimer()
    {
        timerController.ResetTimer();
    }

    bool IsTimerRunning()
    {
        return timerController.IsRunning();
    }

    void UpdateTargetText()
    {
        targetText.text = "Target: " + shapeNames[targetIndex];
    }

    void GameOver()
    {
        gameOver = true;
        targetText.text = "GAME OVER!";
        Debug.Log("Game Over!");

        shapeController.enabled = false;
    }
}
