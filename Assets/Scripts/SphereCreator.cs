using System;
using UnityEngine;

public class SphereCreator : MonoBehaviour
{
    [SerializeField] private Material sphereMaterial = null;
    [SerializeField] private GameObject spherePrototype = null;
    [SerializeField] private float circleRadius = 5f;
    [SerializeField] private Texture2D[] textures = new Texture2D[20];
     private const int SPHERE_MAX_COUNT = 20;

    private GameObject[] spheres;
    private void Awake()
    {
        spheres = new GameObject[SPHERE_MAX_COUNT];
        float rad = ((360/ SPHERE_MAX_COUNT) * Mathf.PI) / 180;
        float cos = Mathf.Cos(rad);
        float sin = Mathf.Sin(rad);
        Func<Vector2, Vector2> RotateVector = (vec) =>
        {
            return new Vector2
                (
                    vec.x * cos - vec.y * sin,
                    vec.x * sin + vec.y * cos
                );
        };
        Vector2 currentDirection = new Vector2(0, circleRadius);
        for (int i = 0; i < SPHERE_MAX_COUNT; i++)
        {
            spheres[i] = Instantiate(spherePrototype, transform);
            spheres[i].transform.localPosition = new Vector3
                (
                    currentDirection.x,
                    0,
                    currentDirection.y
                );

            MeshRenderer renderer = spheres[i].GetComponent<MeshRenderer>();
            renderer.material.mainTexture = textures[i];

            currentDirection = RotateVector(currentDirection);
        }
    }
    public void SetSpheresVisible(bool isVisible)
    {
        foreach(GameObject sphere in spheres)
            sphere.SetActive(isVisible);
    }
}
