using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class KillPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    

    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Scene currentScene = SceneManager.GetActiveScene();
            // SceneManager.LoadScene(currentScene.name);
            player.SetActive(false);
            Debug.Log("TOCCATO");
          

            

        }
    }
}

