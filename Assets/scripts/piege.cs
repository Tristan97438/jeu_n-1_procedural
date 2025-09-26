using StarterAssets;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class piege : MonoBehaviour
{
    [SerializeField] GameObject player;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1)récupéré les games objects pieges
        //2)lorsque le joueur est proche d'un piege il perd en vitesse
        

        
        //récupéré les games objects pieges
        GameObject[] tab_piege = GameObject.FindGameObjectsWithTag("pieges");  //<--1ère étape
        for (int i = 0; i < tab_piege.Length; i++)
        {
            if (Vector3.Distance(player.transform.position, tab_piege[i].transform.position) < 2)
            {
                Debug.Log("piege_touché");
                //récupéré le composant permetant de changer la vitesse du joueur et on reduit sa vitesse avec le temp
                player.GetComponent<FirstPersonController>().MoveSpeed -= 0.001f;  //<--2ème étape
                            
            }
            
        }
     

    }
}
