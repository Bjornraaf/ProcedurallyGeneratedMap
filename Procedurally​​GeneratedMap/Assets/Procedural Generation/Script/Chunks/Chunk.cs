using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chunk : MonoBehaviour
{
    [Range(0, 100)][SerializeField]
    private float xSpawnThreshold = 50;
    public float XSpawnThreshold
    {
        get { return xSpawnThreshold + transform.position.x; }
    }

    [System.Serializable]
    public class OnPlayerEnteredEvent : UnityEvent<Chunk> { }
    [SerializeField] OnPlayerEnteredEvent onPlayerEnteredEvent;

    public bool HasNeighbour { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ChunkTresholdChecker pm = FindObjectOfType<ChunkTresholdChecker>();
            pm.SetActiveChunk(this);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(new Vector3(transform.position.x + xSpawnThreshold, 0, 0), new Vector3(transform.position.x+xSpawnThreshold, 50, 0));
    }
}
