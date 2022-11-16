/***
 * Author: Ava Fritts
 * Created: 11-14-22
 * Modified:
 * Description: Controls weather effects
 ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class FollowDestination : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform destination;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(destination.position);
    }

}
