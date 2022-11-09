using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float tankHP = 200000.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;
    [SerializeField] float currentSpeed;
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsGrounded;
    // Start is called before the first frame update
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = GameObject.Find("CENTEROFMASS").transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.forward * Time.deltaTime * tankSpeed * verticalInput);
        if (isonGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * verticalInput * tankHP);
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput);
            currentSpeed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
        }
        speedText.SetText("Speed:" + currentSpeed + "mph");
    }
    bool isonGround()
    {
        wheelsGrounded = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsGrounded++;
            }
        }
        if (wheelsGrounded == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
