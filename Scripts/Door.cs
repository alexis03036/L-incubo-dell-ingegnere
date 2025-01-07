using UnityEngine;

public class Door : MonoBehaviour
{
    // Riferimento al giocatore
    public PlayerInteraction player;

    // Metodo chiamato quando il giocatore clicca sulla porta
    private void OnMouseDown()
    {
        // Se il giocatore ha il piede di porco, chiama il metodo di interazione
        if (player != null)
        {
            player.InteractWithDoor(gameObject);
        }
    }
}