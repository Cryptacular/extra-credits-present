using UnityEngine;

public class WaterTriggerController : MonoBehaviour
{
    public GameObject initiator;
    public GameObject water;
    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == initiator && !activated)
        {
            activated = true;
            var rb = water.GetComponent<Rigidbody2D>();

            rb.velocity = new Vector2(0, 1);
        }
    }

}
