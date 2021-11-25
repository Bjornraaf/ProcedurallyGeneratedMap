using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChunkTresholdChecker : MonoBehaviour
{
    [SerializeField] UnityEvent OnChunkThresholdPassedEvent;
    private Chunk activeChunk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= activeChunk.XSpawnThreshold && !activeChunk.HasNeighbour)
        {
            print("Should Spawn");
            OnChunkThresholdPassedEvent?.Invoke();
        }
    }
    public void SetActiveChunk(Chunk chunk)
    {
        activeChunk = chunk;
    }
}
