using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void OnCharacterSelected(GameObject button)
    {
        CardDataLoader.Instance.SelectedCharacter(button);
        SceneManager.LoadScene(sceneName);
    }
    public void OnTeamSelected(GameObject button)
    {
        CardDataLoader.Instance.SelectedTeam(button);
    }
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit");
    }
}
