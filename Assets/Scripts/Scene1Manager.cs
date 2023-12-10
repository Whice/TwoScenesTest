using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1Manager : MonoBehaviour
{
    [SerializeField] private CubeView cubePrototype = null;
    [SerializeField] private SphereManipulator sphereManipulator = null;
    [SerializeField] private UI ui = null;

    private CubeView redCube;
    private CubeView greenCube;

    private PlayerInput playerInput;
    private const float HIDE_SPHERE_DISANCE = 2f;
    private const float SCENE2_LOAD_DISANCE = 1f;

    private void CheckDistance()
    {
        float distance = Vector3.Distance(redCube.localPosition, greenCube.localPosition);
        ui.SetDistance(distance);
        sphereManipulator.SetSpheresVisible(distance < HIDE_SPHERE_DISANCE);

        if (distance < SCENE2_LOAD_DISANCE)
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }
    private void CheckPositions()
    {
        redCube.SetAnotherCubePosition(greenCube.transform.position);
        greenCube.SetAnotherCubePosition(redCube.transform.position);
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
        CheckPositions();

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
            CheckPositions();
        }
    }
}
