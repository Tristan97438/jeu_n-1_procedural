using UnityEngine;
using UnityEngine.AI;

public class Mur : MonoBehaviour
{
    [SerializeField] string nom;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void ouvrir()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<NavMeshObstacle>().enabled = false;
    }
    

    // Update is called once per frame
    void Update()
    {

    }
}
