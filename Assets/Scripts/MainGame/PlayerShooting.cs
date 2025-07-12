using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;

    public float fireDelay = 0.25f;
    float shootTimer = 0;

    public AudioClip shootSound;
    void Update()
    {

        shootTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && shootTimer <= 0)
        {

            shootTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGO.layer = LayerMask.NameToLayer("PlayerBullet"); 
            
            CentralAudioHub.Instance.PlayBulletShot();
        }
        
    }
}
