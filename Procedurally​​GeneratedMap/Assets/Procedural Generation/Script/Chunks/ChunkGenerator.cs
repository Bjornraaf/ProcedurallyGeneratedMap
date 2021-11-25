using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChunkGenerator : MonoBehaviour
{
    [System.Serializable]
    public class NewChunkEvent : UnityEvent<Chunk> { }
     
    [SerializeField] int width, height;
    [SerializeField] int minStoneHeight, maxStoneHeight;
    [SerializeField] int timesw = 1;
    [SerializeField] GameObject dirt, grass, stone;

    public NewChunkEvent newChunkEvent;

    private ChunkContainer chunkContainer;

    private void Start()
    {
        chunkContainer = GetComponent<ChunkContainer>();
        GenerateChunk();
    }
    public void GenerateChunk()
    {
        GameObject chunkObj = new GameObject("Chunk");
        Chunk newChunk = chunkObj.AddComponent<Chunk>();

        // chunkObj.transform.SetParent(this.transform);
        newChunk.transform.SetParent(chunkObj.transform);

        GenerateChunkContent(newChunk);
        PositionNewChunk(newChunk);
        GenerateChunkTriggerZone(newChunk);

        chunkContainer.AddChunkToList(newChunk);
        newChunkEvent?.Invoke(newChunk);
    }

    private void GenerateChunkTriggerZone(Chunk newChunk)
    {
        BoxCollider2D collider = newChunk.gameObject.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
        collider.offset = new Vector2(width / 2 - 0.5f, width / 4f);
        collider.size = new Vector2(width, width / 2f);
    }

    private void PositionNewChunk(Chunk newChunk)
    {
        Chunk latestChunk = chunkContainer.GetLatestGeneratedChunk();
        Vector3 newChunkPosition = latestChunk == null ? Vector3.zero : new Vector3(latestChunk.transform.position.x + width, 0, 0);
        newChunk.transform.position = newChunkPosition;
        
        if (latestChunk != null)
        {
            latestChunk.HasNeighbour = true;
        }
    }

    protected void GenerateChunkContent(Chunk chunk)
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
                if (y < totalStoneSpawnDistance)
                {
                    SpawnObj(stone, x, y, chunk.transform);
                }
                else
                {
                    SpawnObj(dirt, x, y, chunk.transform);
                }

            }
            SpawnObj(grass, x, height, chunk.transform);
        }

    }
    void SpawnObj(GameObject obj, int width, int height, Transform parent)
    {
        obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        obj.transform.parent = parent;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GenerateChunk();
        }
    }
}
