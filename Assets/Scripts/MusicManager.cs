using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip StageTheme;
    public AudioClip BossTheme;
    public UI ui;
    public Boss boss;

    private AudioSource audiosrc;
    private bool bossMusicOn;
    private bool stageMusicOn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ui.IsReady)
        {
            return;
        }
            if (boss.BossActive)
            {
                if (bossMusicOn)
                {
                return;
                }
                if (stageMusicOn)
            {
                bossMusicOn = true;
                stageMusicOn = false;
                audiosrc.clip = BossTheme;
                audiosrc.Play();
            }
        }
            else
            {
                if (stageMusicOn)
                {
                    return;
                }
                if (bossMusicOn)
            {
                stageMusicOn = true;
                bossMusicOn = false;
                audiosrc.clip = StageTheme;
                audiosrc.Play();
            }
            }
    }
}
