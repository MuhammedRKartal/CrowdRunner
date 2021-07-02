using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeleteCharacter : MonoBehaviour
{
    public GameObject[] dummies;
    public int numberOfClones;
    private bool isInside;
    private GameObject player;
    public GameObject rock;
    private Animator rockAnim;

    public Canvas a;
    private TextMeshProUGUI textMesh;


    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            isInside = true; 
            player = col.gameObject;
        }
    }

    void Start(){
        rockAnim = rock.GetComponent<Animator>();
        textMesh = a.GetComponent<TextMeshProUGUI>();
        textMesh.text = "-"+numberOfClones.ToString();
    }

    void Update(){
        dummies = GameObject.FindGameObjectsWithTag("Dummy");
        if(isInside == true){
            isInside = false;
            rockAnim.SetBool("isActivated", true);
            DummyCount.dummyCount -= numberOfClones;
            if(numberOfClones>dummies.Length){
                /*Destroy(player);
                foreach(GameObject dummy in dummies){
                    Destroy(dummy);
                }*/
                StartCoroutine(nextScene()); 
            }
            else{
                for(int i=0; i<numberOfClones; i++){
                    Destroy(dummies[i]);
                } 
            }
            Destroy(this.gameObject);
        }
    }
    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(2f);
        Destroy(player);
        foreach(GameObject dummy in dummies){
            Destroy(dummy);
        }
        DummyCount.dummyCount = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        
        

    }
}
