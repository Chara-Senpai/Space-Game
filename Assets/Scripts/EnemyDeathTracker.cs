using UnityEngine;

public class EnemyDeathTracker : MonoBehaviour
{

    public EnemySpawner spawner;
    public int scoreValue = 100;
    void OnDestroy()
    {

        if (spawner != null)
        {

            spawner.ReportEnemyDeath(gameObject);

        }

         if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(scoreValue);
        }
    }


}


