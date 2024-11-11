using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool controller;

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Gamepad.current == null)
        {
            controller = false;
        }

        if(Gamepad.current != null)
        {
            controller = true;
        }
    }
}
