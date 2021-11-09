using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableBehavior : MonoBehaviour
{
    //? type 0 length type 1 instrument
    [SerializeField]
    int type = 0;
    //? per things 
    [SerializeField]
    int thing = 0;
    UIManager uiManager;
    void Start()
    {
        this.uiManager = FindObjectOfType<UIManager>();
        Object.Destroy(this.gameObject, 5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        this.uiManager.onPickup(type, thing);
        Debug.Log("ENTERED");
        Object.Destroy(this.gameObject, 0f);


    } 
}
