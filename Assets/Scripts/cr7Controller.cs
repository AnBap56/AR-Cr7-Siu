using TrueInputSystem;
using UnityEngine;

public class cr7Controller : MonoBehaviour
{
    [SerializeField] private float speed;

    private TISInputBridge tIS;
    private Animator animator;
    private Rigidbody rigidBody;
    private bool canMove = true;

    void Awake()
    {
        tIS = TISInputBridge.Instance;
    }

    void OnEnable()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Siu();
    }

    private void FixedUpdate()
    {
        if(!canMove) 
            return;

        float x = tIS.MoveDirection.x;
        float y = tIS.MoveDirection.y;

        Vector3 movement = new Vector3(x, 0, y);

        rigidBody.linearVelocity = movement * speed;

        if (movement.sqrMagnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(movement);

            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void Siu()
    {
        if(tIS.GetSkillAction("Siu"))
        {
            transform.Rotate(0f, 180f, 0f);
            
            animator.SetTrigger("Siu");
            canMove = false;
        }
    }

    public void ResetSiu()
    {
        canMove = true;
    }
}