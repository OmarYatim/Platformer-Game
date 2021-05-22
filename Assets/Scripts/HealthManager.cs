using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] List<GameObject> HeartImages;
    [SerializeField] GameObject LoseMenu;
    int PlayerLives = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            PlayerHit();
        }
    }

    void PlayerHit()
    {
        PlayerLives--;
        int count = HeartImages.Count;
        Destroy(HeartImages[count - 1]);
        HeartImages.RemoveAt(count - 1);
        if(PlayerLives == 0)
        {
            LoseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
