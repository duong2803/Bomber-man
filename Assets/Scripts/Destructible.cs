using UnityEngine;

public class Destructible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float destructionTime = 1f;

    [Range(0f, 1f)]
    public float itemSpawnChance = 0.2f;
    public GameObject[] spawnableItems;
    void Start()
    {
        Destroy(gameObject, destructionTime); 
    }

    public void OnDestroy()
    {
        if(spawnableItems.Length > 0 && Random.value < itemSpawnChance){
            int randomIndex = Random.Range(0, spawnableItems.Length);
            Instantiate(spawnableItems[randomIndex], transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
