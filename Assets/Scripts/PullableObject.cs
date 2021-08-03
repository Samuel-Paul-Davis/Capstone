using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullableObject : AbstractObjectInteraction
{
    public float speed = 10f;
    public Vector3 targetPos = Vector3.zero;
    public bool isMoving;
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            MoveAObject();
        }

    }

    public override void ObjectInteraction()
    {
        isActive = true;
    }

    public override void ObjectDeselectInteraction()
    {
        isActive = false;
    }

    void SetTarggetPosition()
    {
        targetPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        isMoving = true;
    }

    void MoveAObject()
    {
        float xIpt = Input.GetAxisRaw("Horizontal");
        float yIpt = Input.GetAxisRaw("Vertical");
        Vector2 inputs = new Vector2(xIpt, yIpt);
        float mag = inputs.magnitude;

        if (mag > 0)
        {
            gameObject.GetComponentInParent<Rigidbody>().AddForce(mag * 10 * GameObject.FindGameObjectWithTag("Player").transform.forward, ForceMode.Impulse);
            isActive = false;
        }
    }
}