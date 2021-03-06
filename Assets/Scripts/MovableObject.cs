using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : AbstractObjectInteraction
{
    public float speed = 10f;
    public Vector3 targetPos;
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
            SetTarggetPosition();
        }

        if (isMoving)
        {            
            MoveAObject();
        }
    }

    public override void ObjectInteraction()
    {
        isActive = true;
        GetComponent<Rigidbody>().useGravity = false;
    }

    public override void ObjectDeselectInteraction()
    {
        isActive = false;
        isMoving = false;
        GetComponent<Rigidbody>().useGravity = true;
    }

    void SetTarggetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
            targetPos = ray.GetPoint(point);

        isMoving = true;
    }

    void MoveAObject()
    {
        transform.LookAt(targetPos);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (transform.position == targetPos)
            isMoving = false;
    }

    //overloading Discover() -- used by Scanner Tool
    public void Discover(Material[] materials)
    {
        Discover();

        if (gameObject.GetComponent<Renderer>().IsVisibleFrom(Camera.main))
            gameObject.GetComponent<Renderer>().materials = materials;
    }
}