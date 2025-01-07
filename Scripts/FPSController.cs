using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;


    public float lookSpeed = 2f;
    public float lookXLimit = 45f;


    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    private bool hasKey = false;  // Per sapere se il giocatore ha la chiave
    private bool nearDoor = false;  // Per sapere se il giocatore è vicino alla porta

    private bool hasKey1 = false;  // Per sapere se il giocatore ha la chiave
    private bool nearDoor1 = false;  // Per sapere se il giocatore è vicino alla porta

    // Riferimento alla porta
    public GameObject door;
    public GameObject key;

    public GameObject door1;
    public GameObject key1;

    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        #endregion

        #region Handles Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        #endregion

        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion
    }

    void OnTriggerEnter(Collider other)
    {
        // Rileva quando il giocatore entra nell'area della chiave
        if (other.CompareTag("Key"))
        {
            hasKey = true;  // Il giocatore raccoglie la chiave
            Destroy(other.gameObject);  // Rimuove la chiave dalla scena
            Debug.Log("Chiave raccolta!");
        }

        // Rileva quando il giocatore entra nell'area della porta
        if (other.CompareTag("Door"))
        {
            nearDoor = true;
            door = other.gameObject;  // Riferimento alla porta
        }






        // Rileva quando il giocatore entra nell'area della chiave
        if (other.CompareTag("Key1"))
        {
            hasKey1 = true;  // Il giocatore raccoglie la chiave
            Destroy(other.gameObject);  // Rimuove la chiave dalla scena
            Debug.Log("Chiave raccolta!");
        }

        // Rileva quando il giocatore entra nell'area della porta
        if (other.CompareTag("Door1"))
        {
            nearDoor1 = true;
            door1 = other.gameObject;  // Riferimento alla porta
        }
    }

    void OnTriggerStay(Collider other)
    {
        // Se il giocatore è vicino alla porta e ha la chiave
        if (nearDoor && hasKey && Input.GetKeyDown(KeyCode.E))  // Quando si preme 'E'
        {
            OpenDoor();  // Apre la porta
        }



        // Se il giocatore è vicino alla porta e ha la chiave
        if (nearDoor1 && hasKey1 && Input.GetKeyDown(KeyCode.E))  // Quando si preme 'E'
        {
            OpenDoor1();  // Apre la porta
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Rileva quando il giocatore esce dall'area della porta
        if (other.CompareTag("Door"))
        {
            nearDoor = false;
        }


        // Rileva quando il giocatore esce dall'area della porta
        if (other.CompareTag("Door1"))
        {
            nearDoor1 = false;
        }
    }

    void OpenDoor()
    {
        if (door != null)
        {
            // Azione di apertura della porta (ad esempio, muoverla)
            door.SetActive(false);
            
            //door.transform.Translate(0, 3f, 0);  // Esempio di apertura spostando la porta
            Debug.Log("Porta aperta!");
        }
    }

    void OpenDoor1()
    {
        if (door1 != null)
        {
            // Azione di apertura della porta (ad esempio, muoverla)
            door1.SetActive(false);

            //door.transform.Translate(0, 3f, 0);  // Esempio di apertura spostando la porta
            Debug.Log("Porta aperta!");
        }
    }
}