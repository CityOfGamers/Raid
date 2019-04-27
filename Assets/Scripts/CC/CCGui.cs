using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CCGui : MonoBehaviour
{

    CharacterCustomizer.EquipLocation currTab;
    public Slot currSlot;

    public static CCGui instance;
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

    CanvasGroup m_CanvasGroup;
    public bool faded;

    public GameObject raiderObj;
    private void Awake()
    {
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance.
            Destroy(gameObject);

        m_CanvasGroup = GetComponent<CanvasGroup>();
        backpacks = new List<Button>(bpTab.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>());
        belts = new List<Button>(btTab.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>());
        bodies = new List<Button>(byTab.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>());
        glasses = new List<Button>(gsTab.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>());
        hats = new List<Button>(htTab.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>());
        heads = new List<Button>(hdTab.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>());
        masks = new List<Button>(mkTab.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>());
        pants = new List<Button>(ptTab.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>());
        shoes = new List<Button>(shTab.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>());
        CharacterCustomizer.instance.Setup();
        TurnOffGUI();
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
        CharacterCustomizer.instance.CheckEquippedIcons();
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
        CharacterCustomizer.instance.ResetGear();
        CharacterCustomizer.instance.CheckEquippedIcons();

    }
    public void ResetGui() //Set Menu to Default Tab
    {
        SetCCButtons();
        ShowTab((int)CharacterCustomizer.EquipLocation.Body);
    }

    public void SetCCButtons() //Determines which gear buttons to display
    {
        if (currSlot != null)
        {
            if (currSlot.unlocked)
            {
                switch (currTab)
                {
                    case CharacterCustomizer.EquipLocation.Backpack:
                        if (currSlot == CharacterCustomizer.instance.currBack)
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
                        if (currSlot == CharacterCustomizer.instance.currBelt)
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
                        if (currSlot == CharacterCustomizer.instance.currBody)
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
                        if (currSlot == CharacterCustomizer.instance.currGlass)
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
                        if (currSlot == CharacterCustomizer.instance.currHat)
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
                        if (currSlot == CharacterCustomizer.instance.currHead)
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
                        if (currSlot == CharacterCustomizer.instance.currMask)
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
                        if (currSlot == CharacterCustomizer.instance.currPants)
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
                        if (currSlot == CharacterCustomizer.instance.currShoe)
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
        if (currSlot != null)
        {
            switch (currSlot.slotLocation)
            {
                case CharacterCustomizer.EquipLocation.Backpack:
                    CharacterCustomizer.instance.ShowBack(currSlot.index);
                    break;
                case CharacterCustomizer.EquipLocation.Belt:
                    CharacterCustomizer.instance.ShowBelt(currSlot.index);
                    break;
                case CharacterCustomizer.EquipLocation.Body:
                    CharacterCustomizer.instance.ShowBody(currSlot.index);
                    break;
                case CharacterCustomizer.EquipLocation.Glasses:
                    CharacterCustomizer.instance.ShowGlasses(currSlot.index);
                    break;
                case CharacterCustomizer.EquipLocation.Hat:
                    CharacterCustomizer.instance.ShowHat(currSlot.index);
                    break;
                case CharacterCustomizer.EquipLocation.Head:
                    CharacterCustomizer.instance.ShowHead(currSlot.index);
                    break;
                case CharacterCustomizer.EquipLocation.Mask:
                    CharacterCustomizer.instance.ShowMask(currSlot.index);
                    break;
                case CharacterCustomizer.EquipLocation.Pants:
                    CharacterCustomizer.instance.ShowPants(currSlot.index);
                    break;
                case CharacterCustomizer.EquipLocation.Shoes:
                    CharacterCustomizer.instance.ShowShoes(currSlot.index);
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
                    CharacterCustomizer.instance.ShowBack(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Belt:
                    CharacterCustomizer.instance.ShowBelt(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Body:
                    CharacterCustomizer.instance.ShowBody(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Glasses:
                    CharacterCustomizer.instance.ShowGlasses(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Hat:
                    CharacterCustomizer.instance.ShowHat(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Head:
                    CharacterCustomizer.instance.ShowHead(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Mask:
                    CharacterCustomizer.instance.ShowMask(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Pants:
                    CharacterCustomizer.instance.ShowPants(-1);
                    break;
                case CharacterCustomizer.EquipLocation.Shoes:
                    CharacterCustomizer.instance.ShowShoes(-1);
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
                CharacterCustomizer.instance.SetBackpack(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Belt:
                CharacterCustomizer.instance.SetBelt(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Body:
                CharacterCustomizer.instance.SetBody(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Glasses:
                CharacterCustomizer.instance.SetGlasses(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Hat:
                CharacterCustomizer.instance.SetHat(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Head:
                CharacterCustomizer.instance.SetHead(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Mask:
                CharacterCustomizer.instance.SetMask(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Pants:
                CharacterCustomizer.instance.SetPants(currSlot.index);
                break;
            case CharacterCustomizer.EquipLocation.Shoes:
                CharacterCustomizer.instance.SetShoes(currSlot.index);
                break;
            default:
                break;
        }
        SetCCButtons();
        CharacterCustomizer.instance.CheckEquippedIcons();
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
                CharacterCustomizer.instance.SetBackpack(-1);
                break;
            case CharacterCustomizer.EquipLocation.Belt:
                CharacterCustomizer.instance.SetBelt(-1);
                break;
            case CharacterCustomizer.EquipLocation.Body:
                CharacterCustomizer.instance.SetBody(-1);
                break;
            case CharacterCustomizer.EquipLocation.Glasses:
                CharacterCustomizer.instance.SetGlasses(-1);
                break;
            case CharacterCustomizer.EquipLocation.Hat:
                CharacterCustomizer.instance.SetHat(-1);
                break;
            case CharacterCustomizer.EquipLocation.Head:
                CharacterCustomizer.instance.SetHead(-1);
                break;
            case CharacterCustomizer.EquipLocation.Mask:
                CharacterCustomizer.instance.SetMask(-1);
                break;
            case CharacterCustomizer.EquipLocation.Pants:
                CharacterCustomizer.instance.SetPants(-1);
                break;
            case CharacterCustomizer.EquipLocation.Shoes:
                CharacterCustomizer.instance.SetShoes(-1);
                break;
            default:
                break;
        }
        SetCCButtons();
        CharacterCustomizer.instance.CheckEquippedIcons();
    }
    public void Buy()
    {
        //TODO: take money
        currSlot.unlocked = true;
        SetCCButtons();
        CharacterCustomizer.instance.ResetGear();
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
        CharacterCustomizer.instance.ResetGear();
        if (index >= 0)
        {
            switch (currTab)
            {
                case CharacterCustomizer.EquipLocation.Backpack:
                    currSlot = CharacterCustomizer.instance.backpacks[index];
                    break;
                case CharacterCustomizer.EquipLocation.Belt:
                    currSlot = CharacterCustomizer.instance.belts[index];
                    break;
                case CharacterCustomizer.EquipLocation.Body:
                    currSlot = CharacterCustomizer.instance.bodies[index];
                    break;
                case CharacterCustomizer.EquipLocation.Glasses:
                    currSlot = CharacterCustomizer.instance.glasses[index];
                    break;
                case CharacterCustomizer.EquipLocation.Hat:
                    currSlot = CharacterCustomizer.instance.hats[index];
                    break;
                case CharacterCustomizer.EquipLocation.Head:
                    currSlot = CharacterCustomizer.instance.heads[index];
                    break;
                case CharacterCustomizer.EquipLocation.Mask:
                    currSlot = CharacterCustomizer.instance.masks[index];
                    break;
                case CharacterCustomizer.EquipLocation.Pants:
                    currSlot = CharacterCustomizer.instance.pants[index];
                    break;
                case CharacterCustomizer.EquipLocation.Shoes:
                    currSlot = CharacterCustomizer.instance.shoes[index];
                    break;
                default:
                    break;
            }
        }
        else if (index == -1)
        {
            currSlot = null;
        }
        SetCCButtons();
    }

    public static void ToggleSVG(Button gearButton, bool enabled)
    {
        gearButton.GetComponentInChildren<SVGImage>().enabled = enabled;
    }

    public void TurnOffGUI()
    {
        m_CanvasGroup.alpha = 0;
        m_CanvasGroup.interactable = false;
    }


    public void FadeGUI(bool fade)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        if (fade && !faded)
        {
            m_CanvasGroup.DOFade(0, 1f);
            m_CanvasGroup.interactable = false;

        }
        else
        {
            m_CanvasGroup.DOFade(1, 1f);
            m_CanvasGroup.interactable = true;
        }
        faded = !faded;
    }

    public static void FadeCCGUI(bool fade)
    {
        instance.FadeGUI(fade);
    }

    private void OnDisable()
    {
        TurnOffGUI();
    }

    public void BackButton()
    {
        ClientFrontend.OnSelectStatic();
        ClientFrontend.instance.ShowMenu(ClientFrontend.MenuShowing.Main);

    }

    public void OnHighlight() { ClientFrontend.OnHightlightStatic(); }
}
