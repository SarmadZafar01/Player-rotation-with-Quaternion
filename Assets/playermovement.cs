using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour


{

    public float speed;
    public float rotationspeed;


    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 movedirection = new Vector3(horizontal,0f,vertical);
        float magnitude = movedirection.magnitude;
        magnitude = Mathf.Clamp01(magnitude);  
        movedirection.Normalize();

        transform.Translate(movedirection* speed* magnitude* Time.deltaTime, Space.World);

        if (movedirection != Vector3.zero)
        {
            Quaternion rorate = Quaternion.LookRotation(movedirection,Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rorate, rotationspeed* Time.deltaTime);
        }


    }
}
