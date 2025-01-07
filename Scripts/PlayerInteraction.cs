using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Flag che indica se il giocatore ha raccolto il piede di porco
    public bool hasCrowbar = false;

    // Metodo chiamato quando il giocatore entra in contatto con un oggetto
    private void OnTriggerEnter(Collider other)
    {
        // Se il giocatore entra in contatto con il piede di porco
        if (other.CompareTag("Crowbar"))
        {
            // Raccoglie il piede di porco
            hasCrowbar = true;

            // Rimuove il piede di porco dalla scena (lo distrugge)
            Destroy(other.gameObject);

            // Messaggio di conferma
            Debug.Log("Hai raccolto il piede di porco!");
        }
    }

    // Metodo per interagire con la porta 
    public void InteractWithDoor(GameObject door)
    {
        if (hasCrowbar)
        {
            // Se il giocatore ha il piede di porco, rompe la porta
            Destroy(door);
            Debug.Log("Hai rotto la porta con il piede di porco!");
        }
        else
        {
            // Se il giocatore non ha il piede di porco
            Debug.Log("Hai bisogno di un piede di porco per rompere questa porta.");
        }
    }
}