using UnityEngine;

public class World: MonoBehaviour
{
    
    [SerializeField] GameObject cube_prefabs;
   
    int largeur = 100;
    int longueur = 100;
    GameObject[,] cube_monde;
    //d�claration du tableau visiter qui va permettre de cr�er le labyrinthe
    bool[,] case_visiter_creation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cube_monde = new GameObject[largeur, longueur];
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
        //on choisi une case qui seras notre depart
        case_visiter_creation[0, 0] = true;
        for (int i = 0; i < largeur; i++)
        {
            for (int j = 0; j < longueur; j++)
            {
                //on cr�er un compteur pour regarder combien de case autour de celle visiter ne le sont pas
                int compteur_case_nom_visiter = 0;
                //on regarde les cases qui sont a cot� de celle ou nous sommes dans la cr�ation.
                //on ajoute 1 a notre compter pour chaque case non visiter
                if (case_visiter_creation[i, j + 1] == false)
                {                   
                    compteur_case_nom_visiter += 1;
                }
                if (case_visiter_creation[i, j - 1] == false)
                {                    
                    compteur_case_nom_visiter += 1;
                }
                if (case_visiter_creation[i + 1, j] == false)
                {                
                    compteur_case_nom_visiter += 1;
                }
                if (case_visiter_creation[i - 1, j] == false)
                {                 
                    compteur_case_nom_visiter += 1;
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
