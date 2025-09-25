using UnityEngine;

public class Score : MonoBehaviour
{
    
    [SerializeField] GameObject player;
    [SerializeField] GameObject ennemi1,ennemi2,ennemi3;
    [SerializeField] TMPro.TextMeshProUGUI win_lose_txt, score_precedent_txt, compteur_txt;
    [SerializeField] TMPro.TextMeshProUGUI distance_ennemi1, distance_ennemi2, distance_ennemi3;

    Vector3 pos_player;
    Vector3 pos_ennemi1;
    Vector3 pos_ennemi2;
    Vector3 pos_ennemi3;

    float dist_ennemi1, dist_ennemi2, dist_ennemi3;
    bool toucher = false;
    int compteur_score = 0;
    int retiens_score = 0;
    //1) on augmente le score dès le lancemant
    //2) si le score du joueur atteint un certain palier alors le joueur a gagner
    //3) si le joueur est touché par l'ennemi avant d'atteindre l'objectif de score alors il a perdu
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        desactiver_ennemi();

        //retiens les position d'orgine
        pos_player = new Vector3(0,0.5f,0);
        pos_ennemi1 = ennemi1.transform.position;
        pos_ennemi2 = ennemi2.transform.position;
        pos_ennemi3 = ennemi3.transform.position;
    }
    //méthode qui désactive les ennemis
    private void desactiver_ennemi()
    {
        ennemi1.SetActive(false);
        ennemi2.SetActive(false);
        ennemi3.SetActive(false);
    }
    //méthode qui active les ennemis
    private void activer_ennemi()
    {
        ennemi1.SetActive(true);
        ennemi2.SetActive(true);
        ennemi3.SetActive(true);
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
            win_lose_txt.text = "Bravo ! Vous avez gagnez ! Vous pouvez recommencer en apuyant sur la touche 'R'.";
            toucher = true;
        }
        //si l'ennemi 1 touche le joueur alors la partie et perdue
        if (Vector3.Distance(player.transform.position, ennemi1.transform.position) < 1.5 && compteur_score<5000 && compteur_score > 500)
        {
            win_lose_txt.text = "Dommage. Vous avez perdu. Vous pouvez recommencer en apuyant sur la touche 'R'.";
            toucher = true;
        }
        //si l'ennemi 2 touche le joueur alors la partie et perdue
        if (Vector3.Distance(player.transform.position, ennemi2.transform.position) < 1.5 && compteur_score < 5000 && compteur_score > 500)
        {
            win_lose_txt.text = "Dommage. Vous avez perdu. Vous pouvez recommencer en apuyant sur la touche 'R'.";
            toucher = true;
        }
        //si l'ennemi 3 touche le joueur alors la partie et perdue
        if (Vector3.Distance(player.transform.position, ennemi3.transform.position) < 1.5 && compteur_score < 5000 && compteur_score > 500)
        {
            win_lose_txt.text = "Dommage. Vous avez perdu. Vous pouvez recommencer en apuyant sur la touche 'R'.";
            toucher = true;
        }
        //faire spawn les ennemi après un certain score 
        if (compteur_score > 500)
        {
            activer_ennemi();
        }

        //1) si on appuie sur R on restart.
        //2) on affiche le score précédent
        //3) ont remet a l'emplacement d'origine le joueur et les ennnemi
        //4) on desactive les ennemi 
        //5) on remet a 0 le compteur
        //6) on remet toucher a False
        //7) retirer le message de victoire ou de défaite

        if (Input.GetKeyDown(KeyCode.R))  //<-- 1ère étape
        {
            retiens_score = compteur_score;  //<-- 2ème étape
            score_precedent_txt.text = "Score précédent : " + retiens_score;

            player.transform.position = pos_player; //<-- 3ème étape
            ennemi1.transform.position = pos_ennemi1;
            ennemi2.transform.position = pos_ennemi2;
            ennemi3.transform.position = pos_ennemi3;

            desactiver_ennemi(); //<--4ème étape

            compteur_score = 0; //<--5ème étape

            toucher = false; //<--6ème étape

            win_lose_txt.text = ""; //<--7ème étape
        }

        //affiche la distance entre le joueur et chaque ennemi
        //ennemi 1
        dist_ennemi1 = Vector3.Distance(player.transform.position, ennemi1.transform.position);
        distance_ennemi1.text = "Ennemi n°1 à " + dist_ennemi1 + " m";
        //ennemi 2
        dist_ennemi2 = Vector3.Distance(player.transform.position, ennemi2.transform.position);
        distance_ennemi2.text = "Ennemi n°2 à " + dist_ennemi2 + " m";
        //ennemi 3
        dist_ennemi3 = Vector3.Distance(player.transform.position, ennemi3.transform.position);
        distance_ennemi3.text = "Ennemi n°3 à " + dist_ennemi3 + " m";
    }

    
}
