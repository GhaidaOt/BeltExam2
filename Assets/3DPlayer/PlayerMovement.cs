using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject pt;
    public SoundManager sm;
    // How fast the Player will move
    [SerializeField] private float playerSpeed;

    // This should be an empty child of the camera, and is the Transform we will be using to update our Player's directional movement
    [SerializeField] private Transform cameraReference;

    // The Player's Rigidbody Component
    private Rigidbody rb;

    // The value we will be using to determine which direction the player faces while moving
    private float facing;

    private Animator an;

    // Start is called before the first frame update
    private void Start()
    {
        // Sets the rotation of the empty child on our camera to match the camera's upon starting the game
        cameraReference.eulerAngles = new Vector3(0, 0, 0);

        // Directly grabs the Player's Rigidbody Component
        rb = GetComponent<Rigidbody>();
        an = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Creates float values out of our inputs multiplied by the amount of speed we set
        float xMovement = Input.GetAxis("Horizontal") * playerSpeed;
        float zMovement = Input.GetAxis("Vertical") * playerSpeed;

        // Vector3 values made up of our input values
        Vector3 movement = new Vector3(xMovement, 0, zMovement);

        movement = cameraReference.TransformDirection(movement);

        // Generates movement in the Player's Rigidbody using the Vector3 values from above
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Takes our player's movement to calculate which angle our player should be rotating towards
        if (movement.x != 0 || movement.z != 0) {
            facing = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            an.SetBool("isRunning", true);
        } else
        {
            an.SetBool("isRunning", false);

        }

        // Rotates our player to face in the direction it is moving towards
        rb.rotation = Quaternion.Euler(0, facing, 0);

        // Locks our camera reference's Transform to 0 
        cameraReference.eulerAngles = new Vector3(0, cameraReference.eulerAngles.y, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            Timer.timerOn = false;
            sm.WinSound();
            pt.SetActive(true);
        }

        if (collision.gameObject.CompareTag("GreenPull") || collision.gameObject.CompareTag("YellowPull"))
        {
            an.SetBool("isPushing", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        an.SetBool("isPushing", false);
    }
}