using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    private void Awake()
    {
        if (!File.Exists(Application.persistentDataPath + "/save.ice"))
        {
            playerStats.coins = 0;
            playerStats.Save();
        }
        Time.timeScale = 1f;
        playerStats.Load();
    }

    public void ChangeScene()
    {
        if (SceneManager.GetActiveScene().buildIndex.Equals(0))
            SceneManager.LoadScene(1);

        if (SceneManager.GetActiveScene().buildIndex.Equals(1))
            SceneManager.LoadScene(0);
    }

    public void RestartStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
