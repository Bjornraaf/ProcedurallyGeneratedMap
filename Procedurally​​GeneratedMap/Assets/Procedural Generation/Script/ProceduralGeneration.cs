using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] int width,height;
    [SerializeField] int minStoneHeight, maxStoneHeight;
    [SerializeField] int timesw = 0;
    [SerializeField] GameObject dirt,grass,stone;
    // Start is called before the first frame update
    void Start()
    {
        Generation();
        transform.position = new Vector3(-width, 0, 0);
        Generation();
        
    }
        // Update is called once per frame
        protected void Generation()
    {
        for (int x = 0; x < width; x++)
        {
            int minHeight = height - 1;
            int maxHeight = height + 2;
            height = Random.Range(minHeight, maxHeight);
            int minStoneSpawnDistance = height - minStoneHeight;
            int maxStoneSpawnDistance = height - maxStoneHeight;
            int totalStoneSpawnDistance = Random.Range(minStoneSpawnDistance, maxStoneSpawnDistance);

            for (int y = 0; y < height; y++)
            {
                if (y<totalStoneSpawnDistance)
                {
                    SpawnObj(stone, x, y);
                }
                else
                {
                    SpawnObj(dirt, x, y);
                }
                
            }
            SpawnObj(grass, x, height);
        }
        
    }
    void SpawnObj(GameObject obj, int width, int height)
    {
        obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}
