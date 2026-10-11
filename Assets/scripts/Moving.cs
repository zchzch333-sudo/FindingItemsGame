
using UnityEngine;

public class Moving : MonoBehaviour
{
    public Vector2 velocity;
    public Rigidbody2D myBody;

    public float minX;
    public float maxX;

    void Update()
    {
        MoveObject();

        if (transform.position.x > maxX)
        {
            velocity.x = -10;
        }

        if (transform.position.x < minX)
        {
            velocity.x = 10;
        }
    }

    void MoveObject()
    {
        myBody.MovePosition(
            (Vector2)transform.position + velocity * Time.deltaTime);
    }
}
