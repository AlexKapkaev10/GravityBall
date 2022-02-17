using UnityEngine;

public class CharacterMover : MonoBehaviour, iControllable
{
    [SerializeField] private bool isGround;

    private Vector3 landingPoint;

    private Rigidbody2D rg;

    private bool isUp;

    private float gravity;

    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();

        gravity = Physics2D.gravity.y;
    }

    private void Update()
    {
        if (isGround)
        {
            if (transform.position.y < landingPoint.y)
            {
                GameController.instance.GameOver();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;

        landingPoint = transform.position;
    }

    public void Move()
    {
        if (isGround) isGround = false;

        if (!isUp)
        {
            isUp = true;

            Physics2D.gravity = new Vector2(0, -gravity);
        }
        else
        {
            isUp = false;

            Physics2D.gravity = new Vector2(0, gravity);
        }
    }
}
