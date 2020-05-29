using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotateSpeed = 45f;

    public char axis = 'Z';

    // Update is called once per frame
    void Update()
    {
        if (axis == 'X')
        {
            this.transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0);
        }
        else if (axis == 'Y')
        {
            this.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
        else if (axis == 'Z')
        {
            this.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }

    }
}
