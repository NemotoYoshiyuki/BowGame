using UnityEngine;

public class DestoryArea : MonoBehaviour
{
    public GameObject Bow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Arrow")
        {
            Destroy(collision.gameObject);
            Bow.GetComponent<Bow>().createArrow();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
