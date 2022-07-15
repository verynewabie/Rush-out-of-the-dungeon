using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructibleLayer : MonoBehaviour
{
    public float xGap;
    public float yGap;
    private Tilemap myTilemap;
    private int[] x = { 1, -1, 0, 0, 1, 1, -1, -1 };
    private int[] y = { 0, 0, 1, -1, 1, -1, 1, -1 };

    // Start is called before the first frame update
    void Start()
    {
        myTilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerAttack"))
        {
            for (int i = 0; i < 8; i++)
            {
                Vector3 hitPos = other.ClosestPoint(other.transform.position);
                hitPos += new Vector3(x[i] * xGap, y[i] * yGap, 0);
                Vector3Int position = myTilemap.WorldToCell(hitPos);
                myTilemap.SetTile(position, null);
            }
        }
    }
}
