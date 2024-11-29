using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField]
    private AudioClip[] audioClips; // AudioClip 배열

    [SerializeField]
    private AudioSource backgroundAudio;

    private string lastSceneName; // 이전 씬 이름을 저장

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않음
        }
        else
        {
            Destroy(gameObject); // 중복된 AudioManager 제거
            return;
        }
    }

    void Start()
    {
        lastSceneName = SceneManager.GetActiveScene().name;
        UpdateBackgroundMusic(lastSceneName); // 초기 씬에 대한 배경음악 설정
    }

    void Update()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        // 씬이 변경된 경우에만 배경음악 갱신
        if (currentSceneName != lastSceneName)
        {
            lastSceneName = currentSceneName;
            UpdateBackgroundMusic(currentSceneName);
        }
    }

    private void UpdateBackgroundMusic(string sceneName)
    {
        AudioClip newClip = null;

        // 씬 이름에 따른 AudioClip 선택
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

        // 현재 재생 중인 클립과 새 클립이 다를 경우에만 변경 및 재생
        if (backgroundAudio.clip != newClip)
        {
            backgroundAudio.clip = newClip;

            // 새로운 클립이 설정되었을 경우에만 재생
            if (backgroundAudio.clip != null)
            {
                backgroundAudio.Play();
            }
        }
    }
}
