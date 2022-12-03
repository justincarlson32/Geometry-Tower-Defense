using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMgr : MonoBehaviour
{

    public List<GameObject> Indicators1, Indicators2;

    public GameObject upgradeSlot1, upgradeSlot2, self;

    public Text price1, price2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upgrade1ButtonPressed()
    {
        if (UIMgr.inst.selectedTower.upgradeSlot1 < 4)
        {
            if (PlayerMgr.inst.playerMoney >= (UIMgr.inst.selectedTower.upgradeSlot1 * 250))
            {
                PlayerMgr.inst.playerMoney -= (UIMgr.inst.selectedTower.upgradeSlot1 * 250);
                UIMgr.inst.selectedTower.upgradeSlot1++;
            }
        }
    }

    public void upgrade2ButtonPressed()
    {
        if (UIMgr.inst.selectedTower.upgradeSlot2 < 4)
        {
            if (PlayerMgr.inst.playerMoney >= (UIMgr.inst.selectedTower.upgradeSlot2 * 250))
            {
                PlayerMgr.inst.playerMoney -= (UIMgr.inst.selectedTower.upgradeSlot2 * 250);
                UIMgr.inst.selectedTower.upgradeSlot2++;
            }
        }
    }
}
