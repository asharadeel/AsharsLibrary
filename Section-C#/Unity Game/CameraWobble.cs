using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Unity
18.03.2024
v 1.0.0
made for Hot Pursuit 
*/

public class CameraWobble : MonoBehaviour
{

    public Camera Camera;
    public float wobbleSpeed;
    public float wobbleAmount;
    private Vector3 initialPosition;

    void Start(){
        if (Camera != null){
            initialPosition = Camera.transform.position;
        }
    }

    void Update(){
        CameraOperation();
    }

    private void CameraOperation(){
        if (Camera != null){
            float xOffset = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount;
            float yOffset = Mathf.Sin(Time.time * wobbleSpeed * 1.2f) * wobbleAmount;

            Vector3 wobbleOffset = new Vector3(xOffset, yOffset, 0);
            Camera.transform.position = initialPosition + wobbleOffset;
        }
    }
}