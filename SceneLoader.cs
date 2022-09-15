using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainAssets
{
    public class SceneLoader : MonoBehaviour
    {
        private List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

        private void OnEnable()
        {
            if (SceneManager.sceneCount == 1) // Checks if scenes are already loaded. If not then loads the scene Cubes and add scene UI.
            {
                scenesToLoad.Add(SceneManager.LoadSceneAsync("Cubes"));
                scenesToLoad.Add(SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive));
            }
        }

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.R)) // Listens for "R". If clicked - restarts the program.
            {
                scenesToLoad.Add(SceneManager.LoadSceneAsync("Cubes"));
                scenesToLoad.Add(SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive));
            }
        }
    }
}