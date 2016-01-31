using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    #region Singleton
    private static AudioManager _instance = null;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var audioGO = new GameObject("Audio Manager");
                _instance = audioGO.AddComponent<AudioManager>();
            }

            return _instance;
        }
    }

    // Use this for initialization
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }

        _instance = this;
        DontDestroyOnLoad(this);
    }
    #endregion

    public enum FadeState
    {
        None,
        FadingOut,
        FadingIn
    }

    public bool _playMusicOnAwake = false;

    public AudioClip[] _songs;
    public AudioClip[] _sfx;

    /// <summary>
    ///   Volume to end the previous clip at.
    /// </summary>
    public float _fadeOutThreshold = 0.05f;

    /// <summary>
    ///   Volume change per second when fading.
    /// </summary>
    public float _fadeSpeed = 0.05f;

    /// <summary>
    ///   Whether the audio source is currently fading, in or out.
    /// </summary>
    private FadeState _fadeState = FadeState.None;

    /// <summary>
    ///   Actual audio source.
    /// </summary>
    private AudioSource _audioSource = null;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (_audioSource == null)
            _audioSource = gameObject.AddComponent<AudioSource>();

        if (_playMusicOnAwake)
        {
            _audioSource.clip = _songs[SceneManager.GetActiveScene().buildIndex];
            _audioSource.Play();
        }
    }

    public void FadeOut()
    {
        if (_audioSource.enabled && _audioSource.isPlaying)
        {
            _fadeState = FadeState.FadingOut;
        }
    }

    void Update()
    {
        if (!_audioSource.enabled)
            return;

        if (_fadeState == FadeState.FadingOut)
        {
            if (_audioSource.volume > _fadeOutThreshold)
            {
                _audioSource.volume -= _fadeSpeed * Time.deltaTime;
            }
        }
    }

    void OnLevelWasLoaded(int level)
    {
        Debug.Log("OnLevelWasLoaded");
        if (_playMusicOnAwake)
        {
            _audioSource.clip = _songs[level];
            _audioSource.Play();
        }
    }
}
