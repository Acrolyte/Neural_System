using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleScene : MonoBehaviour
{
   public string LoadSceneName;
   public void LoadScene()
   {
      SceneManager.LoadScene(LoadSceneName);
        Debug.Log("Loading scene: "+ LoadSceneName);
   }
}
