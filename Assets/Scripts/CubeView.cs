using UnityEngine;

public class CubeView : MonoBehaviour
{
    [SerializeField] private float speed = .5f;
    public void SetColor(Color color)
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();//Потому что один раз устанавливается цвет.
        renderer.material.color = color;
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
