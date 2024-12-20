using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class femalebutton : MonoBehaviour
{
    public Button female;

    private void Start()
    {
        Button btn = female.GetComponent<Button>();
        btn.onClick.AddListener(femaleCharacter);
    }
    void femaleCharacter()
    {
        Debug.Log("Creating a female character");
    }
}