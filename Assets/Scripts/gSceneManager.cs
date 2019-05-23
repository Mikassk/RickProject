using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gSceneManager : MonoBehaviour
{
    private static gSceneManager _instance;

    public SceneField startScene;
    public SceneField gameScene;
    public SceneField gameoverScene;
    public SceneField proxScene;
    public SceneField actualScene;
    public int life;
    public AudioClip gameoverSound;
    public AudioClip menuSound;
    public AudioClip gameSound;
    public int score;

    private AudioSource source;

    public static gSceneManager Instance { get; set; }

    private void Awake()
    {
        life = 3;
        score = 0;
        source = GetComponent<AudioSource>();
        source.clip = menuSound;
        source.Play();
    }

    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        actualScene = startScene;
    }

    // Update is called once per frame
    void Update()
    {

        if (proxScene == gameoverScene && actualScene != gameoverScene && life <= 0)
        {
            actualScene = gameoverScene;
            SceneManager.LoadScene(proxScene, LoadSceneMode.Single);
            source.Stop();
            source.PlayOneShot(gameoverSound, 1.0f);
        }
        if (proxScene == gameScene && actualScene != gameScene)
        {
            actualScene = gameScene;
            SceneManager.LoadScene(proxScene, LoadSceneMode.Single);
            source.clip = gameSound;
            source.Play();
        }
    }
}
