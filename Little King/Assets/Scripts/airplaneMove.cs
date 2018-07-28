using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airplaneMove : MonoBehaviour {

    public float speedForward = 5.0f;
    public float speedMove = 5.0f;
    public float startTimeSlow = 8.0f;      //when does the airplane start to get slower
    public float intervalsForSlow = 1.0f;   //how many seconds does it need to get slower again

    private float timeBetweenIntervals;    //the amount of the that has passed since the last slow has gone through
    private float amountOfSlow = 0.5f;  
    private float horizontalInput;
    private float timeFromStart;
    private Vector3 forwardVector = new Vector3(0, 0, 1);
    private Vector3 moveVector = new Vector3(1, 0, 0);
    Rigidbody rb;
   

    void Start() {
        rb = GetComponent<Rigidbody>();
        timeBetweenIntervals = intervalsForSlow;
        
     }

    // Update is called once per frame
    void Update() {

        timeFromStart = Time.fixedTime;
        horizontalInput = Input.GetAxisRaw("Horizontal"); 

        rb.transform.Translate(forwardVector * speedForward * Time.deltaTime);  //Forward movement
        
        rb.AddForce(moveVector * horizontalInput * speedMove); //Horizontal movement

        timeBetweenIntervals += Time.deltaTime;

        if (timeFromStart > startTimeSlow && intervalsForSlow <= timeBetweenIntervals && speedMove >= 0)   //Movement Slow
        {
            timeBetweenIntervals = 0.0f;
            speedMove -= amountOfSlow;
            
        }





        Debug.Log(timeFromStart);


	}
}
