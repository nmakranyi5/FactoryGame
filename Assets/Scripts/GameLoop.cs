using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public MeshFilter meshFilter;   // assign your player’s MeshFilter
    public TextMesh shapeText;      // text showing target shape
    public TextMesh timerText;      // countdown text

    public Mesh[] shapeMeshes;      // list of available shapes
    public string[] shapeNames;     // their names (same order)
    public float roundTime = 5f;    // seconds per round

    private float timeRemaining;
    private int currentShapeIndex = 0;    // what player is on
    private int targetShapeIndex = 0;     // what they need to match

    void Start()
    {
        // Initialize timer and shapes
        timeRemaining = roundTime;
        meshFilter.mesh = shapeMeshes[currentShapeIndex];

        PickNewTarget();
        UpdateUI();
    }

    void Update()
    {
        // Handle shape cycling
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentShapeIndex = (currentShapeIndex + 1) % shapeMeshes.Length;
            meshFilter.mesh = shapeMeshes[currentShapeIndex];
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentShapeIndex = (currentShapeIndex - 1 + shapeMeshes.Length) % shapeMeshes.Length;
            meshFilter.mesh = shapeMeshes[currentShapeIndex];
        }

        // Countdown
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            // Time’s up — pick a new target
            PickNewTarget();
            ResetTimer();
        }

        // Check if player picked the correct shape
        if (currentShapeIndex == targetShapeIndex)
        {
            PickNewTarget();
            ResetTimer();
        }

        UpdateUI();
    }

    void PickNewTarget()
    {
        // pick a new random target shape
        int newIndex = targetShapeIndex;
        while (newIndex == targetShapeIndex)
            newIndex = Random.Range(0, shapeMeshes.Length);

        targetShapeIndex = newIndex;
    }

    void ResetTimer()
    {
        timeRemaining = roundTime;
    }

    void UpdateUI()
    {
        timerText.text = "Time: " + timeRemaining.ToString("F2") + "s";
        shapeText.text = "Target: " + shapeNames[targetShapeIndex];
    }
}
