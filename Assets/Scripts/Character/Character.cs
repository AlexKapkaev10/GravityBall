using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, iControllable
{

    [SerializeField ]private float jumpSpeed;

    private bool isGround;

    private bool isGameStarting;

    private float checkUpFail;

    private float checkDownFail;

    private Rigidbody2D rg;

    private bool isUp;

    private bool isDead;

    private void Start()
    {
        SetStartSettings();
    }

    private void Update()
    {
        CheckFail();
    }

    private void SetStartSettings()
    {
        rg = GetComponent<Rigidbody2D>();

        checkUpFail = GameController.instance.GetFailPoint(true);

        checkDownFail = GameController.instance.GetFailPoint(false);
    }

    public void Move()
    {
        if (!isGround || isDead) return;

        Vector2 jumpForce;

        if (!isUp)
        {
            isUp = true;

            rg.gravityScale = -1;

            jumpForce = Vector2.up;
        }
        else
        {
            isUp = false;

            rg.gravityScale = 1;

            jumpForce = Vector2.down;
        }

        rg.AddForce(jumpForce * jumpSpeed, ForceMode2D.Impulse);

        if (isGround) isGround = false;
    }

    private void CheckFail()
    {
        if (!isGameStarting) return;

        if (isUp)
        {
            if (transform.position.y > checkUpFail)
            {
                GameController.instance.GameOver();

                isDead = true;
            }
        }
        else
        {
            if (transform.position.y < checkDownFail)
            {
                GameController.instance.GameOver();
                isDead = true;
            }
        }

        if (isDead) Destroy(gameObject, 3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<iCollision>() != null)
        {
            collision.gameObject.GetComponent<iCollision>().Collision(isGameStarting);
        }

        if (!isGameStarting) isGameStarting = true;

        isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(isGround)
        {
            GameController.instance.GameOver();

            isDead = true;

            rg.AddForce(new Vector2(0, -rg.gravityScale * 300), ForceMode2D.Force);

            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
