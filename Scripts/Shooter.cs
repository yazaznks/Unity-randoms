using UnityEngine;

public class Shooter : MonoBehaviour{
    public GameObject firePoint;
    public GameObject ballPrefab;
    public float power;
    public float rotationSpeed;

    Vector3 currentPosition;
    Quaternion currentRotation;


    void Start(){
        currentPosition = firePoint.transform.position ;
        currentRotation = transform.rotation;
        // predict();
    }

    public Vector3 calculateForce(){
        return transform.forward * power;
    }

    void shoot(){
        GameObject ball = GameObject.FindGameObjectWithTag("Player");
        ball.GetComponent<Rigidbody>().AddForce(calculateForce(), ForceMode.Impulse);
        LevelManager.instance.shoot();
    }

    void Update(){
        
        if (Input.GetMouseButtonDown(0)){
        Vector3 mousePos = Input.mousePosition;
        if (mousePos.y > 130 && mousePos.y < 220 && mousePos.x > 400 && mousePos.x < 500){
            predict();
        }}
            // line.gameObject.SetActive(true);
            // line.SetPosition(0, transform.position);
            // start = mousePos.y;

        // if(currentRotation != transform.rotation){
        //    predict();
        // }   

        // if(currentPosition != transform.transform.position){
        //    predict();
        // }       
    
        currentRotation = transform.rotation;

        if(Input.GetKeyUp(KeyCode.Space)){
            if(LevelManager.instance.currentShoots.val > 0){
                shoot();
            }
        }
    }

    void predict(){
        PredictionManager.instance.predict(ballPrefab, firePoint.transform.position, calculateForce());
    }
}
