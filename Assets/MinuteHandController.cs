using UnityEngine;

public class MinuteHandController : MonoBehaviour {
    public GameObject Character;
    public bool ShouldMove = false;
    private bool IsComplete = false;

    public void FixedUpdate()
    {
        if (IsComplete) return;

        if (transform.rotation.z < 0)
        {
            ShouldMove = false;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            Instantiate(Character, new Vector2(-3.33f, 5.63f), new Quaternion(0, 0, 0, 0));
            IsComplete = true;
        }

        if (ShouldMove)
        {
            transform.Rotate(0, 0, -1f, Space.Self);
        }
    }

    public void TurnMoveOn()
    {
        ShouldMove = true;
    }
}
