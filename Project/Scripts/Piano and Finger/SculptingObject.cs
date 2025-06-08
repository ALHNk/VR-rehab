using UnityEngine;

public class SculptingObject : MonoBehaviour
{
    public float sculptStrength = 0.05f;  // How much to deform the mesh
    public float sculptRadius = 0.1f;     // The radius around the collision point that gets affected

    private Mesh mesh;
    private Vector3[] vertices;
    private Vector3[] originalVertices;
    private Vector3[] normals;

    void Start()
    {
        // Get the mesh from the object
        mesh = GetComponent<MeshFilter>().mesh;
        // Store original vertices for later use
        originalVertices = mesh.vertices;
        vertices = mesh.vertices;
        normals = mesh.normals;
    }

    void Update()
    {
        // Update the mesh vertices if needed
        mesh.vertices = vertices;
        mesh.RecalculateNormals();  // Recalculate normals after deformation for proper lighting
        mesh.RecalculateBounds();   // Recalculate bounds after deformation
    }

    // Call this method when a finger collider enters the object
    public void OnFingerCollide(Vector3 collisionPoint)
    {
        // For each vertex, calculate if it's within the sculpting radius from the collision point
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 worldVertex = transform.TransformPoint(vertices[i]);  // Convert local to world position
            float distance = Vector3.Distance(worldVertex, collisionPoint);  // Distance to collision point

            if (distance < sculptRadius)
            {
                // Apply deformation: move vertices towards the collision point based on distance
                Vector3 direction = (worldVertex - collisionPoint).normalized;  // Get direction from collision point
                float deformAmount = sculptStrength * Mathf.Clamp01(1 - distance / sculptRadius);  // How much to deform based on distance
                vertices[i] -= direction * deformAmount;  // Deform vertex
            }
        }
    }
}
