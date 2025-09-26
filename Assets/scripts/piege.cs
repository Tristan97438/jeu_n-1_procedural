using StarterAssets;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class piege : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject les_pieges;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1)lorsque le joueur touche un piege ralenti pendant un certain temp
        //2)reprend sa vitesse normal

        int compteur_temp_ralenti = 0;
        if(Vector3.Distance(player.transform.position, les_pieges.transform.position) < 1)
        {
            Debug.Log("piege_touché");
           player.GetComponent<FirstPersonController>().MoveSpeed = 2.5f;
           while (compteur_temp_ralenti < 250)
            {
                compteur_temp_ralenti += 1;
            }
            player.GetComponent<FirstPersonController>().MoveSpeed = 4.5f;
        }
    }
}
