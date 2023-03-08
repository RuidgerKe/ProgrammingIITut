using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundlayer, playerlayer;


    //patrol 
    public Vector3 walkPoint;
     bool walkpointSet;
    public float walkpointRange;

    //atk
    public float timeinbetweenatk;
    bool alreadyAtked;
    public GameObject projectile;
    public GameObject projectiePos;


    //states
    public float sightrange, atkrange;
     bool playerinSightrange, playerInAttackRange;


    private void Awake()
    {
        //agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        playerinSightrange = Physics.CheckSphere(transform.position, sightrange, playerlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, atkrange, playerlayer);

        if (!playerinSightrange && !playerInAttackRange) Patrol();
        if (playerinSightrange && !playerInAttackRange) Chase();
        if (playerInAttackRange && playerinSightrange) Beatup();
        
    }

    private void Patrol()
    {
        if (!walkpointSet) SearchWalkPoint();

        if (walkpointSet)
        {
            agent.SetDestination(walkPoint);
           
        }
        Vector3 ditanceWalkPoint = transform.position - walkPoint;
        if (ditanceWalkPoint.magnitude < 1f)
        {
            walkpointSet = false;
        }

    }
    private void SearchWalkPoint()
    {
        float randomx = Random.Range(-walkpointRange, walkpointRange);
        float randomz = Random.Range(-walkpointRange, walkpointRange);

        walkPoint = new Vector3(transform.position.x + randomx, transform.localPosition.y, transform.position.z + randomz);
        if (Physics.Raycast(walkPoint, -transform.up, 1f, groundlayer))
        {
            walkpointSet = true;
        }

    }



    private void Chase() 
    {
        agent.SetDestination(player.position);
    }

    private void Beatup()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAtked)
        {
            Rigidbody bulletrb = Instantiate(projectile, projectiePos.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            bulletrb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            Destroy(bulletrb.gameObject, 1);
            alreadyAtked = true;
            Invoke("ResetAttack", timeinbetweenatk);
        }
    }

    private void ResetAttack()
    {
        alreadyAtked = false;
    }
    

    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightrange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, atkrange);
    }



}
