using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour
{
    float xRot, yRot = 0f;
    public Rigidbody ball;
    public float rotationSpeed = 5f;
    public float shootPower = 30f;
    float start;
    // Camera camera;
    Transform ballTransform;
    
    // Start is called before the first frame update
    Vector3 checkpoint;
    void Start()
    {
        // camera = Camera.main;
        checkpoint = new Vector3 (0,0.504f,0);
     
        ballTransform = ball.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        //transform.position = ball.position;
        if (Input.GetMouseButtonDown(0)){
    //         line.positionCount = 2;
        
    //   // We offset by forward so it's within the cameras viewpoint, else it wouldn't be renderered.
    //         line.SetPosition(0, transform.position);
    //         line.SetPosition(1, transform.position);

            
        if (mousePos.y > 130 && mousePos.y < 220 && mousePos.x > 400 && mousePos.x < 500)
            // line.gameObject.SetActive(true);
            // line.SetPosition(0, transform.position);
            start = mousePos.y;

    }
        if (Input.GetMouseButton(0)){

            if (mousePos.y < Screen.height/3){
                xRot += Input.GetAxis("Mouse X")*rotationSpeed;}

            if (mousePos.y > Screen.height/3){
                xRot -= Input.GetAxis("Mouse X")*rotationSpeed;}

            if (mousePos.x < Screen.width/2){
                xRot -= Input.GetAxis("Mouse Y")*rotationSpeed;}

            if (mousePos.x > Screen.width/2){
                xRot += Input.GetAxis("Mouse Y")*rotationSpeed;}

            
            // if (yRot > 0)
            //     shootPower = 0f;
            //     line.SetHeight(0.1f,0);  
            // }
            print("x" + mousePos.y);
            transform.rotation = Quaternion.Euler(16f,xRot,0f);
            
            print(Screen.height/4);
            
            //line.numCapVertices = 20;
            
            // Vector3 mousePos = Input.mousePosition;
            // float difference = start / mousePos.y;
            // print (difference);
            // print("y" + mousePos.y);
            // line.SetPosition(1, new Vector3(0f,transform.position.x + transform.forward.x * (difference/5),0f));
        }

        // if (Input.GetMouseButtonUp(0)){
        //     ball.velocity = transform.forward * shootPower;
        //     line.gameObject.SetActive(false);
        // }
        if (ball.transform.position.y <-3){
            ball.velocity = Vector3.zero;
            ball.angularVelocity = Vector3.zero;
            ball.transform.position = checkpoint;
         }
    }
    
}
