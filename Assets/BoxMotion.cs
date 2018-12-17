using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMotion : MonoBehaviour
{
    public GameObject initiator;
    private bool activated = false;



    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == initiator && !activated)
        {
            this.gameObject.GetComponent<Rigidbody2D>().WakeUp();
            activated = true;
        }
    }
}
