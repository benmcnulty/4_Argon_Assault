using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In Seconds")][SerializeField] float levelLoadDelay = 2f;
    [Tooltip("FX Prefab on Player")] [SerializeField] GameObject crashFX;

    bool playerCrashed = false;

    int currentSceneIndex;

    // Use this for initialization
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!playerCrashed)
        {
            print("Player Triggered: " + other);
            SendMessage("OnPlayerCrash");
        }
        
    }

    void OnPlayerCrash()
    {
        playerCrashed = true;
        crashFX.SetActive(true);
        Invoke("ReloadCurrentScene", levelLoadDelay);
    }

    void ReloadCurrentScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
}
