using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : UIBase
{
    [Header("PlayerStatus")]
    [SerializeField] private Image healthBar;
    [SerializeField] private Image manaBar;

    [Header("Level")]
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Image expImg;

    [Header("Coin")]
    [SerializeField] private TextMeshProUGUI getCoinAccount;

    [Header("Stage")]
    [SerializeField] private TextMeshProUGUI stageNumber;

    StringBuilder strbuilder = new StringBuilder();

    private void Awake()
    {
        UIManager.Instance.UISet(this);
    }

    public void PlayerStatusUpdate(int health, int mana)
    {
        float f_Hp = health;
        float f_Mp = mana;

        healthBar.fillAmount = f_Hp / GameManager.Instance.Player.Data.MaxHealth;
        manaBar.fillAmount = f_Mp / GameManager.Instance.Player.Data.MaxMana;
    }

    public void PlayerLevelUpdate(int Level, int exp)
    {
        float f_Exp = exp;

        levelText.text = Level.ToString();
        expImg.fillAmount = f_Exp / GameManager.Instance.Player.Data.MaxExp;
    }

    public void PlayerGetCoinUpdate(int curCoin)
    {
        getCoinAccount.text = curCoin.ToString();
    }

    public void StageNumberUpadte(int curStageNum)
    {
        strbuilder.Clear();
        strbuilder.Append("Stage ");
        strbuilder.Append(curStageNum.ToString());
        stageNumber.text = strbuilder.ToString();
    }

}
