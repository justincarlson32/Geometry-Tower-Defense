using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{

    //displays an entity’s name, speed, desired speed, heading, and desired heading.
    public Text lives, money, round;

    public RaycastHit hit;

    public bool isPlacing;

    public int selectedType;

    public GreyTower Grey_Tower;

    public RedTower Red_Tower;

    public BlueTower Blue_Tower;

    public GameObject SelectionCircle, SelectionCircleInst;

    public PlaceableTile selectedTile;

    public int lClickRadiusSq = 3;

    public Tower selectedTower;

    public UpgradeMgr upgradeMgr;

    public bool shouldSpawnCircle;

    public GameObject defeatUI;

    public static UIMgr inst;

    private void Awake()
    {
        inst = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        isPlacing = false;
        shouldSpawnCircle = true;
    }

    public void pauseButtonPressed()
    {
        GameStateMgr.inst.isGamePaused = (GameStateMgr.inst.isGamePaused) ? false : true;
    }

    public void startButtonPressed()
    {
        if (!GameStateMgr.inst.isGamePaused && !WaveMgr.inst.roundInProgress)
        {
            WaveMgr.inst.roundInProgress = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        lives.text = PlayerMgr.inst.playerLives + " hp";
        money.text = "$ " + PlayerMgr.inst.playerMoney;
        round.text = "Round " + WaveMgr.inst.round;

        updateUpgradeTable();

        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f)) {
                Debug.DrawLine(Camera.main.transform.position, hit.point, Color.yellow, 20);
                Vector3 pos = hit.point;
                pos.y = 0;
                PlaceableTile ent = hit.transform.GetComponent<PlaceableTile>();

                if (isPlacing)
                    placeTowerOfTypeAtTile(selectedType, ent);
                else
                    selectTowerAtTile(ent);
            } else {
                Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward) * 1000, Color.white, 20);
            }
        }

        if (selectedTower)
        {
            if (shouldSpawnCircle)
            {
                Vector3 spawnPostion = selectedTile.transform.position;
                spawnPostion.x += 2.5f;
                spawnPostion.y += 1.0f;
                spawnPostion.z += 0.0f;
                SelectionCircleInst = Instantiate(SelectionCircle, spawnPostion, selectedTile.transform.localRotation);
                shouldSpawnCircle = false;
            }
            else
            {
                Vector3 spawnPostion = selectedTile.transform.position;
                spawnPostion.x += 2.5f;
                spawnPostion.y += 1.0f;
                spawnPostion.z += 0.0f;

                SelectionCircleInst.transform.position = spawnPostion;
            }
        }

    }

    public void placeTowerOfTypeAtTile(int type, PlaceableTile tile)
    {
        if (tile)
        {
            if (tile.isSpaceAvailable)
            {
                Vector3 spawnPostion = tile.transform.position;
                spawnPostion.x += 1f;
                spawnPostion.y += 1.25f;
                if (type == 0 && PlayerMgr.inst.playerMoney >= 300)
                {
                    tile.placedTower = Instantiate(Grey_Tower, spawnPostion, tile.transform.localRotation);
                    tile.isSpaceAvailable = false;
                    PlayerMgr.inst.playerMoney -= 300;
                }

                if (type == 1 && PlayerMgr.inst.playerMoney >= 400)
                {
                    tile.placedTower = Instantiate(Red_Tower, spawnPostion, tile.transform.localRotation);
                    tile.isSpaceAvailable = false;
                    PlayerMgr.inst.playerMoney -= 400;
                }

                if (type == 2 && PlayerMgr.inst.playerMoney >= 450)
                {
                    tile.placedTower = Instantiate(Blue_Tower, spawnPostion, tile.transform.localRotation);
                    tile.isSpaceAvailable = false;
                    PlayerMgr.inst.playerMoney -= 450;
                }

            }
            isPlacing = false;
        }
    }

    public void greyTowerButtonPressed() {
        selectedType = 0;
        isPlacing = true;
    }

    public void redTowerButtonPressed()
    {
        selectedType = 1;
        isPlacing = true;
    }

    public void blueTowerButtonPressed()
    {
        selectedType = 2;
        isPlacing = true;
    }

    public void selectTowerAtTile(PlaceableTile tile)
    {
        if (tile)
        {
            if (!tile.isSpaceAvailable)
            {
                selectedTower = tile.placedTower;
                selectedTile = tile;
            }
        }
        else
        {

        }
    }


    public void updateUpgradeTable()
    {

        for (int i = 0; i < 4; i++)
        {
            upgradeMgr.Indicators2[i].GetComponent<Image>().color = new Color32(0, 0, 0, 200);
            upgradeMgr.Indicators1[i].GetComponent<Image>().color = new Color32(0, 0, 0, 200);
        }

        if (selectedTower)
        {

            upgradeMgr.self.SetActive(true);

            int upgrades1 = selectedTower.upgradeSlot1, upgrades2 = selectedTower.upgradeSlot2;

            for (int i = 0; i < upgrades1; i++){
                upgradeMgr.Indicators1[i].GetComponent<Image>().color = new Color32(0, 255, 0, 200);
            }

            for (int i = 0; i < upgrades2; i++)
            {
                upgradeMgr.Indicators2[i].GetComponent<Image>().color = new Color32(0, 255, 0, 200);
            }

            upgradeMgr.price1.text = "$" + (250 * upgrades1);
            upgradeMgr.price2.text = "$" + (250 * upgrades2);

        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                upgradeMgr.Indicators2[i].GetComponent<Image>().color = new Color32(0, 0, 0, 200);
                upgradeMgr.Indicators1[i].GetComponent<Image>().color = new Color32(0, 0, 0, 200);
            }
            upgradeMgr.self.SetActive(false);
        }
    }
}
