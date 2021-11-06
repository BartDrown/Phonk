using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("ENTERED");
        Object.Destroy(this.gameObject, 0f);


    } 
}
