using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    float followSpeed = 5f;
    // Start is called before the first frame update
    [SerializeField]
    Vector2 offset = new Vector2(0f, 4f);

    [SerializeField]
    Vector2 limit = new Vector2(0f, 10f);

    void FixedUpdate() {
        this.transform.position = new Vector3 (Mathf.Lerp(this.transform.position.x, player.transform.position.x + this.offset.x, Time.deltaTime * followSpeed),
                                               Mathf.Lerp(this.transform.position.y, player.transform.position.y + this.offset.y, Time.deltaTime * followSpeed), 
                                               this.transform.position.z
                                               );

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, this.player.transform.position.x - limit.x, this.player.transform.position.x + limit.x ),
            Mathf.Clamp(transform.position.y, this.player.transform.position.y - limit.y, this.player.transform.position.y + limit.y ),
            this.transform.position.z
        );


    }
}
