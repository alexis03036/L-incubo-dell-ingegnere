using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickMale : MonoBehaviour
{
    public Button male;

    private void Start()
    {
        Button btn = male.GetComponent<Button>();
        btn.onClick.AddListener(MaleCharacter);
    }
    void MaleCharacter()
    {
        Debug.Log("Creating a male character");
    }
}
