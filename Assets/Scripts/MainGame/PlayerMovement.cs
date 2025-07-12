using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float playerspeed = 5f;
    public float rotation = 200f;
    public Rigidbody2D rb;
    public float playerradius = 0.5f;

    private float moveinput;
    private float turninput;
    private float minX, maxX, minY, maxY;

    void Start()
    {
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Camera.main.aspect;

        Vector3 camPos = Camera.main.transform.position;


        minX = camPos.x - horzExtent + playerradius;
        maxX = camPos.x + horzExtent - playerradius;
        minY = camPos.y - vertExtent + playerradius;
        maxY = camPos.y + vertExtent - playerradius;
    }
    // Update is called once per frame
    void Update()
    {

        turninput = -Input.GetAxisRaw("Horizontal");
        moveinput = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {

        rb.MoveRotation(rb.rotation + turninput * rotation * Time.fixedDeltaTime);


        Vector2 direction = transform.up;
        Vector2 newPos = rb.position + direction * moveinput * playerspeed * Time.fixedDeltaTime;

        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

        rb.MovePosition(newPos);
    }

    

}
