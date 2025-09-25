using Unity.AI.Navigation;
using UnityEngine;

public class World: MonoBehaviour
{
    
    [SerializeField] GameObject cube_prefabs;
   
    int largeur = 100;
    int longueur = 100;
    GameObject[,] cube_monde;

    //déclaration du tableau visiter qui va permettre de créer le labyrinthe
    bool[,] case_visiter_creation;

    //déclaration du tableau historique qui va permettre de retenir les positions des cases visiter et permettre de revenir en arrière pour.
    GameObject[] historique_case_visiter;  //<-- pour l'étape 4

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cube_monde = new GameObject[largeur, longueur];
        case_visiter_creation = new bool[largeur, longueur];
        historique_case_visiter = new GameObject[100000];
        for (int i = 0; i < largeur; i++)
        {
            for(int j= 0 ; j < longueur; j++)
            {
                //créer les cubes du labyrinthe
                cube_monde[i, j] = Instantiate(cube_prefabs, new Vector3(i*2, 0, j*2), Quaternion.identity);
                
                
                
                
            }
            
        }

        //----Algo labyrinthe----//
        //1)  Au départ, toutes les cellules sont marquées comme non visitées(faux).

        //2) On choisit arbitrairement une cellule, on stocke la position en cours et on la marque comme visitée(vrai).

        //3) Puis on regarde quelles sont les cellules voisines possibles et non visitées.

        //4) S'il n'y en pas, on revient à la case précédente et on recommence.

        //5) S'il y a au moins une possibilité, on en choisit une au hasard, on ouvre le mur et on recommence avec la nouvelle cellule si il y en a qu'une seule on ne choisit pas au hasard on ouvre le mur directement.

        //6) Lorsque l'on est revenu à la case de départ et qu'il n'y a plus de possibilités, le labyrinthe est terminé. 
        for (int i = 0; i < largeur; i++) //<---1ère étape
        {
            for (int j = 0; j < longueur; j++)
            {
                //ont initialise le tableau avec false pour dire que l'on a pas encore visiter de cases
                case_visiter_creation[i, j] = false;
            }

        }
        

        int g = 0;
        int h = 0;
        //on choisi une case qui seras notre depart
        case_visiter_creation[g, h] = true; //<---2ème étape
        //on créer un compteur pour regarder combien de case autour de celle visiter ne le sont pas encore

        int compteur_case_non_visiter = 0;
        //on créer un compteur pour ajouter des elements dans le tableau --> historique_case_visiter
        int compteur_case = 0;
        
        //on sauvegarde dans une variable notre case actuelle
        
        GameObject position_en_cours = cube_monde[g, h];
        //on enregistre dans l'historique de nos cases dans le tableau --> historique_case_visiter
        historique_case_visiter[compteur_case] = position_en_cours;

        int sorti_while = 0;
        //-------boucle-------//
       

