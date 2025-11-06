using UnityEngine;

public class ChangeShape : MonoBehaviour
{
    private MeshFilter meshFilter;
    private Mesh[] shapeMeshes;
    private int currentIndex = 0;

    [Header("Input Cooldown")]
    public float inputCooldown = 1f;
    private float cooldownTimer = 0f;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();

        shapeMeshes = new Mesh[]
        {
            Resources.GetBuiltinResource<Mesh>("Cube.fbx"),
            Resources.GetBuiltinResource<Mesh>("Sphere.fbx"),
            Resources.GetBuiltinResource<Mesh>("Capsule.fbx"),
            Resources.GetBuiltinResource<Mesh>("Cylinder.fbx"),
            Resources.GetBuiltinResource<Mesh>("Plane.fbx")
        };

        meshFilter.mesh = shapeMeshes[currentIndex];
    }

    void Update()
    {
        if (cooldownTimer > 0f)
            cooldownTimer -= Time.deltaTime;

        if (cooldownTimer > 0f)
            return;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentIndex = (currentIndex + 1) % shapeMeshes.Length;
            meshFilter.mesh = shapeMeshes[currentIndex];
            cooldownTimer = inputCooldown;
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentIndex = (currentIndex - 1 + shapeMeshes.Length) % shapeMeshes.Length;
            meshFilter.mesh = shapeMeshes[currentIndex];
            cooldownTimer = inputCooldown;
        }
    }

    public int GetCurrentIndex() => currentIndex;
}
