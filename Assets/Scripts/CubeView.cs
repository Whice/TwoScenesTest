using UnityEngine;

public class CubeView : MonoBehaviour
{
    [SerializeField] private float speed = .5f;
    [SerializeField] private ParticleSystem particleSystem = null;
    public void SetColor(Color color)
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();//Потому что один раз устанавливается цвет.
        renderer.material.color = color;
        var main = particleSystem.main;
        main.startColor = color;
    }

    public void SetAnotherCubePosition(Vector3 position)
    {
        Transform transform = particleSystem.transform;
        transform.LookAt(position);
    }

    public Vector3 localPosition
    {
        get => transform.localPosition;
    }

    public void PositionUpdate(Vector2 direction)
    {
        direction *= speed;
        Vector3 oldPos = transform.localPosition;
        transform.localPosition = new Vector3
            (
                oldPos.x + direction.x,
                oldPos.y,
                oldPos.z + direction.y
            );
    }
}
