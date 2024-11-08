using System.Collections;
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

    bool cooldown;
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

        if(Input.GetButtonDown("Fire1"))
        {
            if(cooldown)
            {
                return;
            }
            OnShoot.Invoke();
            StartCoroutine(Cooldown());
        }
    }


    IEnumerator Cooldown()
    {
        cooldown = true;
        yield return new WaitForSeconds(1);
        cooldown = false;
    }
}
