using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject cube_prefabs;
    public GameObject[] cube_monde = new GameObject[1000];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
