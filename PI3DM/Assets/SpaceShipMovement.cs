using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : MonoBehaviour {

    private Vector3 movement;
    private Rigidbody rb;
    public float speed;
    private float timeSpeed;
  //  public float rotationSpeed;




    [Header("Axis")]
    public float h;
    public float v;

    [Header ("Keys")]
    public KeyCode up;
    public KeyCode down;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        timeSpeed = speed * Time.deltaTime;
    }
	
	void FixedUpdate ()
    {
        Move();
        
	}

    void Move ()
    {
        movement = new Vector3(-v, 0, h);
        h = Input.GetAxis("Horizontal") * timeSpeed;
        v = Input.GetAxis("Vertical") * timeSpeed;

        if(Input.GetAxis("Horizontal") > 0){
        	Rotate(1);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
        	Rotate(2);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            Rotate(0);
        }

        //rb.AddTorque(new Vector3 (-v,0,0), ForceMode.Acceleration);

        rb.velocity = movement;

        if (Input.GetKey(up))
        {
            rb.velocity = Vector3.up * timeSpeed;
        }

        if (Input.GetKey(down))
        {
            rb.velocity = Vector3.down * timeSpeed;
        }
    }
    float i = -90;
    float ii = 0;
    void Rotate2(int sentido)
    {
        if (sentido == 1)
        {
            ii = Mathf.Lerp(ii, 50, 6 * Time.deltaTime);
            transform.eulerAngles = new Vector3(-ii, 0, 0);
        }
        else
        {
            if (sentido == 2)
            {
                transform.eulerAngles = new Vector3(-ii, 0, 0);
                ii = Mathf.Lerp(ii, -50, 6 * Time.deltaTime);
            }
            else
            {
                ii = Mathf.Lerp(ii, 0, 6 * Time.deltaTime);
                transform.eulerAngles = new Vector3(-ii, 0, 0);

            }
        }
    }

    void Rotate(int sentido)
    {
        if (sentido == 1)
        {
            i = Mathf.Lerp(i, 50, 6 * Time.deltaTime);
            transform.eulerAngles = new Vector3(-i, 0, 0);
        }
        else
        {
            if (sentido == 2)
            {
                transform.eulerAngles = new Vector3(-i, 0, 0);
                i = Mathf.Lerp(i, 120, 6 * Time.deltaTime);
            }
            else
            {
                i = Mathf.Lerp(i, 90, 6 * Time.deltaTime);
                transform.eulerAngles = new Vector3(-i, 0, 0);

            }
        }
    }
}
