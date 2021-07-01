using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyCount : MonoBehaviour
{
    public Text dummyCountText;
    public static int dummyCount = 1;
    
    void Update(){
        TextChange();
    }
    public void TextChange(){
        if(dummyCount<=0){
            dummyCountText.text = "0";
        }
        else{
            dummyCountText.text = dummyCount.ToString();
        }
        
    }
}
