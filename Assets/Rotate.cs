using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotateSpeed = 45f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0,rotateSpeed * Time.deltaTime);
    }
}
