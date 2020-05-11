using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    [Header("Attributes")]


    public float attackRange = 10f;
    public float interactRange = 2f;

    public GameObject activeTarget = null;

    public LayerMask clickable;
    private NavMeshAgent agent;
    private Camera mainCamera;

    public GameObject moveTarget;

    public Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main;
        animator.SetInteger("Speed", 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // Pathing
        if (Input.GetMouseButtonDown(1))
        {
            Ray myRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100, clickable))
            {
                MovePlayer(hitInfo);
            }
        }
        */
    }

    public void MovePlayer(RaycastHit hit, int hasTarget)
    {
        agent.SetDestination(hit.point);

        if (hasTarget == 0)
        {
            moveTarget.GetComponentInChildren<Renderer>().enabled = true;
            moveTarget.transform.position = hit.point;
        }
        else
        {
            moveTarget.GetComponentInChildren<Renderer>().enabled = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.blue; 
        Gizmos.DrawWireSphere(transform.position, interactRange);

    }


    // When the user left clicks, is sees if the thing clicked is a valid target.  If it is, it will
    // set that object as its target. 
    void SelectTarget()
    {

    }

    // Checks to see if the selected enemy is in range to shoot.  If not, the player
    // Will walk towards them.
    void CheckAttack()
    {

    }

    //Checks to see if the selected interactable is in range to interact with.  If not,
    // the player will walk towards it.
    void CheckInteract()
    {

    }
}
