using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public float speed;
    public Vector3 target;
    Transform targetMarker;
    public bool clicked;

    Vector3 initialAngles;
    public float startY;
    public float endY;
    void Start () 
    {
        initialAngles = transform.rotation.eulerAngles;
    }

    void Update()
    {
        if (clicked)
        {            
            if (startY == 50)
            {
            transform.Rotate(  0, startY, 0);
            } else 
            {
                transform.Rotate(  0, -startY, 0);
            }
            //transform.position = Vector3.RotateTowards(transform.position, target, 90, 10);
            //transform.Rotate(Vector2.up * speed * Time.deltaTime);            
            //transform.Rotate(Vector3.up, speed);                        
        }
    }
    public void OneHand()
    {
        clicked = true;
        //transform.position = Vector3.MoveTowards (transform.position, target, Time.deltaTime * speed);
    }
    public void DelayHand()
    {

    }
}
