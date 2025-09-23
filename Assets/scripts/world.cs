using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    
    [SerializeField] GameObject cube_prefabs;
    [SerializeField] TMPro.TextMeshPro "text (TMP)";
    public int largeur = 100;
    public int longueur = 100;
    public GameObject[,] cube_monde; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cube_monde = new GameObject[largeur, longueur];
        for (int i = 0; i < largeur; i++)
        {
            for(int j= 0 ; j < longueur; j++)
            {
                int hauteur = Random.Range(0, 5);
                cube_monde[i, j] = Instantiate(cube_prefabs, new Vector3(i, hauteur, j), Quaternion.identity);
                Renderer rend = cube_monde[i, j].GetComponent<Renderer>();

                // Duplique le matériau pour éviter que tous les cubes partagent la même couleur
                rend.material = new Material(rend.material);

                // Couleur aléatoire
                rend.material.color = new Color(Random.value, Random.value, Random.value);
            }
            
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
