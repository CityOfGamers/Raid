using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CCGui : MonoBehaviour
{
    CharacterCustomizer cc;
    CharacterCustomizer.EquipLocation currTab;
    public Slot currSlot;

    #region MyRegion

    public ScrollRect bpTab;
    public ScrollRect btTab;
    public ScrollRect byTab;
    public ScrollRect gsTab;
    public ScrollRect htTab;
    public ScrollRect hdTab;
    public ScrollRect mkTab;
    public ScrollRect ptTab;
    public ScrollRect shTab;
    #endregion

    public List<Button> backpacks;
    public List<Button> belts;
    public List<Button> bodies;
    public List<Button> glasses;
    public List<Button> hats;
    public List<Button> heads;
    public List<Button> masks;
    public List<Button> pants;
    public List<Button> shoes;

    public Button tryButton;
    public Button buyButton;
    public Button equipButton;
    public Button deEquipButton;



    private void Awake()
    {
        cc = FindObjectOfType<CharacterCustomizer>();
        backpacks = new List<Button>(bpTab.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>());
        belts = new List<Button>(btTab.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>());
        bodies = new List<Button>(byTab.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>());
        glasses = new List<Button>(gsTab.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>());
        hats = new List<Button>(htTab.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>());
        heads = new List<Button>(hdTab.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>());
        masks = new List<Button>(mkTab.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>());
        pants = new List<Button>(ptTab.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>());
        shoes = new List<Button>(shTab.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>());
        cc.gui = this;
        cc.Setup();
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowTab(int locationIndex)
    {
        currTab = (CharacterCustomizer.EquipLocation)locationIndex;
        switch (currTab)
        {
            case CharacterCustomizer.EquipLocation.Backpack:
                bpTab.gameObject.SetActive(true);
                btTab.gameObject.SetActive(false);
                byTab.gameObject.SetActive(false);
                gsTab.gameObject.SetActive(false);
                htTab.gameObject.SetActive(false);
                hdTab.gameObject.SetActive(false);
                mkTab.gameObject.SetActive(false);
                ptTab.gameObject.SetActive(false);
                shTab.gameObject.SetActive(false);
                break;
            case CharacterCustomizer.EquipLocation.Belt:
                bpTab.gameObject.SetActive(false);
                btTab.gameObject.SetActive(true);
                byTab.gameObject.SetActive(false);
                gsTab.gameObject.SetActive(false);
                htTab.gameObject.SetActive(false);
                hdTab.gameObject.SetActive(false);
                mkTab.gameObject.SetActive(false);
                ptTab.gameObject.SetActive(false);
                shTab.gameObject.SetActive(false);
                break;
            case CharacterCustomizer.EquipLocation.Body:
                bpTab.gameObject.SetActive(false);
                btTab.gameObject.SetActive(false);
                byTab.gameObject.SetActive(true);
                gsTab.gameObject.SetActive(false);
                htTab.gameObject.SetActive(false);
                hdTab.gameObject.SetActive(false);
                mkTab.gameObject.SetActive(false);
                ptTab.gameObject.SetActive(false);
                shTab.gameObject.SetActive(false);
                break;
            case CharacterCustomizer.EquipLocation.Glasses:
                bpTab.gameObject.SetActive(false);
                btTab.gameObject.SetActive(false);
                byTab.gameObject.SetActive(false);
                gsTab.gameObject.SetActive(true);
                htTab.gameObject.SetActive(false);
                hdTab.gameObject.SetActive(false);
                mkTab.gameObject.SetActive(false);
                ptTab.gameObject.SetActive(false);
                shTab.gameObject.SetActive(false);
                break;
            case CharacterCustomizer.EquipLocation.Hat:
                bpTab.gameObject.SetActive(false);
                btTab.gameObject.SetActive(false);
                byTab.gameObject.SetActive(false);
                gsTab.gameObject.SetActive(false);
                htTab.gameObject.SetActive(true);
                hdTab.gameObject.SetActive(false);
                mkTab.gameObject.SetActive(false);
                ptTab.gameObject.SetActive(false);
                shTab.gameObject.SetActive(false);
                break;
            case CharacterCustomizer.EquipLocation.Head:
                bpTab.gameObject.SetActive(false);
                btTab.gameObject.SetActive(false);
                byTab.gameObject.SetActive(false);
                gsTab.gameObject.SetActive(false);
                htTab.gameObject.SetActive(false);
                hdTab.gameObject.SetActive(true);
                mkTab.gameObject.SetActive(false);
                ptTab.gameObject.SetActive(false);
                shTab.gameObject.SetActive(false);
                break;
            case CharacterCustomizer.EquipLocation.Mask:
                bpTab.gameObject.SetActive(false);
                btTab.gameObject.SetActive(false);
                byTab.gameObject.SetActive(false);
                gsTab.gameObject.SetActive(false);
                htTab.gameObject.SetActive(false);
                hdTab.gameObject.SetActive(false);
                mkTab.gameObject.SetActive(true);
                ptTab.gameObject.SetActive(false);
                shTab.gameObject.SetActive(false);
                break;
            case CharacterCustomizer.EquipLocation.Pants:
                bpTab.gameObject.SetActive(false);
                btTab.gameObject.SetActive(false);
                byTab.gameObject.SetActive(false);
                gsTab.gameObject.SetActive(false);
                htTab.gameObject.SetActive(false);
                hdTab.gameObject.SetActive(false);
                mkTab.gameObject.SetActive(false);
                ptTab.gameObject.SetActive(true);
                shTab.gameObject.SetActive(false);
                break;
            case CharacterCustomizer.EquipLocation.Shoes:
                bpTab.gameObject.SetActive(false);
                btTab.gameObject.SetActive(false);
                byTab.gameObject.SetActive(false);
                gsTab.gameObject.SetActive(false);
                htTab.gameObject.SetActive(false);
                hdTab.gameObject.SetActive(false);
                mkTab.gameObject.SetActive(false);
                ptTab.gameObject.SetActive(false);
                shTab.gameObject.SetActive(true);
                break;
            default:
                break;
        }
        cc.CheckEquippedIcons();
    }

    public void ShowTab(CharacterCustomizer.EquipLocation location)
    {
        switch (location)
        {
            case CharacterCustomizer.EquipLocation.Backpack:
                bpTab.gameObject.SetActive(true);
                btTab.gameObject.SetActive(false);
                byTab.gameObject.SetActive(false);
                gsTab.gameObject.SetActive(false);
                htTab.gameObject.SetActive(false);
                hdTab.gameObject.SetActive(false);
                mkTab.gameObject.SetActive(false);
                ptTab.gameObject.SetActive(false);
                shTab.gameObject.SetActive(false);
                break;
            case CharacterCustomizer.EquipLocation.Belt:
                bpTab.gameObject.SetActive(false);
                btTab.gameObject.SetActive(true);
                byTab.gameObject.SetActive(false);
                gsTab.gameObject.SetActive(false);
                htTab.gameObject.SetActive(false);
                hdTab.gameObject.SetActive(false);
                mkTab.gameObject.SetActive(false);
                ptTab.gameObject.SetActive(false);
                shTab.gameObject.SetActive(false);
                break;
            case CharacterCustomizer.EquipLocation.Body:
                bpTab.gameObject.SetActive(false);
                btTab.gameObject.SetActive(false);
                byTab.gameObject.SetActive(true);
                gsTab.gameObject.SetActive(false);
                htTab.gameObject.SetActive(false);
                hdTab.gameObject.SetActive(false);
                mkTab.gameObject.SetActive(false);
                ptTab.gameObject.SetActive(false);
                shTab.gameObject.SetActive(false);
                break;
            case CharacterCustomizer.EquipLocation.Glasses:
                bpTab.gameObject.SetActive(false);
                btTab.gameObject.SetActive(false);
                byTab.gameObject.SetActive(false);
                gsTab.gameObject.SetActive(true);
                htTab.gameObject.SetActive(false);
                hdTab.gameObject.SetActive(false);
                mkTab.gameObject.SetActive(false);
                ptTab.gameObject.SetActive(false);
                shTab.gameObject.SetActive(false);
                break;
            case CharacterCustomizer.EquipLocation.Hat:
                bpTab.gameObject.SetActive(false);
                btTab.gameObject.SetActive(false);
                byTab.gameObject.SetActive(false);
                gsTab.gameObject.SetActive(false);
                htTab.gameObject.SetActive(true);
                hdTab.gameObject.SetActive(false);
                mkTab.gameObject.SetActive(false);
                ptTab.gameObject.SetActive(false);
                shTab.gameObject.SetActive(false);
                break;
            case CharacterCustomizer.EquipLocation.Head:
                bpTab.gameObject.SetActive(false);
                btTab.gameObject.SetActive(false);
                byTab.gameObject.SetActive(false);
                gsTab.gameObject.SetActive(false);
                htTab.gameObject.SetActive(false);
                hdTab.gameObject.SetActive(true);
                mkTab.gameObject.SetActive(false);
                ptTab.gameObject.SetActive(false);
                shTab.gameObject.SetActive(false);
                break;
            case CharacterCustomizer.EquipLocation.Mask:
                bpTab.gameObject.SetActive(false);
                btTab.gameObject.SetActive(false);
                byTab.gameObject.SetActive(false);
                gsTab.gameObject.SetActive(false);
                htTab.gameObject.SetActive(false);
                hdTab.gameObject.SetActive(false);
                mkTab.gameObject.SetActive(true);
                ptTab.gameObject.SetActive(false);
                shTab.gameObject.SetActive(false);
                break;
            case CharacterCustomizer.EquipLocation.Pants:
                bpTab.gameObject.SetActive(false);
                btTab.gameObject.SetActive(false);
                byTab.gameObject.SetActive(false);
                gsTab.gameObject.SetActive(false);
                htTab.gameObject.SetActive(false);
                hdTab.gameObject.SetActive(false);
                mkTab.gameObject.SetActive(false);
                ptTab.gameObject.SetActive(true);
                shTab.gameObject.SetActive(false);
                break;
            case CharacterCustomizer.EquipLocation.Shoes:
                bpTab.gameObject.SetActive(false);
                btTab.gameObject.SetActive(false);
                byTab.gameObject.SetActive(false);
                gsTab.gameObject.SetActive(false);
                htTab.gameObject.SetActive(false);
                hdTab.gameObject.SetActive(false);
                mkTab.gameObject.SetActive(false);
                ptTab.gameObject.SetActive(false);
                shTab.gameObject.SetActive(true);
                break;
            default:
                break;
        }
        cc.ResetGear();
        cc.CheckEquippedIcons();

    }
    public void ResetGui() //Set Menu to Default Tab
    {
        ShowTab((int)CharacterCustomizer.EquipLocation.Body);
    }

    public void SetCCButtons() //Determines which gear buttons to display
    {
        if (currSlot!=null)
        {
            if (currSlot.unlocked)
            {
                switch (currTab)
                {
                    case CharacterCustomizer.EquipLocation.Backpack:
                        if (currSlot == cc.currBack)
                        {
                            tryButton.gameObject.SetActive(false);
                            buyButton.gameObject.SetActive(false);
                            deEquipButton.gameObject.SetActive(true);
                            equipButton.gameObject.SetActive(false);
                        }
                        else
                        {
                            tryButton.gameObject.SetActive(false);
                            buyButton.gameObject.SetActive(false);
                            deEquipButton.gameObject.SetActive(false);
                            equipButton.gameObject.SetActive(true);
                        }
                        break;
                    case CharacterCustomizer.EquipLocation.Belt:
                        if (currSlot == cc.currBelt)
                        {
                            tryButton.gameObject.SetActive(false);
                            buyButton.gameObject.SetActive(false);
                            deEquipButton.gameObject.SetActive(true);
                            equipButton.gameObject.SetActive(false);
                        }
                        else
                        {
                            tryButton.gameObject.SetActive(false);
                            buyButton.gameObject.SetActive(false);
                            deEquipButton.gameObject.SetActive(false);
                            equipButton.gameObject.SetActive(true);
                        }
                        break;
                    case CharacterCustomizer.EquipLocation.Body:
                        if (currSlot == cc.currBody)
                        {
                            tryButton.gameObject.SetActive(false);
                            buyButton.gameObject.SetActive(false);
                            deEquipButton.gameObject.SetActive(true);
                            equipButton.gameObject.SetActive(false);
                        }
                        else
                        {
                            tryButton.gameObject.SetActive(false);
                            buyButton.gameObject.SetActive(false);
                            deEquipButton.gameObject.SetActive(false);
                            equipButton.gameObject.SetActive(true);
                        }
                        break;
                    case CharacterCustomizer.EquipLocation.Glasses:
                        if (currSlot == cc.currGlass)
                        {
                            tryButton.gameObject.SetActive(false);
                            buyButton.gameObject.SetActive(false);
                            deEquipButton.gameObject.SetActive(true);
                            equipButton.gameObject.SetActive(false);
                        }
                        else
                        {
                            tryButton.gameObject.SetActive(false);
                            buyButton.gameObject.SetActive(false);
                            deEquipButton.gameObject.SetActive(false);
                            equipButton.gameObject.SetActive(true);
                        }
                        break;
                    case CharacterCustomizer.EquipLocation.Hat:
                        if (currSlot == cc.currHat)
                        {
                            tryButton.gameObject.SetActive(false);
                            buyButton.gameObject.SetActive(false);
                            deEquipButton.gameObject.SetActive(true);
                            equipButton.gameObject.SetActive(false);
                        }
                        else
                        {
                            tryButton.gameObject.SetActive(false);
                            buyButton.gameObject.SetActive(false);
                            deEquipButton.gameObject.SetActive(false);
                            equipButton.gameObject.SetActive(true);
                        }
                        break;
                    case CharacterCustomizer.EquipLocation.Head:
                        if (currSlot == cc.currHead)
                        {
                            tryButton.gameObject.SetActive(false);
                            buyButton.gameObject.SetActive(false);
                            deEquipButton.gameObject.SetActive(true);
                            equipButton.gameObject.SetActive(false);
                        }
                        else
                        {
                            tryButton.gameObject.SetActive(false);
                            buyButton.gameObject.SetActive(false);
                            deEquipButton.gameObject.SetActive(false);
                            equipButton.gameObject.SetActive(true);
                        }
                        break;
                    case CharacterCustomizer.EquipLocation.Mask:
                        if (currSlot == cc.currMask)
                        {
                            tryButton.gameObject.SetActive(false);
                            buyButton.gameObject.SetActive(false);
                            deEquipButton.gameObject.SetActive(true);
                            equipButton.gameObject.SetActive(false);
                        }
                        else
                        {
                            tryButton.gameObject.SetActive(false);
                            buyButton.gameObject.SetActive(false);
                            deEquipButton.gameObject.SetActive(false);
                            equipButton.gameObject.SetActive(true);
                        }
                        break;
                    case CharacterCustomizer.EquipLocation.Pants:
                        if (currSlot == cc.currPants)
                        {
                            tryButton.gameObject.SetActive(false);
                            buyButton.gameObject.SetActive(false);
                            deEquipButton.gameObject.SetActive(true);
                            equipButton.gameObject.SetActive(false);
                        }
                        else
                        {
                            tryButton.gameObject.SetActive(false);
                            buyButton.gameObject.SetActive(false);
                            deEquipButton.gameObject.SetActive(false);
                            equipButton.gameObject.SetActive(true);
                        }
                        break;
                    case CharacterCustomizer.EquipLocation.Shoes:
                        if (currSlot == cc.currShoe)
                        {
                            tryButton.gameObject.SetActive(false);
                            buyButton.gameObject.SetActive(false);
                            deEquipButton.gameObject.SetActive(true);
                            equipButton.gameObject.SetActive(false);
                        }
                        else
                        {
                            tryButton.gameObject.SetActive(false);
                            buyButton.gameObject.SetActive(false);
                            deEquipButton.gameObject.SetActive(false);
                            equipButton.gameObject.SetActive(true);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                tryButton.gameObject.SetActive(true);
                buyButton.gameObject.SetActive(true);
                deEquipButton.gameObject.SetActive(false);
                equipButton.gameObject.SetActive(false);
            }
        }
        else
        {
            tryButton.gameObject.SetActive(false);
            buyButton.gameObject.SetActive(false);
            deEquipButton.gameObject.SetActive(true);
            equipButton.gameObject.SetActive(false);
        }

    }

    public void Try()
    {
        if (currSlot!=null)
        {
            switch (currSlot.slotLocation)
        {
            case CharacterCustomizer.EquipLocation.Backpack:
                cc.ShowBack(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Belt:
                cc.ShowBelt(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Body:
                cc.ShowBody(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Glasses:
                cc.ShowGlasses(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Hat:
                cc.ShowHat(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Head:
                cc.ShowHead(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Mask:
                cc.ShowMask(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Pants:
                cc.ShowPants(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Shoes:
                cc.ShowShoes(currSlot.index);
                break;
            default:
                break;
        }
        }
        else
        {
            switch (currTab)
            {
                case CharacterCustomizer.EquipLocation.Backpack:
                    cc.ShowBack(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Belt:
                    cc.ShowBelt(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Body:
                    cc.ShowBody(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Glasses:
                    cc.ShowGlasses(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Hat:
                    cc.ShowHat(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Head:
                    cc.ShowHead(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Mask:
                    cc.ShowMask(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Pants:
                    cc.ShowPants(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Shoes:
                    cc.ShowShoes(-1);
                    break;
                default:
                    break;
            }
        }
        
    }
    public void Equip()
    {
        switch (currSlot.slotLocation)
        {
            case CharacterCustomizer.EquipLocation.Backpack:
                cc.SetBackpack(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Belt:
                cc.SetBelt(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Body:
                cc.SetBody(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Glasses:
                cc.SetGlasses(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Hat:
                cc.SetHat(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Head:
                cc.SetHead(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Mask:
                cc.SetMask(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Pants:
                cc.SetPants(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Shoes:
                cc.SetShoes(currSlot.index);
                break;
            default:
                break;
        }
        SetCCButtons();
        cc.CheckEquippedIcons();
    }

    public void DequipButtons()
    {
        tryButton.gameObject.SetActive(false);
        buyButton.gameObject.SetActive(false);
        deEquipButton.gameObject.SetActive(true);
        equipButton.gameObject.SetActive(false);
    }
    public void DeEquip()
    {
            switch (currTab)
            {
                case CharacterCustomizer.EquipLocation.Backpack:
                    cc.SetBackpack(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Belt:
                    cc.SetBelt(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Body:
                    cc.SetBody(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Glasses:
                    cc.SetGlasses(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Hat:
                    cc.SetHat(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Head:
                    cc.SetHead(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Mask:
                    cc.SetMask(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Pants:
                    cc.SetPants(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Shoes:
                    cc.SetShoes(-1);
                    break;
                default:
                    break;
            }
        SetCCButtons();
        cc.CheckEquippedIcons();
    }
    public void Buy()
    {
        //TODO: take money
        currSlot.unlocked = true;
        SetCCButtons();
        cc.ResetGear();
    }

    void Deselect()
    {
        currSlot = null;

    }
    public void HideButtons()
    {
        tryButton.gameObject.SetActive(false);
        buyButton.gameObject.SetActive(false);
        deEquipButton.gameObject.SetActive(false);
        equipButton.gameObject.SetActive(false);

    }

    public void SetGearSlot(int index)
    {
        cc.ResetGear();
        if (index >= 0)
        {
            switch (currTab)
            {
                case CharacterCustomizer.EquipLocation.Backpack:
                    currSlot = cc.backpacks[index];
                    break;
                case CharacterCustomizer.EquipLocation.Belt:
                    currSlot = cc.belts[index];
                    break;
                case CharacterCustomizer.EquipLocation.Body:
                    currSlot = cc.bodies[index];
                    break;
                case CharacterCustomizer.EquipLocation.Glasses:
                    currSlot = cc.glasses[index];
                    break;
                case CharacterCustomizer.EquipLocation.Hat:
                    currSlot = cc.hats[index];
                    break;
                case CharacterCustomizer.EquipLocation.Head:
                    currSlot = cc.heads[index];
                    break;
                case CharacterCustomizer.EquipLocation.Mask:
                    currSlot = cc.masks[index];
                    break;
                case CharacterCustomizer.EquipLocation.Pants:
                    currSlot = cc.pants[index];
                    break;
                case CharacterCustomizer.EquipLocation.Shoes:
                    currSlot = cc.shoes[index];
                    break;
                default:
                    break;
            }
        }
        else if (index==-1)
        {
            currSlot = null;
        }
        SetCCButtons();
    }

    public static void ToggleSVG(Button gearButton, bool enabled)
    {
        gearButton.GetComponentInChildren<SVGImage>().enabled = enabled;
    }
}
