using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using static CharacterCreator;
using System.Runtime.CompilerServices;

public class SceneLoader : MonoBehaviour
{
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MenùPrincipale");
        }
    }
    
}
