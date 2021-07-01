using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Colliding : MonoBehaviour
{
    public Text dummyCountText;
    private bool isDestroyPlane = false;



    void Update()
    {
        //Debug.Log(DummyCount.dummyCount);
        if(DummyCount.dummyCount < 1){
            dummyCountText.text = "0";
            StartCoroutine(nextScene()); 
        }
        if(isDestroyPlane){
            if (this.gameObject.tag =="Player"){
                if(DummyCount.dummyCount == 1){
                    DummyCount.dummyCount -=1;
                    //Debug.Log("burada");
                    StartCoroutine(nextScene()); 
                }   
            }
            else{
                DummyCount.dummyCount -=1;
                Destroy(this.gameObject);
            }
        }

    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("DestroyPlane")){
            isDestroyPlane= true;
        }

        if(col.gameObject.CompareTag("EnemyZone")){
            CreateEnemy.isInside = true; 
        }

        if(col.gameObject.CompareTag("SpeedZone"))
        {
            CharacterMove.isEnhanced = true;
        }

        if(col.gameObject.CompareTag("JumpZone"))
        {
            CharacterMove.isJump = true;
        }

    }
    void OnTriggerExit(Collider col){
        if(col.gameObject.CompareTag("EnemyZone")){
            CreateEnemy.isInside = false; 
        }
    }

    IEnumerator nextScene()
    {
        Destroy(this.gameObject);
        DummyCount.dummyCount = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return new WaitForSeconds(2f);
        

    }
}
