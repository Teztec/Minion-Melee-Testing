using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Lobbies.Models;
using Unity.Services.Lobbies;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager Instance;

    public Lobby CurrentLobby { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public async Task CreateLobbyAsync(string lobbyName, int maxPlayers)
    {
        try
        {
            var options = new CreateLobbyOptions
            {
                IsPrivate = false,
                //Player = new Player(id: AuthenticationService.Instance.PlayerId),
                Data = new Dictionary<string, DataObject>
                {
                    { "GameMode", new DataObject(DataObject.VisibilityOptions.Public, "Default") }
                }
            };

            CurrentLobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, options);
            Debug.Log("Lobby created: " + CurrentLobby.Id);
        }
        catch (LobbyServiceException e)
        {
            Debug.LogError("Create lobby failed: " + e);
        }
    }

    public async Task<List<Lobby>> QuickListLobbies()
    {
        try
        {
            var response = await LobbyService.Instance.QueryLobbiesAsync();
            return response.Results;
        }
        catch (LobbyServiceException e)
        {
            Debug.LogError("Query lobbies failed: " + e);
            return new List<Lobby>();
        }
    }

    public async Task JoinLobbyAsync(string lobbyId)
    {
        try
        {
            var joinLobby = await LobbyService.Instance.JoinLobbyByIdAsync(lobbyId);
            CurrentLobby = joinLobby;
            Debug.Log("Joined lobby: " + CurrentLobby.Id);
        }
        catch (LobbyServiceException e)
        {
            Debug.LogError("Join lobby failed: " + e);
        }
    }
}
