using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class BulletTime : MonoBehaviour
{
    public float slowMoFactor = 0.5f;
    public float maxBulletTime = 5f;
    public float drainRate = 1f;
    public float regenRate = 0.5f;
    public KeyCode slowMoKey = KeyCode.LeftShift;

    public Slider bulletTimeBar;
    public Image bulletTimeOverlay;
    public float overlayFadeSpeed = 3f;

    private float currentBulletTime;
    private float originFixedDeltaTime;
    private Color overlayColor;

    void Start()
    {

        currentBulletTime = maxBulletTime;
        originFixedDeltaTime = Time.fixedDeltaTime;

        if (bulletTimeOverlay != null)
            bulletTimeBar.maxValue = maxBulletTime;

        if (bulletTimeOverlay != null)
        {

            overlayColor = bulletTimeOverlay.color;
            overlayColor.a = 0f;
            bulletTimeOverlay.color = overlayColor;

        }

    }

    void Update()
    {

        bool isHolding = Input.GetKey(slowMoKey) && currentBulletTime > 0f;

        if (isHolding)
        {

            Time.timeScale = slowMoFactor;
            Time.fixedDeltaTime = originFixedDeltaTime * slowMoFactor;
            currentBulletTime -= drainRate * Time.unscaledDeltaTime;
            currentBulletTime = Mathf.Max(currentBulletTime, 0f);
            CentralAudioHub.Instance.SetPitch(0.9f);

        }
        else
        {

            Time.timeScale = 1f;
            Time.fixedDeltaTime = originFixedDeltaTime;
            currentBulletTime += regenRate * Time.unscaledDeltaTime;
            currentBulletTime = Mathf.Min(currentBulletTime, maxBulletTime);
            CentralAudioHub.Instance.SetPitch(1f);

        }

        if (bulletTimeBar != null)
            bulletTimeBar.value = currentBulletTime;

        if (bulletTimeOverlay != null)
        {

            float targetAlpha = isHolding ? 0.6f : 0f;
            overlayColor.a = Mathf.MoveTowards(overlayColor.a, targetAlpha, overlayFadeSpeed * Time.unscaledDeltaTime);
            bulletTimeOverlay.color = overlayColor;

        }

    }
}
