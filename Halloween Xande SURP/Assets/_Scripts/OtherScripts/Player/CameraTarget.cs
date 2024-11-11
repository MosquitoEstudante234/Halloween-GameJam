using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraTarget : MonoBehaviour
{
    public InputAction inputAction;

    public Transform player;
    public Vector3 target, mousePos, refVel, shakeOffset;

    public Vector2 move;

    public float cameraDist = 3.5f;
    public float smoothTime = 0.2f; private float zStart;
    public static CameraTarget Instance;
    //shake
    float shakeMag, shakeTimeEnd;
    Vector3 shakeVector;
    bool shaking;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        target = PlayerLife.Instance.transform.position; //set default target
        zStart = transform.position.z; //capture current z position
    }
    void Update()
    {
        mousePos = CaptureMousePos(); //find out where the mouse is
        shakeOffset = UpdateShake(); //account for screen shake
        target = UpdateTargetPos(); //find out where the camera ought to be
        UpdateCameraPosition(); //smoothly move the camera closer to it's target location
    }
    public Vector3 CaptureMousePos()
    {
        Vector2 ret;

        if (GameManager.Instance.controller)
        {
            move = Gamepad.current.rightStick.ReadValue();

            ret = move;
        }
        else
        {
            ret = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }

         //raw mouse pos
        
        ret -= Vector2.zero; //set (0,0) of mouse to middle of screen
        float max = 0.9f;
        if (Mathf.Abs(ret.x) > max || Mathf.Abs(ret.y) > max)
        {
            ret = ret.normalized; //helps smooth near edges of screen
        }
        return ret;
    }
    Vector3 UpdateTargetPos()
    {
        Vector3 mouseOffset = mousePos * cameraDist; //mult mouse vector by distance scalar 
        Vector3 ret = player.position + mouseOffset; //find position as it relates to the player
        ret += shakeOffset; //add the screen shake vector to the target
        ret.z = zStart; //make sure camera stays at same Z coord
        return ret;
    }
    Vector3 UpdateShake()
    {
        if (!shaking || Time.time > shakeTimeEnd)
        {
            shaking = false; //set shaking false when the shake time is up
            return Vector3.zero; //return zero so that it won't effect the target
        }
        Vector3 tempOffset = shakeVector;
        tempOffset *= shakeMag; //find out how far to shake, in what direction
        return tempOffset;
    }
    void UpdateCameraPosition()
    {
        Vector3 tempPos;
        tempPos = Vector3.SmoothDamp(transform.position, target, ref refVel, smoothTime); //smoothly move towards the target
        transform.position = tempPos; //update the position
    }

    public void Shake(Vector3 direction, float magnitude, float length)
    { //capture values set for where it's called
        shaking = true; //to know whether it's shaking
        shakeVector = direction; //direction to shake towards
        shakeMag = magnitude; //how far in that direction
        shakeTimeEnd = Time.time + length; //how long to shake
    }
}