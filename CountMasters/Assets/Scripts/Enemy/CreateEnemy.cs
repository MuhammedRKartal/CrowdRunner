using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateEnemy : MonoBehaviour
{
    public Transform ch;
    public Transform enemy;

    private Vector3 spawnInTheBack;

    public static bool isInside = false;
    private float range = 3f;

    public int numberOfClones;
    public Canvas canv;
    private TextMeshProUGUI textMesh;

    public GameObject[] dummies;

    void Start(){
        textMesh = canv.GetComponent<TextMeshProUGUI>();
        textMesh.text = "vs "+numberOfClones.ToString()+"\nArea Damage";

        if(this.gameObject.tag == "EnemyMain"){
            for(int i=0; i<numberOfClones; i++){
                spawnInTheBack = new Vector3(Random.Range(-range,range),0,Random.Range(-range,range));
                Vector3 v = enemy.position+spawnInTheBack;
                Instantiate(ch,v,Quaternion.Euler (0, 180f, 0));
            }
        }

        
    }
    void Update(){
        dummies = GameObject.FindGameObjectsWithTag("Dummy");
        Vector3 x = Vector3.zero;
        try{
            x = GameObject.Find("Player").transform.position;
        }
        catch{

        }
        
        //Debug.Log(x);
        
        if(isInside == true){
            if(dummies.Length == 0){
                transform.Translate(x*Time.deltaTime);
                transform.LookAt(x);
            }
            else{
                int r = Random.Range(0,dummies.Length);
                GameObject rG = dummies[r];
                Vector3 ranDummy = rG.transform.position;

                transform.Translate(ranDummy*Time.deltaTime);
                transform.LookAt(ranDummy);               
            }
            
        }
    }
}