        while (sorti_while < longueur*largeur*5)//grand chiffre pour être sur qu'il créer tous le labyrinthe
        {
            //on créer un tableau dans lequel l'on va enregistre les cases voisines non visiter.
            GameObject[] cases_voisines = new GameObject[4];
            compteur_case_non_visiter = 0;
            //on regarde les cases qui sont a coté de celle ou nous sommes dans la création. 
            //on ajoute 1 a notre compteur pour chaque case non visiter
            if (g==0 && h == 0)     //<---3eme étape
            {
                if (h + 1 < longueur && case_visiter_creation[g, h + 1] == false)
                {
                    //on incrémente notre tableau --> cases_voisines avec une case voisines non visiter
                    cases_voisines[compteur_case_non_visiter] = cube_monde[g, h + 1];
                    compteur_case_non_visiter += 1;


                }
                if (g + 1 < largeur && case_visiter_creation[g + 1, h] == false)
                {
                    cases_voisines[compteur_case_non_visiter] = cube_monde[g + 1 , h ];
                    compteur_case_non_visiter += 1;


                }
            }
            else{
                if (h+1<longueur && case_visiter_creation[g, h + 1] == false)
                {
                    //on incrémente notre tableau --> cases_voisines avec une case voisines non visiter
                    cases_voisines[compteur_case_non_visiter] = cube_monde[g, h + 1];
                    compteur_case_non_visiter += 1;


                }
                if (h-1 >=0 && case_visiter_creation[g, h - 1] == false)
                {
                    cases_voisines[compteur_case_non_visiter] = cube_monde[g, h - 1];
                    compteur_case_non_visiter += 1;


                }
                if (g + 1 < largeur && case_visiter_creation[g + 1, h] == false)
                {
                    cases_voisines[compteur_case_non_visiter] = cube_monde[g +1 , h ];
                    compteur_case_non_visiter += 1;


                }
                if (g-1 >=0 && case_visiter_creation[g - 1, h] == false)
                {
                    cases_voisines[compteur_case_non_visiter] = cube_monde[g - 1 , h];
                    compteur_case_non_visiter += 1;


                }
            }
            
            //on regarde combien il y a de cases voisines non visiter
            //si il y a 0 on revient a la case d'avant
            if (compteur_case_non_visiter == 0) //<---4ème étape
            {
                case_visiter_creation[g, h] = true;
                //on rajoute a l'historique la case actuelle
                

                if(compteur_case>0)
                    position_en_cours = historique_case_visiter[compteur_case - 1];

                if(compteur_case==0)
                    position_en_cours = historique_case_visiter[compteur_case];


                //on enlève 1 au compteur_case 
                int i = -1;
                int j = -1;
                compteur_case -= 1;

                //on cherche les coordonnées de la nouvelle case
                GameObject nouveau = position_en_cours;
                for (int x = 0; x < largeur; x++)
                {
                    for (int y = 0; y < longueur; y++)
                    {
                        if (cube_monde[x, y] == nouveau)
                        {
                            i = x;
                            j = y;
                            break;
                        }
                    }
                    if (i != -1) break;
                }
                //mise a jour des coordonnées
                g = i;
                h = j;


            }

            if (compteur_case_non_visiter == 1)//<---5ème étape
            {
                case_visiter_creation[g, h] = true;//on mets a true notre case actuelle
                //et on l'ajoute a l'historique

                historique_case_visiter[compteur_case] = position_en_cours;

                // Trouver les coordonnées (i, j) de la nouvelle position
                //signifient que les variables i et j sont initialisées à une valeur invalide par défaut (ici -1), pour signaler qu’on n’a pas encore trouvé les coordonnées recherchées.
                int i = -1;
                int j = -1;
                //la case voisine
                GameObject nouveau = cases_voisines[0];
                //on cherche les coordonnées de la nouvelle case
                //on parcours le array cube_monde
                for (int x = 0; x < largeur; x++)
                {
                    for (int y = 0; y < longueur; y++)
                    {
                        if (cube_monde[x, y] == nouveau)
                        {
                            i = x;
                            j = y;
                            break;
                        }
                    }
                    if (i != -1) break;
                }

                // Comparaison pour savoir la direction
                //&& --> et
                if (i == g && j == h + 1)
                {
                    Debug.Log("NORD");
                    //on ouvre les murs pour se déplacer vers le nord
                    position_en_cours.GetComponent<Case>().OuvrirMurN();
                    nouveau.GetComponent<Case>().OuvrirMurS();
                }

                else if (i == g && j == h - 1)
                {
                    Debug.Log("SUD");
                    //on ouvre les murs pour se déplacer vers le sud
                    position_en_cours.GetComponent<Case>().OuvrirMurS();
                    nouveau.GetComponent<Case>().OuvrirMurN();
                }

                else if (i == g + 1 && j == h)
                {
                    Debug.Log("EST");
                    //on ouvre les murs pour se déplacer vers l'est
                    position_en_cours.GetComponent<Case>().OuvrirMurE();
                    nouveau.GetComponent<Case>().OuvrirMurO();
                }


                else if (i == g - 1 && j == h)
                {
                    Debug.Log("OUEST");
                    //on ouvre les murs pour se déplacer vers l'ouest
                    position_en_cours.GetComponent<Case>().OuvrirMurO();
                    nouveau.GetComponent<Case>().OuvrirMurE();
                }


                // Mise à jour des coordonnées
                g = i;
                h = j;

                position_en_cours = cases_voisines[0];//on se déplace vers la case suivante
                compteur_case += 1;
            }

            if (compteur_case_non_visiter > 1)
            {
                case_visiter_creation[g, h] = true;//on mets a true notre case actuelle
                //et on l'ajoute a l'historique
                historique_case_visiter[compteur_case] = position_en_cours;

                int i = -1;
                int j = -1;
                //on choisit aléatoirement un nombre par rapport au nombres de cases voisines non-visiter.
                int rand = Random.Range(0, compteur_case_non_visiter);
                //la case voisine choisi au hasard
                GameObject nouveau = cases_voisines[rand];
                //on cherche les coordonnées de la nouvelle case
                //on parcours le array cube_monde
                for (int x = 0; x < largeur; x++)
                {
                    for (int y = 0; y < longueur; y++)
                    {
                        if (cube_monde[x, y] == nouveau)
                        {
                            i = x;
                            j = y;
                            break;
                        }
                    }
                    if (i != -1) break;
                }

                // Comparaison pour savoir la direction
                //&& --> et
                if (i == g && j == h + 1)
                {
                    Debug.Log("NORD");
                    //on ouvre les murs pour se déplacer vers le nord
                    position_en_cours.GetComponent<Case>().OuvrirMurN();
                    nouveau.GetComponent<Case>().OuvrirMurS();
                }

                else if (i == g && j == h - 1)
                {
                    Debug.Log("SUD");
                    //on ouvre les murs pour se déplacer vers le sud
                    position_en_cours.GetComponent<Case>().OuvrirMurS();
                    nouveau.GetComponent<Case>().OuvrirMurN();
                }

                else if (i == g + 1 && j == h)
                {
                    Debug.Log("EST");
                    //on ouvre les murs pour se déplacer vers l'est
                    position_en_cours.GetComponent<Case>().OuvrirMurE();
                    nouveau.GetComponent<Case>().OuvrirMurO();
                }


                else if (i == g - 1 && j == h)
                {
                    Debug.Log("OUEST");
                    //on ouvre les murs pour se déplacer vers l'ouest
                    position_en_cours.GetComponent<Case>().OuvrirMurO();
                    nouveau.GetComponent<Case>().OuvrirMurE();
                }


                // Mise à jour des coordonnées
                //vérification si il y a un problème de coordonnée
                //si il n'y a pas de problème ont les changes (Mise à jour des coordonnées)
                if (i == -1 || j == -1)
                {
                    Debug.LogError("ERREUR : la case voisine sélectionnée n'a pas été trouvée dans la grille.");
                    break; 
                }
                else
                {
                    g = i;
                    h = j;
                }

                position_en_cours = cases_voisines[rand];//on se déplace vers la case suivante
                compteur_case += 1;


            }
            sorti_while += 1;
        }
        

    }
    void Update()
    {

    }


}

    
    
