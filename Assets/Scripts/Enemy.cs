using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    private NavMeshAgent agent;

    public GameObject player;

    private Animator animator;

    public float maxHP = 10f;

    private float currentHP;

    public Image healthbar;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        healthbar.fillAmount = currentHP/maxHP;

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        agent.enabled = false;
        Destroy(this.gameObject, 2f);
    }
}
