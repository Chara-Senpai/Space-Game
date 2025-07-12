using UnityEngine;

public class DamageHandler : MonoBehaviour
{

    public int health = 1;
    float invulntimer = 0;
    public float invulnPeriod = 0;
    int correctlayer;
    SpriteRenderer spriteRend;
    void Start()
    {

        correctlayer = gameObject.layer;

        spriteRend = GetComponent<SpriteRenderer>();

        spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        health--;

        invulntimer = 1f;

        invulntimer = invulnPeriod;

        gameObject.layer = 8;
        
        CentralAudioHub.Instance.PlayPlayerHit();
        
    }

    void Update()
    {

        invulntimer -= Time.deltaTime;
        if (invulntimer <= 0)
        {

            gameObject.layer = correctlayer;

            if (spriteRend != null)
            {

                spriteRend.enabled = true;

            }

        }
        else
        {
            if (spriteRend != null)
            {

                spriteRend.enabled = !spriteRend.enabled;

            }
        }
        if (health <= 0)
            {

                Die();

            }
        
        void Die()
        {

            Destroy(gameObject);

        } 

    }
}
