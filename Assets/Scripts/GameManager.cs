using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] players;

    public void CheckWinState(){
        int aliveCount = 0;

        foreach(GameObject player in players){
            if(player.activeSelf){
                aliveCount++;
            }
        }
        if(aliveCount <= 1){
            Invoke(nameof(NewRound), 3f);
        }
    }

    private void NewRound(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
