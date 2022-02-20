using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//trzeba doda� aby unity czyta�o

public class EnemyControler : MonoBehaviour

{   //Zasi�g widoczno�ci

    public float lookRadius = 50f;
    
    Transform target;// czy player jest w terenie
    NavMeshAgent agent;//

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
        }
             
    }
    void OnDrawGizmosSelected()//Czerwona obr�cz
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
