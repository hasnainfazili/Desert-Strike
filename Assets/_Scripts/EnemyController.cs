using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target; 
    public float detectionRange = 20f; 
    public float attackRange = 10f; 
    public int damage = 10; 
    public float attackCooldown = 2f; 

    private NavMeshAgent navMeshAgent;
    public Animator animator;
    private bool isAttacking = false;
    private Health playerHealth;
    public GameObject bulletPrefab;
    public Transform shootPoint;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Assuming player has a Health script attached
        playerHealth = target.GetComponent<Health>();

        if (target == null || playerHealth == null)
        {
            Debug.LogError("Target or playerHealth not assigned to EnemyController script!");
        }
    }

    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= attackRange && !isAttacking)
        {
            isAttacking = true;
            StartCoroutine(Attack());
        }
        else if (distanceToTarget <= detectionRange)
        {
            navMeshAgent.SetDestination(target.position);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    IEnumerator Attack()
    {
        animator.SetTrigger("Attack");
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        yield return new WaitForSeconds(0.5f);

        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget <= attackRange)
        {
        }

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }
}
