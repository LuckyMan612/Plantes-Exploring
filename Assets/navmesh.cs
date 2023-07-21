using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navmesh : MonoBehaviour
{
    public Transform target;
    public bool czyToWrog;
    public bool czyMozeSieRuszac;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NavMeshAgent>().updateRotation = false;
        GetComponent<NavMeshAgent>().updateUpAxis = false;
        if (czyToWrog)
        {
            target = GameObject.Find("spaceRockets_004").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (czyMozeSieRuszac)
        {
            GetComponent<NavMeshAgent>().SetDestination(target.position);
        }
    }
}
