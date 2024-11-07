using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{
    public int xpGain;
    Rigidbody2D body;
    bool isMagnetized;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMagnetized)
        {
            body.velocity = (PlayerLife.Instance.transform.position - transform.position) * 4;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                HealFlasks.instance.Gain(Random.Range(2,4));
                Destroy(gameObject);
                break;
            case "Magnetic":
                PlayerLife.Instance.transform.position = collision.transform.position;
                isMagnetized = true;
                break;
        }
    }
}
