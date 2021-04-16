using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : AbstractObjectInteraction
{
    public float speed = 10f;
    public Vector3 targetPos;
    public bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            SetTarggetPosition();
            MoveAObject();
        }
    }

    public override void ObjectInteraction()
    {
        isMoving = true;
    }

    public override void ObjectDeselectInteraction()
    {
        isMoving = false;
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
}