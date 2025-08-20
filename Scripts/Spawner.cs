using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    
    

    void Start()
    {
        InvokeRepeating(nameof(SpawnPipes), 1f, 3f);
    }

    void Update()
    {
        
    }

    private void SpawnPipes()
    {
        
        Instantiate(objectToSpawn, new Vector2(transform.position.x,transform.position.y + Random.Range(-4f,4f)), Quaternion.identity);
    }

}
