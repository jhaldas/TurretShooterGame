using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{



    public LayerMask clickable;
    private NavMeshAgent agent;
    private Camera mainCamera;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        // Pathing
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray myRay = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(myRay, out hitInfo, 100, clickable))
                {
                    agent.SetDestination(hitInfo.point);
                }
            }
        }
    }
}
