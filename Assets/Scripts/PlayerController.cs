using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    [Header("Attributes")]


    public float attackRange = 8f;
    public float interactRange = 2f;

    public GameObject activeTarget = null;

    public LayerMask clickable;
    private NavMeshAgent agent;
    private Camera mainCamera;

    public GameObject moveTarget;

    public Animator animator;

    public int coins = 0;

    private Vector3 curPos;
    private Vector3 lastPos;

    public Interactable focus;

    Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main;
        animator.SetInteger("Speed", 0);

        EnableMoveTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (focus != null)
        {
            FollowTarget(focus);
        }
        else
        {
            StopFollowingTarget();
        }

        if (target != null)
        {
            //agent.SetDestination(target.transform.position);
            FaceTarget();
        }

        // Animation Control
        curPos = this.transform.position;
        if (curPos == lastPos)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }
        lastPos = curPos;
    }

    public void MovePlayer(Vector3 point, int hasTarget)
    {

        agent.SetDestination(point);

        if (hasTarget == 0)
        {
            EnableMoveTarget();
            moveTarget.transform.position = point;
        }
        else
        {
            DisableMoveTarget();
        }
    }


    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius;
        agent.updateRotation = false;

        target = newTarget.interactionTransform;
        //agent.SetDestination(target.transform.position);

        DisableMoveTarget();
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.blue; 
        Gizmos.DrawWireSphere(transform.position, interactRange);

    }

    void EnableMoveTarget()
    {
        moveTarget.GetComponentInChildren<Renderer>().enabled = true;
    }

    void DisableMoveTarget()
    {
        moveTarget.GetComponentInChildren<Renderer>().enabled = false;
    }

    public void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
        newFocus.OnFocused(transform);
        newFocus.OnFocused(transform);
    }

    public void RemoveFocus()
    {
        focus = null;
    }

    public void AddMoney(int money)
    {
        coins += money;
    }

    public bool InRange()
    {
        float dis = Vector3.Distance(transform.position, target.transform.position);
        if (dis <= interactRange)
        {
            return true;
        }
        return false;
    }
}
