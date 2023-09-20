using UnityEngine;

public class ShortcutKey : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.RightCommand))
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                MyFunction();
            }
        }
    }

    void MyFunction()
    {
        Debug.Log("Control + S was pressed!");
    }
}

