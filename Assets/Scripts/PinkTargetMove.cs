using UnityEngine;
using System.Collections;

public class PinkTargetMove : MonoBehaviour
{
    Animator animator;
    Vector3 movement;
    int movementFlag = 0;

    public float Speed = 1;
  

    // Update is called once per frame
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        StartCoroutine("ChangeMovement");
    }

    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range(0, 5);

        if (movementFlag == 0)
            animator.SetBool("isMoving", false);
        else
            animator.SetBool("isMoving", true);

        yield return new WaitForSeconds(0.2f);

        StartCoroutine("ChangeMovement");
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        {
            if (movementFlag == 1)
            {
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(-1.6f, 1.6f, 1.6f);
            }
            else if (movementFlag == 2) {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            }
            else if (movementFlag ==3)
            {
                moveVelocity = Vector3.up;
                transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            }
            else if (movementFlag == 4)
            {
                moveVelocity = Vector3.down;
                transform.localScale = new Vector3(1.6f, -1.6f, 1.6f);
            }

        }
            
        transform.position += moveVelocity * Speed * Time.deltaTime;

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;

    }
}
