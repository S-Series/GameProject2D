using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    public Tilemap[] tilemap;
    public TileBase[] groundTile;
    public TileBase[] wallTile;

    public int mapWidth, mapHeight;
    public float noiseScale, wallThreshold;



    [ContextMenu("Generate Tilemap")]
    public void GenerateBasemap()
    {
        tilemap[0].ClearAllTiles();
        int[] size = { mapWidth / 2, mapHeight / 2 };

        float value;
        TileBase @base;
        for (int x = -size[0]; x < size[0]; x++)
        {
            for (int y = -size[1]; y < size[1]; y++)
            {
                value = Random.Range(0f, 1f);
                if (value < 0.95f) { @base = groundTile[0]; }
                else if (value < 0.97f) { @base = groundTile[1]; }
                else if (value < 0.99f) { @base = groundTile[2]; }
                else if (value < 0.9925f) { @base = groundTile[3]; }
                else if (value < 0.995f) { @base = groundTile[4]; }
                else if (value < 0.9975f) { @base = groundTile[4]; }
                else { @base = groundTile[5]; }

                tilemap[0].SetTile(new Vector3Int(x, y, 0), @base);
            }
        }
    }
}
