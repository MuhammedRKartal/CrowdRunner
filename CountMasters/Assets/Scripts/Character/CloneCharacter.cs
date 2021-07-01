using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CloneCharacter : MonoBehaviour
{
    public Transform ch;
    public Transform plyr;
    private bool isInside = false;
    private Vector3 spawnInTheBack;
    private float range = 0.6f;
    public int numberOfClones;

    public Canvas a;
    private TextMeshProUGUI textMesh;

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            isInside = true; 
        }
    }

    void Start(){
        textMesh = a.GetComponent<TextMeshProUGUI>();
        textMesh.text = "+"+numberOfClones.ToString();
    }

    void Update(){
        if(isInside == true){
            DummyCount.dummyCount += numberOfClones;
            //Debug.Log(DummyCount.dummyCount);
    
            for(int i=0; i<numberOfClones; i++){
                spawnInTheBack = new Vector3(Random.Range(-range,range),0,Random.Range(-range,range));
                Instantiate(ch,plyr.position+spawnInTheBack,Quaternion.identity);
            }
            gameObject.SetActive(false);
        }
    }
}
