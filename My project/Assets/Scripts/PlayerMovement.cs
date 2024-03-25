using System.Collections;

using System.Collections.Generic;
using TMPro;
using UnityEngine;



[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour

{
    public GameObject textObj;

    TextMeshProUGUI text;

    public Camera playerCamera;

    bool StatueInFront = false;

    ParticleManager LastStatueRef;

    public float walkSpeed = 6f;

    public float runSpeed = 12f;

    public float jumpPower = 7f;

    public float gravity = 10f;

    public float lookSpeed = 2f;

    public float lookXLimit = 45f;

    public float defaultHeight = 2f;

    public float crouchHeight = 1f;

    public float hideHeight = 0.5f;

    public bool boyInFront = false;

    public float crouchSpeed = 3f;

    int layerMask = 1 << 11;

    int layerMaskPlayer = 1 << 12;

    public bool Loud = false;

    public bool Quiet = false;

    private Vector3 moveDirection = Vector3.zero;

    private float rotationX = 0;

    private CharacterController characterController;

    public bool hidding = false;

    private bool canMove = true;



    void Start()

    {

        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;

        text = textObj.GetComponent<TextMeshProUGUI>();

    }



    void Update()

    {
        
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        Vector3 right = transform.TransformDirection(Vector3.right);



        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;

        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;

        float movementDirectionY = moveDirection.y;

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);


        Loud = isRunning;

       

        moveDirection.y = movementDirectionY;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
       
        RaycastHit hit = new RaycastHit();
         
        if (!hidding) { 
            
            
            StatueInFront = Physics.Raycast(ray, out hit, 5, layerMask);
            if (StatueInFront) {
                text.text = "Press E to pray";
            }
            else
            {
                text.text = "";
            }
        }
        if (Input.GetKeyDown(KeyCode.E)){
            if (!hidding)
            {
                if (StatueInFront)
                {
                   
                    LastStatueRef = hit.transform.gameObject.GetComponent<ParticleManager>();
                    hit.transform.gameObject.GetComponent<ParticleManager>().playing = true;
                    canMove = false;
                    hidding = true;
                    characterController.height = hideHeight;
                }

            }
            else 
            {
                LastStatueRef.playing = false;
                canMove = true;
                hidding = false;
                characterController.height = defaultHeight;
            }

        }
        
        if (!characterController.isGrounded)
        {

            moveDirection.y -= gravity * Time.deltaTime;

        }

        

        if (Input.GetKey(KeyCode.LeftControl) && canMove)

        {

            characterController.height = crouchHeight;

            walkSpeed = crouchSpeed;

            runSpeed = crouchSpeed;

            Quiet = true;

        }

        else if(Input.GetKeyUp(KeyCode.LeftControl) && canMove)

        {

            characterController.height = defaultHeight;
                
            walkSpeed = 6f;

            runSpeed = 12f;

            Quiet = false;

        }



        characterController.Move(moveDirection * Time.deltaTime);



       

            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;

            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

        

    }

}