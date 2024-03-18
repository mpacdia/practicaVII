using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject mono;
    public GameObject enemy;

    public Animator enemyAnimator;

    public bool stay = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAnimator.GetBool("stay") == true)
        {
            agent.destination = mono.transform.position;
        }
    }

    private void OnDrawGizmos()
    {
        /* TODO 1: Crear un Gizmo que sea un rayo */
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(transform.position, transform.forward);
    }
}
