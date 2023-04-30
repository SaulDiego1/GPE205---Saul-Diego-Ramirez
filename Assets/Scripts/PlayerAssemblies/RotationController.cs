using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    //Here is were we will set the rotation angle we want to be locked on.
    Transform playerRotation;
    public float fixedRotation = 0;

     void Start ()
    {
        playerRotation = transform;
    }
    //Since we want to still move on our y-axis we will only lock the x-axis and z-axis to our pawns.
     void Update ()
    {
        playerRotation.eulerAngles = new Vector3 (fixedRotation, playerRotation.eulerAngles.y, fixedRotation);
    }
}
