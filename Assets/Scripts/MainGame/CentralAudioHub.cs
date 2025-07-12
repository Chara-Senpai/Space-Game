using UnityEngine;

public class CentralAudioHub : MonoBehaviour
{
    public static CentralAudioHub Instance { get; private set; }

    public AudioSource sfxSource;
    public AudioSource musicSource;

    public AudioClip bulletShotClip;
    public AudioClip playerHitClip;
    public AudioClip otherEffectClip;
    public AudioClip backgroundMusic;
    public AudioClip enemyFireClip;
    public AudioClip enemyHitClip;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayMusic(backgroundMusic);
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }


    public void PlayBulletShot() => PlaySFX(bulletShotClip);
    public void PlayOtherEffect() => PlaySFX(otherEffectClip);

    public void PlayEnemyFire() => PlaySFX(enemyFireClip);
    public void PlayEnemyHit() => PlaySFX(enemyHitClip);
    public void PlayPlayerHit() => PlaySFX(enemyHitClip);

    public void PlayMusic(AudioClip musicClip)
    {
        if (musicSource != null && musicClip != null)
        {
            musicSource.clip = musicClip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void SetPitch(float newPitch)
    {

        if (musicSource != null)
            musicSource.pitch = newPitch;

        if (sfxSource != null)
            sfxSource.pitch = newPitch;
            
    }
}
