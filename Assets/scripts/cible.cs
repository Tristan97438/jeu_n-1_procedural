using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class cible : MonoBehaviour
{
    [SerializeField]GameObject joueur;
   
    NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(joueur.transform.position);
    }
    
   

}
