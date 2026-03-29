using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public static GameAudio Instance { get; private set; }

    private AudioSource _sfxSource;

    private AudioClip _shootClip;
    private AudioClip _enemyShootClip;
    private AudioClip _explosionClip;
    private AudioClip _deathClip;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        _sfxSource = gameObject.AddComponent<AudioSource>();
        _sfxSource.playOnAwake = false;
        _sfxSource.spatialBlend = 0f;
        _sfxSource.volume = 0.35f;

        _shootClip = CreateToneClip("Shoot", 880f, 0.07f, 0.18f, 0.03f);
        _enemyShootClip = CreateToneClip("EnemyShoot", 320f, 0.08f, 0.16f, 0.02f);
        _explosionClip = CreateNoiseClip("Explosion", 0.14f, 0.25f);
        _deathClip = CreateToneClip("Death", 180f, 0.22f, 0.28f, 0.18f);
    }

    public void PlayShoot()
    {
        if (_shootClip != null) _sfxSource.PlayOneShot(_shootClip, 0.85f);
    }

    public void PlayEnemyShoot()
    {
        if (_enemyShootClip != null) _sfxSource.PlayOneShot(_enemyShootClip, 0.75f);
    }

    public void PlayExplosion()
    {
        if (_explosionClip != null) _sfxSource.PlayOneShot(_explosionClip, 1f);
    }

    public void PlayDeath()
    {
        if (_deathClip != null) _sfxSource.PlayOneShot(_deathClip, 1f);
    }

    private static AudioClip CreateToneClip(string name, float freq, float duration, float volume, float falloffStart)
    {
        const int sampleRate = 44100;
        var sampleCount = Mathf.CeilToInt(duration * sampleRate);
        var data = new float[sampleCount];

        for (var i = 0; i < sampleCount; i++)
        {
            var t = (float)i / sampleRate;
            var fade = t < falloffStart ? 1f : Mathf.Clamp01(1f - (t - falloffStart) / (duration - falloffStart));
            data[i] = Mathf.Sin(2f * Mathf.PI * freq * t) * volume * fade;
        }

        var clip = AudioClip.Create(name, sampleCount, 1, sampleRate, false);
        clip.SetData(data, 0);
        return clip;
    }

    private static AudioClip CreateNoiseClip(string name, float duration, float volume)
    {
        const int sampleRate = 44100;
        var sampleCount = Mathf.CeilToInt(duration * sampleRate);
        var data = new float[sampleCount];

        for (var i = 0; i < sampleCount; i++)
        {
            var t = (float)i / sampleRate;
            var envelope = Mathf.Clamp01(1f - t / duration);
            data[i] = (Random.value * 2f - 1f) * volume * envelope;
        }

        var clip = AudioClip.Create(name, sampleCount, 1, sampleRate, false);
        clip.SetData(data, 0);
        return clip;
    }
}
