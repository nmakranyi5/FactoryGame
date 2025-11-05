using UnityEngine;

public class ChangeShape : MonoBehaviour
{
    private MeshFilter meshFilter;
    private Mesh[] shapeMeshes;
    private int currentIndex = 0;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();

        shapeMeshes = new Mesh[]
        {
            Resources.GetBuiltinResource<Mesh>("Cube.fbx"),
            Resources.GetBuiltinResource<Mesh>("Sphere.fbx"),
            Resources.GetBuiltinResource<Mesh>("Capsule.fbx"),
            Resources.GetBuiltinResource<Mesh>("Cylinder.fbx"),
        };

        meshFilter.mesh = shapeMeshes[currentIndex];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentIndex = (currentIndex + 1) % shapeMeshes.Length;
            meshFilter.mesh = shapeMeshes[currentIndex];
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentIndex = (currentIndex - 1 + shapeMeshes.Length) % shapeMeshes.Length;
            meshFilter.mesh = shapeMeshes[currentIndex];
        }
    }
}
