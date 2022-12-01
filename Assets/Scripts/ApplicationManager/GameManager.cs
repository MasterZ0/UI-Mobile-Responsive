using TritanTest.Data;
using TritanTest.Shared;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TritanTest.ApplicationManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameSettings gameSettings;

        private void Awake()
        {
            gameSettings.Initialize();

            Scene scene = SceneManager.GetActiveScene();
            GameObject[] rootObjects = scene.GetRootGameObjects();

            foreach (GameObject go in rootObjects)
            {
                foreach (IInitable script in go.GetComponentsInChildren<IInitable>(true))
                {
                    script.Init();
                }
            }
        }
    }
}