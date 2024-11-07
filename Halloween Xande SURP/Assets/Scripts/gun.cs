using UnityEngine;
using UnityEngine.Events;

public class gun : MonoBehaviour
{
    [HideInInspector] public Camera mainCamera;
    public Transform aimTransform;
    public float gunAngle;
    public Vector3 mousePos;
    public int gunBullets;
    public float reloadingTime;
    public int damage;
    public UnityEvent OnShoot;
    [HideInInspector] public Vector3 aimDirection;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        aimDirection = mousePos - transform.position;
        gunAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, gunAngle);

        if(Input.GetMouseButtonDown(0))
        {
            OnShoot.Invoke();
        }
    }
}
