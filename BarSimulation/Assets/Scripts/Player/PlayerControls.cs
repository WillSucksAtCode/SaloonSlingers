using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControls : MonoBehaviour
{
    public Rigidbody reggy;
    public float speed;
    Vector2 movementDir = Vector2.zero;
    private InputAction move;
    private InputAction interact;
    public PlayerInputs playerContr;

    AudioSource audioSource;



    [SerializeField] float sprintSpeedIncrease = 15.0f;
    public float originalSpeed;

    [SerializeField] GameObject camera;
    [SerializeField] LayerMask interactibleMask;
    [SerializeField] float interactRange;
    [SerializeField] GameObject interactText;
    

    // Start is called before the first frame update
    void Awake()
    {
        originalSpeed = speed;
        playerContr = new PlayerInputs();
        audioSource = GetComponent<AudioSource>();
        reggy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        movementDir = move.ReadValue<Vector2>();
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = originalSpeed + sprintSpeedIncrease;
        }
        else
        {
            speed = originalSpeed;
        }

        CheckIfInteractible();
    }

    private void FixedUpdate()
    {
        reggy.velocity = transform.right * movementDir.x * speed + transform.forward * movementDir.y * speed;
        if (reggy.velocity != new Vector3(0, 0, 0))
        {
            audioSource.mute = false;
        } else
        {
            audioSource.mute = true;
        }
    }
    private void OnEnable()
    {
        move = playerContr.Player.Move;
        move.Enable();
        interact = playerContr.Player.Interact;
        interact.Enable();
        interact.performed += Interact;
    }
    private void OnDisable()
    {
        move.Disable();
        interact.Disable();
    }


    private void Interact(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, interactRange, interactibleMask))
        {
            Debug.Log(hit.transform.name);
            var interactible = hit.transform.gameObject.GetComponent<IInteractible>();
            if (interactible == null) return;
            interactible.Interact();


        }
    }

    void CheckIfInteractible()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, interactRange, interactibleMask))
        {
            interactText.SetActive(true);
        } else
        {
            interactText.SetActive(false);
        }
    }
    
}
