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


[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]

public class AnimatorController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    public float runVelocity = -.1f;
    public string animationRunPerameter;
    public string animationSpeedPerameter;
    private float maxSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        maxSpeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat(animationSpeedPerameter, agent.velocity.magnitude/runVelocity);
    }
}
