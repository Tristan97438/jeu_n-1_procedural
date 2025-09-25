using UnityEngine;

public class score : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI compteur_txt;
    [SerializeField] GameObject player;
    [SerializeField] GameObject ennemi;
    [SerializeField] TMPro.TextMeshProUGUI win_lose_txt;
    bool toucher = false;
    int compteur_score = 0;
    //1) on augmente le score dès le lancemant
    //2) si le score du joueur atteint un certain palier alors le joueur a gagner
    //3) si le joueur est touché par l'ennemi avant d'atteindre l'objectif de score alors il a perdu
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        ennemi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //tant que le joueur n'est pas touché on augmente le score et on l'affiche
        if (toucher == false)
        {
            compteur_score += 1;
            compteur_txt.text = "Votre score : " + compteur_score + "/ 5000";
        }
        //si ont atteint les 5000 le joueur a gagner
        if (compteur_score >= 5000)
        {
            win_lose_txt.text = "Bravo ! Vous avez gagnez !";
        }
        //si l'ennemi touche le joueur alors la partie et perdue
        if (Vector3.Distance(player.transform.position, ennemi.transform.position) < 1.5 && compteur_score<5000 && compteur_score > 250)
        {
            win_lose_txt.text = "Dommage. Vous avez perdu.";
        }
        //faire spawn l'ennemi après un certain score 
        if (compteur_score > 250)
        {
            ennemi.SetActive(true);
        }
    }
}
