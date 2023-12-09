using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text textField = null;

    public void SetDistance(float distance)
    {
        textField.text = $"Distance: {distance}";
    }
}
