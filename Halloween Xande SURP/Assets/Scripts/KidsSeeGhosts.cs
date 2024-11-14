using UnityEngine;

public class KidsSeeGhosts : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            collision.GetComponent<Animator>().SetBool("Appear", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            collision.GetComponent<Animator>().SetBool("Appear", false);
        }
    }
}
