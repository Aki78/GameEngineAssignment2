using UnityEngine;

public class KeyDetection : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            OnSKeyPressed();
        }
    }

    void OnSKeyPressed()
    {
        Debug.Log("S key was pressed!");
    }
}

