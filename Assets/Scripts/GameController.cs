using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameObject enemy;

    IEnumerator Start() 
    { 
         yield return new WaitForSeconds(1);
         enemy.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(0);
    }


}
