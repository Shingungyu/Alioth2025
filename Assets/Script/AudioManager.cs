using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField]
    private AudioClip[] audioClips; // AudioClip �迭

    [SerializeField]
    private AudioSource backgroundAudio;

    private string lastSceneName; // ���� �� �̸��� ����

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� ����
        }
        else
        {
            Destroy(gameObject); // �ߺ��� AudioManager ����
            return;
        }
    }

    void Start()
    {
        lastSceneName = SceneManager.GetActiveScene().name;
        UpdateBackgroundMusic(lastSceneName); // �ʱ� ���� ���� ������� ����
    }

    void Update()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        // ���� ����� ��쿡�� ������� ����
        if (currentSceneName != lastSceneName)
        {
            lastSceneName = currentSceneName;
            UpdateBackgroundMusic(currentSceneName);
        }
    }

    private void UpdateBackgroundMusic(string sceneName)
    {
        AudioClip newClip = null;

        // �� �̸��� ���� AudioClip ����
        switch (sceneName)
        {
            case "Stg1-1": 
            case "Stg1-2":
            case "Stg1-3":
            case "Stg1-4":
            case "Stg1-5":
                newClip = audioClips[1];
                break;

            case "Stg2-1":
            case "Stg2-2":
            case "Stg2-3":
            case "Stg2-4":
            case "Stg2-5":
                newClip = audioClips[2];
                break;

            case "Stg3-1":
            case "Stg3-2_Story":
            case "Stg3-3":
            case "Stg3-4":
                newClip = audioClips[3];
                break;

            case "Stg4-1_(Story)":
            case "Stg4-2":
            case "Stg4-3":
                newClip = audioClips[4];
                break;

            case "Stg5-1":
            case "Stg5-2":
            case "Stg5-3":
            case "Stg5-4":
                newClip = audioClips[5];
                break;

            case "Stg6-1":
            case "Stg6-2":
            case "Stg6-3":
            case "Stg6-4":
                newClip = audioClips[6];
                break;

            case "Lobby":
                newClip = audioClips[0];
                break;
        }

        // ���� ��� ���� Ŭ���� �� Ŭ���� �ٸ� ��쿡�� ���� �� ���
        if (backgroundAudio.clip != newClip)
        {
            backgroundAudio.clip = newClip;

            // ���ο� Ŭ���� �����Ǿ��� ��쿡�� ���
            if (backgroundAudio.clip != null)
            {
                backgroundAudio.Play();
            }
        }
    }
}
