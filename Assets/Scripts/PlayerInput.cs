using UnityEngine;

public class PlayerInput
{
    public bool isInput
    {
        get => Input.anyKey;
    }
    public Vector2 GetRedCubeDirection()
    {
        Vector2 dir = Vector2.zero;

        if(Input.GetKey(KeyCode.W))
            {
            dir.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
        }

        if(Input.GetKey(KeyCode.A))
            {
            dir.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
        }

        return dir;
    }
    public Vector2 GetGreenCubeDirection()
    {
        Vector2 dir = Vector2.zero;

        if(Input.GetKey(KeyCode.UpArrow))
            {
            dir.y = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            dir.y = -1;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
            {
            dir.x = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            dir.x = 1;
        }

        return dir;
    }
}
