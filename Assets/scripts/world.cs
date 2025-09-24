using UnityEngine;

public class World: MonoBehaviour
{
    
    [SerializeField] GameObject cube_prefabs;
   
    int largeur = 100;
    int longueur = 100;
    GameObject[,] cube_monde;

    //d�claration du tableau visiter qui va permettre de cr�er le labyrinthe
    bool[,] case_visiter_creation;

    //d�claration du tableau historique qui va permettre de retenir les positions des cases visiter et permettre de revenir en arri�re.
    GameObject[] historique_case_visiter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cube_monde = new GameObject[largeur, longueur];
        case_visiter_creation = new bool[largeur, longueur];
        historique_case_visiter = new GameObject[largeur * longueur];
        for (int i = 0; i < largeur; i++)
        {
            for(int j= 0 ; j < longueur; j++)
            {
                //cr�er les cubes du labyrinthe
                cube_monde[i, j] = Instantiate(cube_prefabs, new Vector3(i*2, 0, j*2), Quaternion.identity);
                //augmentation de la taille des cubes
                cube_monde[i, j].transform.localScale = new Vector3(2, 2, 2);
                //r�cup�r� le renderer pour appliquer la couleur
                Renderer rend = cube_monde[i, j].GetComponent<Renderer>();

                // Duplique le mat�riau pour �viter que tous les cubes partagent la m�me couleur
                rend.material = new Material(rend.material);

                // Couleur al�atoire
                rend.material.color = new Color(Random.value, Random.value, Random.value);
            }
            
        }
        for (int i = 0; i < largeur; i++)
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
        case_visiter_creation[g, h] = true;
        //on cr�er un compteur pour regarder combien de case autour de celle visiter ne le sont pas

        int compteur_case_non_visiter = 0;
        //on cr�er un compteur pour ajouter des elements dans le tableau --> historique_case_visiter
        int compteur_case = 0;
        
        //on sauvegarde dans une variable notre case actuelle
        
        GameObject position_en_cours = cube_monde[g, h];
        //on enregistre dans l'historique de nos cases dans le tableau --> historique_case_visiter
        historique_case_visiter[compteur_case] = position_en_cours;

        //-------boucle-------

        //on enregistre les cases voisines non visiter
        GameObject[] cases_voisines = new GameObject[4];

        //on regarde les cases qui sont a cot� de celle ou nous sommes dans la cr�ation. 
        //on ajoute 1 a notre compteur pour chaque case non visiter
        if (case_visiter_creation[g, h + 1] == false)
        {
            //on incr�mente notre tableau --> cases_voisines avec une case voisines non visiter
            cases_voisines[compteur_case_non_visiter] = cube_monde[g, h + 1];
            compteur_case_non_visiter += 1;
            
            
        }
        if (case_visiter_creation[g, h - 1] == false)
        {
            cases_voisines[compteur_case_non_visiter] = cube_monde[g, h + 1];
            compteur_case_non_visiter += 1;

            
        }
        if (case_visiter_creation[g + 1, h] == false)
        {
            cases_voisines[compteur_case_non_visiter] = cube_monde[g, h + 1];
            compteur_case_non_visiter += 1;

            
        }
        if (case_visiter_creation[g - 1, h] == false)
        {
            cases_voisines[compteur_case_non_visiter] = cube_monde[g, h + 1];
            compteur_case_non_visiter += 1;

            
        }
        //on regarde combien il y a de cases voisines non visiter
        //si il y a 0 on revient a la case d'avant
        if (compteur_case_non_visiter == 0)
        {
            case_visiter_creation[g, h] = true;
            //on rajoute a l'historique la case actuelle
            historique_case_visiter[compteur_case] = position_en_cours;
            position_en_cours = historique_case_visiter[compteur_case - 1];
            
            
            //on rajoute 1 au compteur_case 
            compteur_case += 1;
        }

        if(compteur_case_non_visiter == 1)
        {
            case_visiter_creation[g, h] = true;
            historique_case_visiter[compteur_case] = position_en_cours;
            position_en_cours = cases_voisines[0];
            compteur_case += 1;
            // Trouver les coordonn�es (i, j) de la nouvelle position
            //signifient que les variables i et j sont initialis�es � une valeur invalide par d�faut (ici -1), pour signaler qu�on n�a pas encore trouv� les coordonn�es recherch�es.
            int i = -1;
            int j = -1;
            //la case voisine
            GameObject nouveau = cases_voisines[0];
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
            if (i == g && j == h + 1)
            {
                Debug.Log("NORD");
                position_en_cours.GetComponent<Case>().OuvrirMurN();
                nouveau.GetComponent<Case>().OuvrirMurS();
            }
                
            else if (i == g && j == h - 1)
            {
                Debug.Log("SUD");
                position_en_cours.GetComponent<Case>().OuvrirMurS();
                nouveau.GetComponent<Case>().OuvrirMurN();
            }
                
            else if (i == g + 1 && j == h)
            {
                Debug.Log("EST");
                position_en_cours.GetComponent<Case>().OuvrirMurE();
                nouveau.GetComponent<Case>().OuvrirMurO();
            }
                

            else if (i == g - 1 && j == h)
            {
                Debug.Log("OUEST");
                position_en_cours.GetComponent<Case>().OuvrirMurO();
                nouveau.GetComponent<Case>().OuvrirMurE();
            }
                

            // Mise � jour des coordonn�es
            g = i;
            h = j;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
