using System.Collections;
using UnityEngine;
using TMPro;
using System.Buffers.Text;
using UnityEngine.SceneManagement;
public class tutorial : MonoBehaviour
{
  public string[] stages;
  public int tutorialNum = 0;
  public TMP_Text tut;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    if (SceneManager.GetActiveScene().name == "LevelOne")
    {
      tutorialNum = 0;
    }
    else if (SceneManager.GetActiveScene().name == "LevelTwo")
    {
      tutorialNum = 3;
    }
  }
  void Update()
  {
    CheckStage();
    tut.text = stages[tutorialNum];
  }
  public void CheckStage()
  {
    if (tutorialNum == 0)
    {
      if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
      {
        tutorialNum = 1;
      }
    }
    else if (tutorialNum == 1)
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        tutorialNum = 2;
      }
    }
    else if (tutorialNum == 3)
    {
      if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
      {
        {
          tutorialNum = 4;
          StartCoroutine(Wait(2));
        }
      }
    }
    else if (tutorialNum == 4)
    {
      if (Input.GetKeyDown(KeyCode.LeftShift))
      {
        tutorialNum = 5;
      }
    }


  }
  public IEnumerator Wait(int time)
    {
        yield return new WaitForSeconds(time);
    } 
}
