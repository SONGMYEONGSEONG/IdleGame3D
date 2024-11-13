using System;
using UnityEngine;
using Utill;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Player player;
    public Player Player { get => player; set => player = value; }
    private UIMain _uiMain;

    protected override void Awake()
    {
        base.Awake();

        if (player == null)
        {
            Instantiate(Resources.Load("Prefebs/Player"));
        }
        else
        {
            Instantiate(player);
        }

        _uiMain = UIManager.Instance.GetUI<UIMain>("UIMain");
    }


    private void Update()
    {
        if (_uiMain != null)
        {
            _uiMain.PlayerStatusUpdate(player.Data.Health, player.Data.Mana);
            _uiMain.PlayerLevelUpdate(player.Data.Level, player.Data.Exp);
            _uiMain.PlayerGetCoinUpdate(player.Data.curCoin);

            //Debug
            _uiMain.StageNumberUpadte(1);
            //
        }

    }
}

