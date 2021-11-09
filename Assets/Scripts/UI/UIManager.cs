using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject arrow;
    int selectedFrame;

    [SerializeField]
    List<GameObject> lengthsUI;

    [SerializeField]
    List<GameObject> instrumentsUI;

    bool[,] state = { 
                        {false,false,false,false,false,false,false, false},
                        {false,false,false,false,false,false,false, false}
    };

    [SerializeField]
    Sprite[] spritesLengths;
    [SerializeField]
    Sprite[] spritesInstruments;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.X)){
            this.selectNextFrame();

        }else if(Input.GetKeyUp(KeyCode.Z)){
            this.selectPreviousFrame();
        }
    }



    void selectNextFrame(){
        if(selectedFrame < 7){
        selectedFrame += 1;
        this.arrow.transform.position = new Vector3(this.arrow.transform.position.x, this.arrow.transform.position.y - 128 , this.arrow.transform.position.z);
        }else{
            selectedFrame = 0;
            this.arrow.transform.position = new Vector3(this.arrow.transform.position.x, this.arrow.transform.position.y + 128 * 7 , this.arrow.transform.position.z);
        }
    }

    void selectPreviousFrame(){
        if(selectedFrame > 0){
            selectedFrame -= 1;
            this.arrow.transform.position = new Vector3(this.arrow.transform.position.x, this.arrow.transform.position.y + 128 , this.arrow.transform.position.z);
        }else{
            selectedFrame = 7;
            this.arrow.transform.position = new Vector3(this.arrow.transform.position.x, this.arrow.transform.position.y - 128 * 7 , this.arrow.transform.position.z);
        }

    }

    public void onPickup(int type, int thing){
        if(type == 0){
            if(state[type ,selectedFrame] == false){
                lengthsUI[selectedFrame].GetComponent<Image>().sprite = spritesLengths[thing];
            }
        }else if(type == 1){
            if(state[type ,selectedFrame] == false){ 
                instrumentsUI[selectedFrame].GetComponent<Image>().sprite = spritesInstruments[thing];
            }
        }


    }

}
