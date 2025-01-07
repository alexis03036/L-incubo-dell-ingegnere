using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor.Experimental.GraphView;

public class BotChaseAndKill : MonoBehaviour
{

    public Transform player;
    public float speed = 3.0f;
    public float stoppingDistance = 0.9f;
    public float killDistance = 1.0f;
    private bool chasingPlayer = true;
    public bool lockx = false;
    public bool locky = false;
    public bool lockz = false;
    public GameObject ilbro;



    private void Update()
    {
        

            if (!chasingPlayer)
            {
                return;
            }

            Vector3 direction = player.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Vector3 eulerAngles = targetRotation.eulerAngles;
        if (lockx) eulerAngles.x = transform.eulerAngles.x;
        if (locky) eulerAngles.y = transform.eulerAngles.y;
        if (lockz) eulerAngles.z = transform.eulerAngles.z;
        transform.rotation = Quaternion.Euler(eulerAngles); 



        float distance = direction.magnitude;

            if (distance > stoppingDistance)
            {
                direction.Normalize();
                transform.position += direction * speed * Time.deltaTime;
            }

            if (distance <= killDistance)
            {
                KillPlayer();
            }
        
        }

        private void KillPlayer()
        {
            Debug.Log("Il bot ha ucciso il giocatore!");
            SceneManager.LoadScene("GameOver");
            Destroy(player.gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                KillPlayer();
            }


        }

      



        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Door"))
            {
                //chasingPlayer = false;
                Debug.Log("Il bot ha smesso di inseguire il giocatore.");
            ilbro.SetActive(false);
            
            }
            


        }
    

}
