using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField] private float forceHorizontal;
    [SerializeField] private float forceBrake;

    [SerializeField] private GameObject brakingEffect;
    private float speedInput;
    private float horizontalInput;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate() 
    {
        speedInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        rb.AddRelativeForce(Vector3.forward * speedInput * speed);
        moveHorizontal();
        if( speedInput > 0 && Input.GetKey(KeyCode.LeftShift)){
            brakeCar();
        }
    }

    private void moveHorizontal()
    {
        Quaternion re = Quaternion.Euler(Vector3.up * horizontalInput * forceHorizontal * Time.deltaTime );
        rb.MoveRotation(rb.rotation * re);
        brakingEffect.SetActive(false);
    }

    private void brakeCar()
    {
        if(rb.velocity.z != 0)
        {
            rb.AddRelativeForce(-Vector3.forward * forceBrake);
            brakingEffect.SetActive(true);
        }
    }
}
