using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject exp;
    public string sname;
    private int oldScore = 0;

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player"))
        {
            /*Debug.Log("Current:"+DummyCount.dummyCount);
            Debug.Log("CurrentSave:"+PlayerPrefs.GetInt("Score").ToString());
            Debug.Log("OldScore:"+oldScore);*/
            oldScore = DummyCount.dummyCount + PlayerPrefs.GetInt("Score");
            PlayerPrefs.SetInt("Score", oldScore);
            StartCoroutine(nextScene());
        }
    }

    IEnumerator nextScene()
    {
        exp.SetActive(true);
        GameObject.FindWithTag("Player").GetComponent<CharacterMove>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        DummyCount.dummyCount = 1;
        SceneManager.LoadScene(sceneName: sname);

    }
}
