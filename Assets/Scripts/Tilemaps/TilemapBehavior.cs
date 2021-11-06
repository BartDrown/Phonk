using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapBehavior : MonoBehaviour
{
    MapManager mapManager;
    Tilemap tilemap;
    // Start is called before the first frame update
    bool onceEnabled = false;

    [SerializeField]
    int offset = 0; 
    void OnEnable()
    {  
        if(!onceEnabled){
            this.tilemap = this.GetComponent<Tilemap>();
            this.mapManager = FindObjectOfType<MapManager>();
            onceEnabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible()
    {
        this.mapManager.tilemapNotVisible();
        Destroy(this.gameObject);
    }

    public Vector2 getSize(){
        return new Vector2(this.tilemap.size.x, this.tilemap.size.y + offset);
    }

}
