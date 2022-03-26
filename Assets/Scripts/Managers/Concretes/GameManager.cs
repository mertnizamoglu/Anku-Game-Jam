using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ANKU.Managers.Concretes
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        private void Awake()
        {
            SingletonObject();
        }
        private void SingletonObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        } 
        public void LoadSelfScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void LoadSceneByIndex(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        
        public void PlayButtonPressed(int sceneIndex)
        {
            StartCoroutine(PlayButtonEnumerator(sceneIndex));
        }
        public void CreditsButtonPressed()
        {
        }

        private IEnumerator PlayButtonEnumerator(int sceneIndex)
        {
            yield return new WaitForSeconds(5.4f); //delay time
            SceneManager.LoadScene(sceneIndex);
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
    
}