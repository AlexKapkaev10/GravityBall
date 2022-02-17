using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour, iCollision
{
    [SerializeField] private float speed;

    private bool isStopMove;

    private bool isCollision;

    private void Start()
    {
        speed = GameController.instance.levelsData.PlatformSpeed;
    }

    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        if (isStopMove) return;

        transform.Translate(new Vector3(-1 * Time.deltaTime * speed, 0, 0));

        if (transform.position.x < -30)
        {
            Destroy(gameObject);
            GameController.instance.AllLevelsPlatform(false, this);
        } 
    }

    public void Collision(bool isGameStarting)
    {
        if (isCollision) return;

        isCollision = true;

        gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;

        GameController.instance.ScoreChange();
    }

    public void MoveMode(bool isStop)
    {
        StartCoroutine(StopDelay(isStop));
    }

    IEnumerator StopDelay(bool isStop)
    {
        yield return new WaitForSeconds(0.2f);

        isStopMove = isStop;
    }
}
