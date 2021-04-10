using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moving;
    public int maxMoveSpeed;
    public float turning;
    public int maxTurnSpeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update once per Timestep
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * moving * Time.deltaTime);
        transform.Rotate(new Vector3(0,1,0) * turning * Time.deltaTime);
    }

    // Update once per frame
    void Update()
    {
        moving = Input.GetAxis("Vertical") * maxMoveSpeed;
        turning = Input.GetAxis("Horizontal") * maxTurnSpeed;

        //GameQuit
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    // Update after and only after Update() has finished
    void LateUpdate()
    {

    }
}