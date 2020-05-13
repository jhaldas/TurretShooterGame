using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    private GameObject Target;
    private Vector3 targetPos;

    // Use this for initialization
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("MainCamera");
        targetPos = Camera.main.WorldToScreenPoint(Target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + Target.transform.rotation * Vector3.forward, Target.transform.rotation * Vector3.up);
    }
}
