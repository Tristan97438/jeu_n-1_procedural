using UnityEngine;
using UnityEngine.AI;


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
        //on definie la cible des ennemis ici le joueur
        agent.SetDestination(joueur.transform.position);
    }
    
   

}
