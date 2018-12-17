using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRising : MonoBehaviour
{
    public GameObject initiator;
    public GameObject water;
    private bool activated = false;



    void OnCollisionEnter(Collision col)
    {
        activated = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        activated = true;
        Debug.Log("entered");
    }

    private void Update()
    {
        if (activated)
        {
            throw new System.Exception();
            water.transform.Translate(Vector3.up * Time.deltaTime);
        }
    }
}
