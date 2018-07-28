using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airplaneRotation : MonoBehaviour {

    Transform objectTrans;

    void Start () {
        objectTrans = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput > 0 && objectTrans.rotation.z > -0.3f)   // rotation while movement
        {
            objectTrans.Rotate(new Vector3(0, 0, -1));
        }
        else if (horizontalInput < 0 && objectTrans.rotation.z < 0.3f)
        {
            objectTrans.Rotate(new Vector3(0, 0, 1));
        }
        else if (horizontalInput == 0)
            if (objectTrans.rotation.z < -0.01f || objectTrans.rotation.z > 0.01f)
            {
                if (objectTrans.rotation.z < 0.0f)
                    objectTrans.Rotate(new Vector3(0, 0, 1) * 0.5f);
                else if (objectTrans.rotation.z > 0.0f)
                    objectTrans.Rotate(new Vector3(0, 0, -1) * 0.5f);
            }
        
    }
}
