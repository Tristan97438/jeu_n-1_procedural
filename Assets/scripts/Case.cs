using UnityEngine;

public class Case : MonoBehaviour
{
    [SerializeField] GameObject[] murs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    
    public void OuvrirMurN()
    {
        //on ouvre la porte murs[0] c'est à dire la porte nord
        murs[0].GetComponent<Mur>().ouvrir();
    }
    public void OuvrirMurS()
    {
        //on ouvre la porte murs[1] c'est à dire la porte Sud
        murs[1].GetComponent<Mur>().ouvrir();
    }
    public void OuvrirMurE()
    {
        //on ouvre la porte murs[2] c'est à dire la porte Est
        murs[2].GetComponent<Mur>().ouvrir();
    }
    public void OuvrirMurO()
    {
        //on ouvre la porte murs[3] c'est à dire la porte Ouest
        murs[3].GetComponent<Mur>().ouvrir();
    }

    // Update is called once per frame
    void Update()
    {

    }
}