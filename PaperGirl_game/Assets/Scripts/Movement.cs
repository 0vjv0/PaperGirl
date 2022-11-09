/* Simple player movemet for prototype*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 12f;

    public bool IsFinished = false;

    void Update()
    {
        if(!IsFinished)
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
