using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FieldOfView : MonoBehaviour
{
    //Vision Stuff
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    //Other
    public float suspicion = 0;
    public bool suspicionLevel0 = true;
    public bool suspicionLevel1 = false;
    public bool suspicionLevel2 = false;
    public bool suspicionLevel3 = false;
    public bool suspicionLevel4 = false;

    //NAVMESH
    public Transform player;

    private NavMeshAgent guard;

    public bool chase = false;

    public Transform[] patrolPoints;
    int patrolPointIndex;
    Vector3 targetPoint;



    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());

        guard = GetComponent<NavMeshAgent>();
        UpdatePatrolDestination();

    }

    private void Update()
    {
        if (canSeePlayer == true)
        {
            chase = true;
        }
        if (chase == true)
        {
            guard.destination = player.position;
        }
        else if (chase == false)
        {
            UpdatePatrolDestination();
            if (Vector3.Distance(transform.position, targetPoint) < 1)
            {
                IteratePatrolPointIndex();
                UpdatePatrolDestination();
            }
        }

        if (suspicionLevel1 == true)
        {
            guard.speed = 3.5f;
        }
        if (suspicionLevel2 == true)
        {
            guard.speed = 5;
        }
        if (suspicionLevel3 == true)
        {
            guard.speed = 6.5f;
        }
        if (suspicionLevel4 == true)
        {
            guard.speed = 8;
        }
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (chase == true && other.CompareTag("Safe"))
        {
            chase = false;
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    IncreaseSuspicion();
                }

                else
                {
                    canSeePlayer = false;
                    DecreaseSuspicion();
                }
            }
            else
            {
                canSeePlayer = false;
                DecreaseSuspicion();
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
            DecreaseSuspicion();
        }
    }

    private void IncreaseSuspicion()
    {
        suspicion += .1f;
        if (suspicion > 1)
        {
            suspicionLevel1 = true;
            suspicionLevel2 = false;
            suspicionLevel3 = false;
            suspicionLevel4 = false;
        }
        if (suspicion > 2)
        {
            suspicionLevel1 = false;
            suspicionLevel2 = true;
            suspicionLevel3 = false;
            suspicionLevel4 = false;
        }
        if (suspicion > 3)
        {
            suspicionLevel1 = false;
            suspicionLevel2 = false;
            suspicionLevel3 = true;
            suspicionLevel4 = false;
        }
        if (suspicion > 4)
        {
            suspicionLevel1 = false;
            suspicionLevel2 = false;
            suspicionLevel3 = false;
            suspicionLevel4 = true;
        }
    }

    private void DecreaseSuspicion()
    {
        if (suspicionLevel1 == true)
        {
            suspicion = Mathf.Clamp(suspicion, 1.1f, 2);
            while (suspicion >= 1.1f)
            {
                suspicion -= .1f;
            }
        }
        if (suspicionLevel2 == true)
        {
            suspicion = Mathf.Clamp(suspicion, 2.1f, 3);
            while (suspicion >= 2.1f)
            {
                suspicion -= .1f;
            }
        }
        if (suspicionLevel3 == true)
        {
            suspicion = Mathf.Clamp(suspicion, 3.1f, 4);
            while (suspicion >= 3.1f)
            {
                suspicion -= .1f;
            }
        }
        if (suspicionLevel4 == true)
        {
            Debug.Log("You Lose!");
        }



    }

    void UpdatePatrolDestination()
    {
        targetPoint = patrolPoints[patrolPointIndex].position;
        guard.SetDestination(targetPoint);
    }

    void IteratePatrolPointIndex()
    {
        patrolPointIndex++;
        if (patrolPointIndex == patrolPoints.Length)
        {
            patrolPointIndex = 0;
        }
    }
}