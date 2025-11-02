using UnityEngine;
using UnityEngine.SceneManagement;

public class levelControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadNext()
    {
        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            SceneManager.LoadScene("LevelTwo");
        }
        if (SceneManager.GetActiveScene().name == "LevelTwo")
        {
            SceneManager.LoadScene("LevelThree");
        }
        if (SceneManager.GetActiveScene().name == "LevelThree")
        {
            SceneManager.LoadScene("LevelFour");
        }
        if (SceneManager.GetActiveScene().name == "LevelFour")
        {
            SceneManager.LoadScene("Menu");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LoadNext();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("LevelOne");
    }
    public void OpenBuilder()
    {
        SceneManager.LoadScene("Builder");
    }
}
