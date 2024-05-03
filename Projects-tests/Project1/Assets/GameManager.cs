using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager InstanceGameManager;
    public int PlayerScore = 0;
    public bool PlayerIsDead = false;
    public Transform EnemiesC;


    private void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (InstanceGameManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            InstanceGameManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Victory()
    {
        print("EC :" + EnemiesC.childCount);
        if (EnemiesC.childCount <= 1)
        {
            
            SceneManager.LoadScene("Victory");
        }
        
    }

    public void GameOver()
    {
        if (PlayerIsDead)
        {
            SceneManager.LoadScene("GameOver");
        }

    }
}
