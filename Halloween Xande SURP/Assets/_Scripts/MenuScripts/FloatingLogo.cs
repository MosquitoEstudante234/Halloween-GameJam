using UnityEngine;

public class FloatingLogo : MonoBehaviour
{
    public float floatSpeed = 1f; 
    public float floatAmplitude = 10f;

    private Vector3 initialPosition; 

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
