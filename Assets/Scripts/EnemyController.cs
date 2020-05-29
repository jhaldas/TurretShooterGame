using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    private NavMeshAgent agent;

    private Animator animator;

    public EnemyStats myStats;

    public float maxHP = 10f;

    private float currentHP;

    public Transform target;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        currentHP = maxHP;
    }


    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        agent.SetDestination(target.position);
    }

    /*
    void Die()
    {
        animator.SetBool("IsDead", true);
        player.GetComponent<PlayerController>().AddMoney(5);
        agent.enabled = false;
        Destroy(healthbarFrame);
        Destroy(this.gameObject, 2f);
    }
    */
}
