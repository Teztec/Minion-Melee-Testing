using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterSelectionUI : MonoBehaviour
{
    public Transform bossPanel;  // Assign the monster toggle panel
    public Transform teamPanel;   // Assign the minion toggle panel

    private Dictionary<Toggle, string> toggleTeamMap = new();

    private void Start()
    {
        RegisterToggles(bossPanel, bossPanel.name);
        RegisterToggles(teamPanel, teamPanel.name);
    }

    private void RegisterToggles(Transform panel, string teamName)
    {
        foreach (Toggle toggle in panel.GetComponentsInChildren<Toggle>())
        {
            toggleTeamMap[toggle] = teamName;
            toggle.onValueChanged.AddListener((isOn) =>
            {
                if (isOn)
                {
                    OnCharacterToggleChanged(toggle);
                }
            });
        }
    }

    private void OnCharacterToggleChanged(Toggle toggle)
    {
        string characterName = toggle.name;
        string team = toggleTeamMap[toggle];

        Debug.Log($"Character Selected: {characterName} from Team {team}");

        // Example usage:
        // CardDataLoader.Instance.SelectTeamByName(characterName);
        // MatchManager.Instance.AssignToTeam(team, characterName);
    }
}
