using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Versus : MonoBehaviour
{
    public string[] tags;
    private bool collided = false;
    void OnTriggerEnter(Collider col){
        foreach(string tag in tags){
            if(!collided){
                if(col.gameObject.CompareTag(tag)){
                    if (this.gameObject.tag =="Player"){
                        if(DummyCount.dummyCount == 1){
                            collided = true;
                            DummyCount.dummyCount -=1;
                            Destroy(this.gameObject);
                            StartCoroutine(nextScene());  
                        } 
                    }
                    else if(this.gameObject.tag == "Dummy") {
                        collided = true;
                        DummyCount.dummyCount -=1;  
                        Destroy(this.gameObject);
                    }
                    else if(this.gameObject.tag =="Enemy"){
                        if(col.gameObject.tag == "Dummy"){
                            collided = true;
                            Destroy(this.gameObject);
                        }
                        else{
                            collided = false;
                        }
                    }
                    else if(this.gameObject.tag =="EnemyMain"){
                        if(col.gameObject.tag == "Dummy"){
                            collided = true;
                            Destroy(this.gameObject);
                        }
                        else{
                            collided = false;
                        }
                    }
                }
            }
        }   
    }

    IEnumerator nextScene()
    {
        CreateEnemy.isInside = false;
        DummyCount.dummyCount =1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return new WaitForSeconds(0.2f);
    }
    
}
