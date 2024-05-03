using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    

   // Update is called once per frame
    void Update()
    {
        ScoreText.text = GameManager.InstanceGameManager.PlayerScore.ToString();
    }
}
