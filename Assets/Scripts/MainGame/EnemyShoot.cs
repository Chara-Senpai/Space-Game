using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
   public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;

    public float fireDelay = 0.75f;
    float shootTimer = 0;
    void Update()
    {

        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0)
        {

            shootTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGO.layer = LayerMask.NameToLayer("EnemyBullet");

            CentralAudioHub.Instance.PlayEnemyFire();
            
        }
        
    }
}
