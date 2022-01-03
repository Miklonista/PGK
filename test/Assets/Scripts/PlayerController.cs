using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //referencje
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform cam;

    //ruch w plaszczyznie X Z
    [SerializeField] private float speed = 6f;
    private float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    //skok
    private float groundedTimer;
    [SerializeField] private float jumpVelocity = 2.0f;
    [SerializeField] private float jumpHeight = 2.0f;
    [SerializeField] private float g = 4 * 9.81f; // wieksza grawitacja powoduje lepsza dynamike ruchu - przyspiesza predkosc skoku 

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // poruszanie si�
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, 0f, z).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        //skok
        bool groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            // czas odnowienia skoku - lepiej działa 
            groundedTimer = 0.2f;
        }
        if (groundedTimer > 0)
        {
            groundedTimer -= Time.deltaTime;
        }

        if (groundedPlayer && jumpVelocity < 0)
        {
            jumpVelocity = 0f;
        }

        //ciagle dzialanie grawitacji
        jumpVelocity -= g * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            // gracz musial spasc na jakas powierzchnie, zeby moc skoczyc znowu
            if (groundedTimer > 0)
            {
                // 0 dopoki znowu nie dotkniemy podloza
                groundedTimer = 0;

                // wzor na predkosc skoku w zaleznosci od wysokosci i grawitacji w naszej grze 
                jumpVelocity += Mathf.Sqrt(jumpHeight * 2 * g);
            }
        }

        controller.Move(new Vector3(0f, jumpVelocity * Time.deltaTime, 0f));
        // Debug.Log(controller.isGrounded);
    }

}

