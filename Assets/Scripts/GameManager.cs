using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public string SelectedTeam { get; private set; } // ← renamed for clarity

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // This is the method you call from the button
    public void SelectTeam(GameObject button)
    {
        //string teamName = button.name;
        //SelectedTeam = teamName; // ← this was the bug!

        TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
        SelectedTeam = text.text;
    }
}
