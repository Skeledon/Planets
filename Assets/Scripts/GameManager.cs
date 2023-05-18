using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject _playerShip;

    [SerializeField]
    string _sceneName;

    [SerializeField]
    float _waitAfterPlayerDestruction;

    private Rewired.Player _player;

    private void Awake()
    {
        _playerShip.GetComponent<ShipController>().ShipDestroyed += PlayerShipDestroyed;
        _player = Rewired.ReInput.players.GetPlayer(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.GetButton("ResetGame"))
            ResetDebugLevel();
    }

    public void ResetDebugLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    private void PlayerShipDestroyed()
    {
        StartCoroutine(WaitBeforeGameReset(_waitAfterPlayerDestruction));
    }

    IEnumerator WaitBeforeGameReset(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ResetDebugLevel();
    }
}
