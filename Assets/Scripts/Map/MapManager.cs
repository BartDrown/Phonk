using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> prefabs;

    [SerializeField]
    GameObject startingPrefab;

    [SerializeField]
    Grid grid;

    float currentHeight = 0;
    void Start()
    {
        this.grid = FindObjectOfType<Grid>();
        GameObject tilemapObject = Instantiate(startingPrefab, Vector3.zero, Quaternion.identity, this.grid.transform);

        TilemapBehavior tilemapBehavior = tilemapObject.GetComponent<TilemapBehavior>();
        Vector2 tilemapSize = tilemapBehavior.getSize();
        
        this.currentHeight += (int) tilemapSize.y; 

        tilemapNotVisible();

    }

    void Update()
    {
        
    }

    public void tilemapNotVisible(){
        GameObject selectedPrefab = prefabs[Random.Range(0, (int) prefabs.Count)];

        Vector3 position = new Vector3(250, 0, 10);

        GameObject tilemapObject = Instantiate(selectedPrefab, position, Quaternion.identity,this.grid.transform);

        TilemapBehavior tilemapBehavior = tilemapObject.GetComponent<TilemapBehavior>();
        Vector2 tilemapSize = tilemapBehavior.getSize();


        tilemapObject.transform.position = new Vector3(0, this.currentHeight, 10);

        this.currentHeight += (int) tilemapSize.y; 
    }

}
