using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DummyCount : MonoBehaviour
{
    public Text dummyCountText;
    public static int dummyCount = 1;

    public TextMeshProUGUI score;
    
    void Update(){
        TextChange();
        score.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
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
