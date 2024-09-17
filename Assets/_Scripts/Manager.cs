using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public void OnEnable()
    {
        SceneManager.LoadScene("Desert_Strike");
    }
    public void StartLvl()
    {
        SceneManager.LoadScene("Game Scene");
    }    
}
