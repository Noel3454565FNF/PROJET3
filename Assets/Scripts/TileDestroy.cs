using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDestroy : MonoBehaviour
{
    private Tilemap tilemap;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    public IEnumerator DestroyTile(Vector3 TilePos)
    {
        yield return new WaitForSeconds(0.1f);
        tilemap.SetTile(new Vector3Int((int)TilePos.x, (int)TilePos.y, 0), null);
    }
}
