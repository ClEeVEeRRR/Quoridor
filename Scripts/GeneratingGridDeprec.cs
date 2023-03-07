using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingGridDeprec : MonoBehaviour
{
    [Header("Generating board")]
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private GameObject boardPrefab;
    // [SerializeField] private GameObject board05x05;
    // [SerializeField] private GameObject board07x07;
    // [SerializeField] private GameObject board09x09;
    // [SerializeField] private GameObject board11x11;
    [SerializeField] private int gridSize;
    [SerializeField] private int tileSize = 1;
    [SerializeField] private GameObject[,] tiles;

    [Header("Pawn manager")]
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject[] teamMaterials;

    GameObject parent;

    private void Awake()
    {
        genBoard(tileSize, gridSize);
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
        GameObject tileObject = new GameObject(string.Format("X:{0}, Y:{1}", x, y));
        tileObject.transform.parent = transform;

        Mesh mesh = new Mesh();
        tileObject.AddComponent<MeshFilter>().mesh = mesh;
        tileObject.AddComponent<MeshRenderer>();

        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(x * tileSize, 0, y * tileSize);
        vertices[1] = new Vector3(x * tileSize, 0, (y+1) * tileSize);
        vertices[2] = new Vector3((x+1) * tileSize, 0, y * tileSize);
        vertices[3] = new Vector3((x+1) * tileSize, 0, (y+1) * tileSize);

        int[] tris = new int[] {0, 1, 2, 1, 3, 2};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tileObject.AddComponent<BoxCollider>();

        return tileObject;
    }


// old
    //  private void genBoard(int gridSize)
    //  {
        //   parent = new GameObject("completeBoard");
        //    if ((gridSize % 2) == 0){
            //   GameObject board = Instantiate(boardPrefab, new Vector3 (0,0,0), Quaternion.Euler(0,0,0));
            //   board.transform.localScale = new Vector3 (((gridSize)*1.3f), 0.9f, ((gridSize)*1.3f));
            //   board.name = "Board";
            //    }
        //    else {
            //    GameObject board = Instantiate(boardPrefab, new Vector3 (gridSize/2-0.125f,-0.25f,gridSize/2-0.125f), Quaternion.Euler(0,0,0));
            //    board.transform.localScale = new Vector3 ((gridSize+((gridSize+2)*0.25f)), 0.9f, (gridSize+((gridSize+2)*0.25f)));
            //    board.name = "Board";
            //    }

        //  GameObject board = Instantiate(boardPrefab, new Vector3 (0,0.9f,0), Quaternion.Euler(0,0,0));
        //  board.transform.localScale = new Vector3 (0.9f, 0.1f, 0.9f);
        //   board.transform.parent = parent;
        //  board.name = "Board";

        //  for(int i = 1; i < gridSize+1; i++)
        //  {
            //  for(int j = 1; j < gridSize+1; j++)
            //  {
                //  GameObject cell = Instantiate(cellPrefab, new Vector3 ((-0.37f*-i),0.93f,(-0.37f*-j)), Quaternion.Euler(0,0,0));
                //   cell.transform.parent = board.transform;
                //   cell.transform.position =  new Vector3 (-0.37f,0.93f,-0.37f);
                //   cell.transform.localScale = new Vector3 (0.1f, 1f, 0.1f);
                //  cell.transform.parent = transform;
                //  cell.name = i + "-" + j;
            //  }
        //  }
    //  }
}
