using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject player;

    private iControllable controllable;

    private void Start()
    {
        controllable = player.GetComponent<iControllable>();
    }

    private void Update()
    {
        MouseInput();
    }

    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //if (mousePos.y > 3) return;

            controllable.Move();
        }
        else if (Input.GetMouseButtonUp(0))
        {

        }

    }
}
