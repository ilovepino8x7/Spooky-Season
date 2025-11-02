using System.Collections;
using UnityEngine;
using TMPro;
using System.Buffers.Text;
using UnityEngine.SceneManagement;
using System;
public class tutorial : MonoBehaviour
{
  public string[] stages;
  private int tutorialNum = 0;
  private bool switching = false;
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
    else if (tutorialNum == 3 && !switching)
    {
      switching = true;
      StartCoroutine(Wait(2, () => switchTutorial(3)));
    }
    else if (tutorialNum == 4)
    {
      if (Input.GetKeyDown(KeyCode.LeftShift))
      {
        tutorialNum = 5;
      }
    }
  }
  public IEnumerator Wait(int time, Action func = null)
  {
    yield return new WaitForSeconds(time);
    func?.Invoke();
  }
  public void switchTutorial(int current)
  {
    tutorialNum = current + 1;
  }
}
