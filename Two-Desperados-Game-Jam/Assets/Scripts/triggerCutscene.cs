using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class triggerCutscene : MonoBehaviour{

    public PlayableDirector m_cutscene;
    void OnTriggerEnter(Collider other){
        m_cutscene.Play();
        StartCoroutine(LoadLevelAfterDelay(10));
    }
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MainScene");
    }
}
