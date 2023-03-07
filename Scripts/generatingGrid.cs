using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatingGrid : MonoBehaviour
{
    [Header("Generating board")]
    private playerMana[,] pieces;
    [SerializeField] private GameObject cellPrefab;
    // [SerializeField] private GameObject boardPrefab;
    [SerializeField] private int gridSize = 5;
    [SerializeField] private int tileSize = 1;
    [SerializeField] private GameObject[,] tiles;
    [SerializeField] private Material tileMaterial;

    [Header("Pawn manager")]
    [SerializeField] private GameObject prefab;
    [SerializeField] private Material[] teamMaterials;

    [Header("Tile pos")]
    [SerializeField] private int TILE_COUNT_X = 0;
    [SerializeField] private int TILE_COUNT_Y = 0;

    [Header("Game param")]
    [SerializeField] private bool gameMode4P = false;

    GameObject parent;

    private void Awake()
    {
        genBoard(tileSize, gridSize);
        spawnPieces();
    }

    private void genBoard(float tileSize, int gridSize)
    {
        tiles = new GameObject[gridSize, gridSize];
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                tiles[x,y] = generateSingleTile(tileSize, x, y);
            }
        }
    }

    private GameObject generateSingleTile(float tileSize, int x, int y)
    {
        // Comments = GENERATE tile
        // GameObject tileObject = new GameObject(string.Format("X:{0}, Y:{1}", x, y));
        GameObject tileObject = Instantiate(cellPrefab, new Vector3 (x+(x*0.5f),0.93f,y+(y*0.5f)), Quaternion.Euler(0,0,0));
        tileObject.transform.parent = transform;

        // Mesh mesh = new Mesh();
        // tileObject.AddComponent<MeshFilter>().mesh = mesh;
        // tileObject.AddComponent<MeshRenderer>().material = tileMaterial;

        // Vector3[] vertices = new Vector3[4];
        // vertices[0] = new Vector3(x * tileSize, 0, y * tileSize);
        // vertices[1] = new Vector3(x * tileSize, 0, (y+1) * tileSize);
        // vertices[2] = new Vector3((x+1) * tileSize, 0, y * tileSize);
        // vertices[3] = new Vector3((x+1) * tileSize, 0, (y+1) * tileSize);

        // int[] tris = new int[] {0, 1, 2, 1, 3, 2};

        // mesh.vertices = vertices;
        // mesh.triangles = tris;

        // mesh.RecalculateNormals();

        tileObject.AddComponent<BoxCollider>();

        return tileObject;
    }

    private void spawnPieces(){
        pieces = new playerMana[TILE_COUNT_X, TILE_COUNT_Y];

        int redTeam = 0, blueTeam = 1, yellowTeam = 2, greenTeam = 3;

        // redTeam
        pieces[0,((gridSize-1)/2)] = spawnSinglePiece(pieceType.Normal, redTeam);
        pieces[(gridSize-1),((gridSize-1)/2)] = spawnSinglePiece(pieceType.Normal, blueTeam);
        if (gameMode4P == true){
            pieces[((gridSize-1)/2),(gridSize-1)] = spawnSinglePiece(pieceType.Normal, yellowTeam);
            pieces[((gridSize-1)/2),0] = spawnSinglePiece(pieceType.Normal, greenTeam);
        }

    }

    private playerMana spawnSinglePiece (pieceType type, int team)
    {
        playerMana p = Instantiate(prefab, transform).GetComponent<playerMana>();

        p.type = type;
        p.team = team;
        p.GetComponent<MeshRenderer>().material = teamMaterials[team];

        return p;
    }
}
