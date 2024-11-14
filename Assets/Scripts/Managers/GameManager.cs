using System;
using UnityEngine;
using Utill;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Player player;
    public Player Player { get => player; set => player = value; }
    private UIMain _uiMain;

    public Vector3 PlayerSpawnPos;

    protected override void Awake()
    {
        base.Awake();

        if (player == null)
        {
            Instantiate(Resources.Load("Prefebs/Player"));
        }
        else
        {
            PlayerRespawn();
        }

        _uiMain = UIManager.Instance.GetUI<UIMain>("UIMain");
    }

    public void PlayerRespawn()
    {
        Instantiate(player);
        player.transform.position = PlayerSpawnPos;
    }

    private void Update()
    {
        if (_uiMain != null)
        {
            _uiMain.PlayerStatusUpdate(player.Health.CurHealth, player.Data.Mana);
            _uiMain.PlayerLevelUpdate(player.Data.Level, player.Data.Exp);
            _uiMain.PlayerGetCoinUpdate(player.Data.curCoin);
        }

    }
}

