using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour



{
    [SerializeField] private Camera camera;
    private NavMeshAgent navMeshAgent;
    private GameObject cylinder;
    private RaycastHit rayCastHit;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        cylinder = GameObject.Find("Cylinder");

        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.SetDestination(cylinder.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(Physics.Raycast(ray,out rayCastHit))
            {
                navMeshAgent.SetDestination(rayCastHit.point);
            }
        }
        if(navMeshAgent.transform.position.x==rayCastHit.point.x && navMeshAgent.transform.position.z == rayCastHit.point.z)
        {
            navMeshAgent.SetDestination(target.position);
        }
        //navMeshAgent.destination = movePositionTransform.position;
        
    }
}
