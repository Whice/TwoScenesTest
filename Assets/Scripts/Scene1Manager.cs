using UnityEngine;

public class Scene1Manager : MonoBehaviour
{
    [SerializeField] private CubeView cubePrototype = null;
    [SerializeField] private SphereManipulator sphereManipulator = null;
    [SerializeField] private UI ui = null;

    private CubeView redCube;
    private CubeView greenCube;

    private PlayerInput playerInput;
    private const float HIDE_SPHERE_DISANCE = 2f;

    private void CheckDistance()
    {
        float distance = Vector3.Distance(redCube.localPosition, greenCube.localPosition);
        ui.SetDistance(distance);
        sphereManipulator.SetSpheresVisible(distance < HIDE_SPHERE_DISANCE);
    }

    private void Awake()
    {
        sphereManipulator.OnCreate();

        redCube = Instantiate(cubePrototype, transform);
        greenCube = Instantiate(cubePrototype, transform);

        redCube.SetColor(Color.red);
        greenCube.SetColor(Color.green);

        redCube.transform.localPosition = new Vector3(0, 2, 4);
       greenCube.transform.localPosition = new Vector3(0, 2, -4);

        CheckDistance();

        playerInput = new PlayerInput();
    }

    private void FixedUpdate()
    {
        if (playerInput.isInput)
        {
            Vector2 redCubeDirection = playerInput.GetRedCubeDirection();
            redCube.PositionUpdate(redCubeDirection);

            Vector2 greenCubeDirection = playerInput.GetGreenCubeDirection();
            greenCube.PositionUpdate(greenCubeDirection);

            CheckDistance();
        }
    }
}
