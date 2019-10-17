using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Accelerometer : MonoBehaviour
{
    public bool isFlat = true;
    public GameObject up, down, left, right;
    Transform Up, Down, Left, Right;
    public Text txt;
    Rigidbody rb;

    float xMul = 10f;
    float zMul = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Up = up.transform;
        Down = down.transform;
        Left = left.transform;
        Right = right.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tilt = Input.acceleration;
        Vector3 pos = rb.transform.position;

        if (isFlat)
        {
            tilt = Quaternion.Euler(90, 0, 0) * tilt;
        }
        //pos.x += Input.GetAxis("Horizontal") * 30 * Time.deltaTime;
        //pos.z += Input.GetAxis("Vertical") * 30 * Time.deltaTime;
                
        pos.x += tilt.x * xMul *Time.deltaTime;
        pos.z += tilt.z * zMul * Time.deltaTime;

        rb.transform.position = pos;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, Left.position.x, Right.position.x),
                                        Mathf.Clamp(transform.position.y,-1000f,1000f),
                                        Mathf.Clamp(transform.position.z,Down.position.z,Up.position.z));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "hole")
        {
            txt.text = "Won";
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        txt.text = "ERRR";
    }
}
