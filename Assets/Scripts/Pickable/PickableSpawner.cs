using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableSpawner : MonoBehaviour
{
    [SerializeField]
    Vector2 offset = new Vector2(0, 15f);
    [SerializeField]
    float width = 30f;

    [SerializeField]
    float minTime = 2f;
    [SerializeField]
    float maxTime = 5f;

    float time = 0f;
    float spawnTime;

    [SerializeField]
    List<GameObject> instruments;

    [SerializeField]
    List<GameObject> lengths;

    void Update()
    {
        time += Time.deltaTime;

        if( time >= spawnTime){
            SpawnObject();
            spawnTime = Random.Range(minTime, maxTime);
            time = 0;
        }

    }

    void SpawnObject(){

        if(Random.Range(0,2) == 0){
        Instantiate(
            instruments[Random.Range(0, instruments.Count)],
            new Vector3(
                (int) Random.Range( Random.Range(-width, -width/2),  Random.Range(width/2, width)),
                this.transform.position.y + offset.y,
                0),
            Quaternion.identity);
        }else{
        Instantiate(
            lengths[Random.Range(0, lengths.Count)],
            new Vector3(
                (int) Random.Range( Random.Range(-width, -width/2),  Random.Range(width/2, width)),
                this.transform.position.y + offset.y,
                0),
            Quaternion.identity);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(
            new Vector3(this.transform.position.x , this.transform.position.y + offset.y, 0),
            new Vector3(offset.x + width, 0,  1));
    }
}
