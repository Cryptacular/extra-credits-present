using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    public float Speed = 10.0f;
    public bool IsWalking = false;

	void Update () {
        var x = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        transform.Translate(x, 0, 0);
        IsWalking = System.Math.Abs(x) > 0.1;

        var IsFacingLeft = x < 0;
        this.GetComponent<SpriteRenderer>().flipX = IsFacingLeft;
    }
}
