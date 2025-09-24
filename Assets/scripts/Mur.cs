using UnityEngine;

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
    }
    public void fermer()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
