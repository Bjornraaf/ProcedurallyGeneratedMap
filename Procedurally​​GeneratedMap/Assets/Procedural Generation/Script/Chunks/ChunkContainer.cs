using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkContainer : MonoBehaviour
{
    private List<Chunk> chunks = new List<Chunk>();

    public void AddChunkToList(Chunk chunk)
    {
        if (chunks.Contains(chunk))
        {
            print("Container already contains this chunk!");
            return;
        }
        chunks.Add(chunk);
        print("Added a new chunk");
    }

    public Chunk GetLatestGeneratedChunk()
    {
        if (chunks.Count <= 0) return null;
        return chunks[chunks.Count - 1];
    }    
}
