using UnityEngine;

public class Case : MonoBehaviour
{
    [SerializeField] GameObject[] murs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //OuvrirTousLesMurs();
    }

    public void OuvrirTousLesMurs()
    {
        for (int i = 0; i < murs.Length; i++)
        {
            murs[i].GetComponent<Mur>().ouvrir();
        }
    }
    public void OuvrirMurN()
    {
        murs[0].GetComponent<Mur>().ouvrir();
    }
    public void OuvrirMurS()
    {
        murs[1].GetComponent<Mur>().ouvrir();
    }
    public void OuvrirMurE()
    {
        murs[2].GetComponent<Mur>().ouvrir();
    }
    public void OuvrirMurO()
    {
        murs[3].GetComponent<Mur>().ouvrir();
    }

    // Update is called once per frame
    void Update()
    {

    }
}