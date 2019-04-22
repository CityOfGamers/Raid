using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomizer : MonoBehaviour
{
    [System.Serializable]
    public enum EquipLocation { Backpack, Belt, Body, Glasses, Hat, Head, Mask, Pants, Shoes };
    public static CharacterCustomizer instance;
    #region Lists
    public List<Slot> backpacks = new List<Slot>();
    public List<Slot> belts = new List<Slot>();
    public List<Slot> bodies = new List<Slot>();
    public List<Slot> glasses = new List<Slot>();
    public List<Slot> hats = new List<Slot>();
    public List<Slot> heads = new List<Slot>();
    public List<Slot> masks = new List<Slot>();
    public List<Slot> pants = new List<Slot>();
    public List<Slot> shoes = new List<Slot>();

    #endregion
    #region currentGear
    public Slot currBack;
    public Slot currBelt;
    public Slot currBody;
    public Slot currGlass;
    public Slot currHat;
    public Slot currHead;
    public Slot currMask;
    public Slot currPants;
    public Slot currShoe;
    #endregion
    #region shownGear
    public Slot shownBack;
    public Slot shownBelt;
    public Slot shownBody;
    public Slot shownGlass;
    public Slot shownHat;
    public Slot shownHead;
    public Slot shownMask;
    public Slot shownPants;
    public Slot shownShoe;
    #endregion

   public CCGui gui;
    bool MustHaveSlotEquipped(EquipLocation location)
    {
        switch (location)
        {
            case EquipLocation.Backpack:
                return false;
            case EquipLocation.Belt:
                return false;
            case EquipLocation.Body:
                return true;
            case EquipLocation.Glasses:
                return false;
            case EquipLocation.Hat:
                return false;
            case EquipLocation.Head:
                return true;
            case EquipLocation.Mask:
                return false;
            case EquipLocation.Pants:
                return true;
            case EquipLocation.Shoes:
                return true;
            default:
                break;
        }

        return false;
    }


    private void OnApplicationQuit()
    {
        //  SaveGear();
    }
    private void OnDisable()
    {
        // SaveGear();
    }

    private void Awake()
    {
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {        
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setup()
    {
        SortGear();
        DefaultGear();
        LoadGear();
        gui.ResetGui();
    }

    void SortGear()
    {
        List<Slot> allGear = new List<Slot>(GetComponentsInChildren<Slot>());
        foreach (var item in allGear)
        {
            switch (item.slotLocation)
            {
                case EquipLocation.Backpack:
                    backpacks.Add(item);
                    item.index = backpacks.IndexOf(item);
                    foreach (var button in gui.backpacks)
                    {
                        if (button.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite == item.gearImage)
                        {
                            item.myButton = button;
                        }
                    }
                    break;
                case EquipLocation.Belt:
                    belts.Add(item);
                    item.index = belts.IndexOf(item);
                    foreach (var button in gui.belts)
                    {
                        if (button.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite == item.gearImage)
                        {
                            item.myButton = button;
                        }
                    }
                    break;
                case EquipLocation.Body:
                    bodies.Add(item);
                    item.index = bodies.IndexOf(item);
                    foreach (var button in gui.bodies)
                    {
                        if (button.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite == item.gearImage)
                        {
                            item.myButton = button;
                        }
                    }
                    break;
                case EquipLocation.Glasses:
                    glasses.Add(item);
                    item.index = glasses.IndexOf(item);
                    foreach (var button in gui.glasses)
                    {
                        if (button.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite == item.gearImage)
                        {
                            item.myButton = button;
                        }
                    }
                    break;
                case EquipLocation.Hat:
                    hats.Add(item);
                    item.index = hats.IndexOf(item);
                    foreach (var button in gui.hats)
                    {
                        if (button.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite == item.gearImage)
                        {
                            item.myButton = button;
                        }
                    }
                    break;
                case EquipLocation.Head:
                    heads.Add(item);
                    item.index = heads.IndexOf(item);
                    foreach (var button in gui.heads)
                    {
                        if (button.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite == item.gearImage)
                        {
                            item.myButton = button;
                        }
                    }
                    break;
                case EquipLocation.Mask:
                    masks.Add(item);
                    item.index = masks.IndexOf(item);
                    foreach (var button in gui.masks)
                    {
                        if (button.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite == item.gearImage)
                        {
                            item.myButton = button;
                        }
                    }
                    break;
                case EquipLocation.Pants:
                    pants.Add(item);
                    item.index = pants.IndexOf(item);
                    foreach (var button in gui.pants)
                    {
                        if (button.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite == item.gearImage)
                        {
                            item.myButton = button;
                        }
                    }
                    break;
                case EquipLocation.Shoes:
                    shoes.Add(item);
                    item.index = shoes.IndexOf(item);
                    foreach (var button in gui.shoes)
                    {
                        if (button.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite == item.gearImage)
                        {
                            item.myButton = button;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
    void DefaultGear()
    {
        foreach (var item in backpacks)
        {
            item.DeEquip();
        }
        foreach (var item in belts)
        {
            item.DeEquip();
        }
        foreach (var item in bodies)
        {
            item.DeEquip();
        }
        foreach (var item in glasses)
        {
            item.DeEquip();
        }
        foreach (var item in hats)
        {
            item.DeEquip();
        }
        foreach (var item in masks)
        {
            item.DeEquip();
        }
        foreach (var item in pants)
        {
            item.DeEquip();
        }
        foreach (var item in shoes)
        {
            item.DeEquip();
        }
        foreach (var item in heads)
        {
            item.DeEquip();
        }
        SetBody(0);
        SetHead(0);
        SetPants(0);
        SetShoes(0);
    }
    void SetUnlockables(string datastring)
    {
        List<string> allUnlocks = new List<string>(datastring.Split('|')); //all the unlocked items in a list
        List<string> bp = new List<string>(allUnlocks[0].Split(','));   //the unlocked backpacks
        List<string> bt = new List<string>(allUnlocks[1].Split(','));   //the unlocked belts
        List<string> by = new List<string>(allUnlocks[2].Split(','));   //the unlocked bodies
        List<string> gs = new List<string>(allUnlocks[3].Split(','));   //the unlocked glasses
        List<string> ht = new List<string>(allUnlocks[4].Split(','));   //the unlocked hats
        List<string> hd = new List<string>(allUnlocks[5].Split(','));   //the unlocked heads
        List<string> mk = new List<string>(allUnlocks[6].Split(','));   //the unlocked masks
        List<string> pt = new List<string>(allUnlocks[7].Split(','));   //the unlocked pants
        List<string> sh = new List<string>(allUnlocks[8].Split(','));   //the unlocked shoes

        foreach (var item in bp)
        {
            int index;
            if (int.TryParse(item, out index))
            {
                backpacks[index].unlocked = true;
            }
        }
        foreach (var item in bt)
        {
            int index;
            if (int.TryParse(item, out index))
            {
                belts[index].unlocked = true;
            }
        }
        foreach (var item in by)
        {
            int index;
            if (int.TryParse(item, out index))
            {
                bodies[index].unlocked = true;
            }
        }
        foreach (var item in gs)
        {
            int index;
            if (int.TryParse(item, out index))
            {
                glasses[index].unlocked = true;
            }
        }
        foreach (var item in ht)
        {
            int index;
            if (int.TryParse(item, out index))
            {
                hats[index].unlocked = true;
            }
        }
        foreach (var item in hd)
        {
            int index;
            if (int.TryParse(item, out index))
            {
                heads[index].unlocked = true;
            }
        }
        foreach (var item in mk)
        {
            int index;
            if (int.TryParse(item, out index))
            {
                masks[index].unlocked = true;
            }
        }
        foreach (var item in pt)
        {
            int index;
            if (int.TryParse(item, out index))
            {
                pants[index].unlocked = true;
            }
        }
        foreach (var item in sh)
        {
            int index;
            if (int.TryParse(item, out index))
            {
                shoes[index].unlocked = true;
            }
        }

    }
    string UnlockableDataString()
    {
        string data = "";
        foreach (var item in backpacks)
        {
            if (item.unlocked)
            {
                data += item.index.ToString() + ',';
            }
        }
        data += '|';
        foreach (var item in belts)
        {
            if (item.unlocked)
            {
                data += item.index.ToString() + ',';
            }
        }
        data += '|';
        foreach (var item in bodies)
        {
            if (item.unlocked)
            {
                data += item.index.ToString() + ',';
            }
        }
        data += '|';
        foreach (var item in glasses)
        {
            if (item.unlocked)
            {
                data += item.index.ToString() + ',';
            }
        }
        data += '|';
        foreach (var item in hats)
        {
            if (item.unlocked)
            {
                data += item.index.ToString() + ',';
            }
        }
        data += '|';
        foreach (var item in heads)
        {
            if (item.unlocked)
            {
                data += item.index.ToString() + ',';
            }
        }
        data += '|';
        foreach (var item in masks)
        {
            if (item.unlocked)
            {
                data += item.index.ToString() + ',';
            }
        }
        data += '|';
        foreach (var item in pants)
        {
            if (item.unlocked)
            {
                data += item.index.ToString() + ',';
            }
        }
        data += '|';
        foreach (var item in shoes)
        {
            if (item.unlocked)
            {
                data += item.index.ToString() + ',';
            }
        }
        return data;
    }

    #region SetClothing
    public void SetBackpack(int index)
    {
        if (index >= 0)
        {
            foreach (var item in backpacks)
            {
                if (item.index == index)
                {
                    if (item.unlocked)
                    {
                        if (shownBack != null)
                            shownBack.DeEquip();
                        currBack = item;
                        shownBack = currBack;
                        shownBack.Equip();
                    }

                }
            }
        }
        else
        {
            if (shownBack != null)
                shownBack.DeEquip();
            currBack = null;
            shownBack = null;
        }

    }
    public void SetBelt(int index)
    {
        if (index >= 0)
        {
            foreach (var item in belts)
            {
                if (item.index == index)
                {
                    if (item.unlocked)
                    {
                        if (shownBelt != null)
                            shownBelt.DeEquip();
                        currBelt = item;
                        shownBelt = currBelt;
                        shownBelt.Equip();
                    }

                }
            }
        }
        else
        {
            if (shownBelt != null)
                shownBelt.DeEquip();
            currBelt = null;
            shownBelt = null;
        }
    }
    public void SetBody(int index)
    {
        if (index >= 0)
        {
            foreach (var item in bodies)
            {
                if (item.index == index)
                {
                    if (item.unlocked)
                    {
                        if (shownBody != null)
                            shownBody.DeEquip();
                        currBody = item;
                        shownBody = currBody;
                        shownBody.Equip();
                    }

                }
            }
        }
        else
        {
            if (shownBody != null)
                shownBody.DeEquip();
            currBody = bodies[0];
            shownBody = currBody;
            shownBody.Equip();
        }
    }
    public void SetGlasses(int index)
    {
        if (index >= 0)
        {
            foreach (var item in glasses)
            {
                if (item.index == index)
                {
                    if (item.unlocked)
                    {
                        if (shownGlass != null)
                            shownGlass.DeEquip();
                        currGlass = item;
                        shownGlass = currGlass;
                        shownGlass.Equip();
                    }

                }
            }
        }
        else
        {
            if (shownGlass != null)
                shownGlass.DeEquip();
            currGlass = null;
            shownGlass = null;
        }
    }
    public void SetHat(int index)
    {
        if (index >= 0)
        {
            foreach (var item in hats)
            {
                if (item.index == index)
                {
                    if (item.unlocked)
                    {
                        if (shownHat != null)
                            shownHat.DeEquip();
                        currHat = item;
                        shownHat = currHat;
                        shownHat.Equip();
                    }

                }
            }
        }
        else
        {
            if (shownHat != null)
                shownHat.DeEquip();
            currHat = null;
            shownHat = null;
        }
    }
    public void SetHead(int index)
    {
        if (index >= 0)
        {
            foreach (var item in heads)
            {
                if (item.index == index)
                {
                    if (item.unlocked)
                    {
                        if (shownHead != null)
                            shownHead.DeEquip();
                        currHead = item;
                        shownHead = currHead;
                        shownHead.Equip();
                    }

                }
            }
        }
        else
        {
            if (shownHead != null)
                shownHead.DeEquip();
            currHead = heads[0];
            shownHead = currHead;
            shownHead.Equip();
        }
    }
    public void SetMask(int index)
    {
        if (index >= 0)
        {
            foreach (var item in masks)
            {
                if (item.index == index)
                {
                    if (item.unlocked)
                    {
                        if (shownMask!=null)
                        shownMask.DeEquip();
                        currMask = item;
                        shownMask = currMask;
                        shownMask.Equip();
                    }

                }
            }
        }
        else
        {
            shownMask.DeEquip();
            currMask = null;
            shownMask = null;
        }
    }
    public void SetPants(int index)
    {
        if (index >= 0)
        {
            foreach (var item in pants)
            {
                if (item.index == index)
                {
                    if (item.unlocked)
                    {
                        if (shownPants != null)
                            shownPants.DeEquip();
                        currPants = item;
                        shownPants = currPants;
                        shownPants.Equip();
                    }

                }
            }
        }
        else
        {
            if (shownPants != null)
                shownPants.DeEquip();
            currPants = pants[0];
            shownPants = currPants;
            shownPants.Equip();
        }
    }
    public void SetShoes(int index)
    {
        if (index >= 0)
        {
            foreach (var item in shoes)
            {
                if (item.index == index)
                {
                    if (item.unlocked)
                    {
                        if (shownShoe != null)
                            shownShoe.DeEquip();
                        currShoe = item;
                        shownShoe = currShoe;
                        shownShoe.Equip();
                    }

                }
            }
        }
        else
        {
            if (shownShoe != null)
                shownShoe.DeEquip();
            currShoe = shoes[0];
            shownShoe = currShoe;
            shownShoe.Equip();
        }
    }
    #endregion

    #region ShowClothing
    public void ShowBelt(int index)
    {
        if (shownBelt!=null)
            shownBelt.DeEquip();
        if (index >= 0)
        {
            shownBelt = belts[index];
        }
        else if (index ==-1)
        {
            shownBelt = null;
        }
        else
        {
            shownBelt = currBelt;
        }
        if (shownBelt!=null)
            shownBelt.Equip();
    }
    public void ShowBack(int index)
    {
        if (shownBack!=null)
        shownBack.DeEquip();
        if (index >= 0)
        {
            shownBack = backpacks[index];
        }
        else if (index==-1)
        {
            shownBack = null;
        }
        else
        {
            shownBack = currBack;
        }
        if (shownBack!=null)
            shownBack.Equip();
    }
    public void ShowBody(int index)
    {
        if (shownBody!=null)
            shownBody.DeEquip();
        if (index >= 0)
        {
            shownBody = bodies[index];
        }
        else if (index ==-1)
        {
            shownBody = bodies[0];
        }
        else
        {
            shownBody = currBody;
        }
        if (shownBody!=null)
            shownBody.Equip();
    }
    public void ShowGlasses(int index)
    {
        if (shownGlass!=null)
            shownGlass.DeEquip();
        if (index >= 0)
        {
            shownGlass = glasses[index];
        }
        else if (index == -1)
        {
            shownGlass = null;
        }
        else
        {
            shownGlass = currGlass;
        }
        if (shownGlass!=null)
            shownGlass.Equip();
    }
    public void ShowHat(int index)
    {
        if (shownHat!=null)
            shownHat.DeEquip();
        if (index >= 0)
        {
            shownHat = hats[index];
        }
        else if (index ==-1)
        {
            shownHat = null;
        }
        else
        {
            shownHat = currHat;
        }
        if (shownHat!=null)
            shownHat.Equip();
    }
    public void ShowHead(int index)
    {
        if (shownHead!=null)
            shownHead.DeEquip();
        if (index >= 0)
        {
            shownHead = heads[index];
        }
        else if(index ==-1)
        {
            shownHead = heads[0];
        }
        else
        {
            shownHead = currHead;
        }
        if (shownHead!=null)
            shownHead.Equip();
    }
    public void ShowMask(int index)
    {
        if (shownMask!=null)
            shownMask.DeEquip();
        if (index >= 0)
        {
            shownMask = masks[index];
        }
        else if (index ==-1)
        {
            shownMask = null;
        }
        else
        {
            shownMask = currMask;
        }
        if (shownMask!=null)
            shownMask.Equip();
    }
    public void ShowPants(int index)
    {
        if (shownPants!=null)
            shownPants.DeEquip();
        if (index >= 0)
        {
            shownPants = pants[index];
        }
        else if (index == -1)
        {
            shownPants = pants[0];
        }
        else
        {
            shownPants = currPants;
        }
        if (shownPants!=null)
            shownPants.Equip();
    }
    public void ShowShoes(int index)
    {
        if (shownShoe!=null)
            shownShoe.DeEquip();
        if (index >= 0)
        {
            shownShoe = shoes[index];
        }
        else if (index == -1)
        {
            shownShoe = shoes[0];
        }
        else
        {
            shownShoe = currShoe;
        }
        if (shownShoe!=null)
            shownShoe.Equip();
    }
    #endregion

    public void ResetGear()
    {
        if (shownBack != currBack)
        {
            if (shownBack != null)
                shownBack.DeEquip();
            shownBack = currBack;
            if (shownBack != null)
                shownBack.Equip();
        }
        if (shownBelt != currBelt)
        {
            if (shownBelt != null)
                shownBelt.DeEquip();
            shownBelt = currBelt;
            if (shownBelt != null)
                shownBelt.Equip();
        }
        if (shownBody != currBody)
        {
            if (shownBody != null)
                shownBody.DeEquip();
            shownBody = currBody;
            if (shownBody != null)
                shownBody.Equip();
        }
        if (shownGlass != currGlass)
        {
            if (shownBelt != null)
                shownGlass.DeEquip();
            shownGlass = currGlass;
            if (shownBelt != null)
                shownGlass.Equip();
        }
        if (shownHat != currHat)
        {
            if (shownHat != null)
                shownHat.DeEquip();
            shownHat = currHat;
            if (shownHat != null)
                shownHat.Equip();
        }
        if (shownHead != currHead)
        {
            if (shownHead != null)
                shownHead.DeEquip();
            shownHead = currHead;
            if (shownHead != null)
                shownHead.Equip();

        }
        if (shownMask != currMask)
        {
            if (shownMask != null)
                shownMask.DeEquip();
            shownMask = currMask;
            if (shownMask != null)
                shownMask.Equip();

        }
        if (shownPants != currPants)
        {
            if (shownPants != null)
                shownPants.DeEquip();
            shownPants = currPants;
            if (shownPants != null)
                currPants.Equip();

        }
        if (shownShoe != currShoe)
        {
            if (shownShoe != null)
                shownShoe.DeEquip();
            shownShoe = currShoe;
            if (shownShoe != null)
                currShoe.Equip();
        }

        CheckEquippedIcons();
    }

    public void CheckEquippedIcons() //Sets the checked icon in the menu on equipment
    {
        foreach (var item in bodies)
        {
            if (currBody == item)
            {
                CCGui.ToggleSVG(item.myButton, true);
            }
            else
            {
                CCGui.ToggleSVG(item.myButton, false);
            }
        }
        foreach (var item in pants)
        {
            if (currPants == item)
            {
                CCGui.ToggleSVG(item.myButton, true);
            }
            else
            {
                CCGui.ToggleSVG(item.myButton, false);
            }

        }
        foreach (var item in heads)
        {
            if (currHead == item)
            {
                CCGui.ToggleSVG(item.myButton, true);
            }
            else
            {
                CCGui.ToggleSVG(item.myButton, false);
            }

        }
        foreach (var item in shoes)
        {

            if (currShoe == item)
            {
                CCGui.ToggleSVG(item.myButton, true);
            }
            else
            {
                CCGui.ToggleSVG(item.myButton, false);
            }
        }

        if (currBelt == null)
        {
            CCGui.ToggleSVG(gui.belts[0], true);
            foreach (var item in belts)
            {
                    CCGui.ToggleSVG(item.myButton, false);
            }
        }
        else
        {
            foreach (var item in belts)
            {
                if (currBelt == item)
                {
                    CCGui.ToggleSVG(gui.belts[0], false);
                    CCGui.ToggleSVG(item.myButton, true);
                }
                else
                {
                    CCGui.ToggleSVG(item.myButton, false);
                }

            }
        }
        if (currBack == null)
        {
            CCGui.ToggleSVG(gui.backpacks[0], true);
            foreach (var item in backpacks)
            {
                CCGui.ToggleSVG(item.myButton, false);
            }
        }
        else
        {
            foreach (var item in backpacks)
            {
                if (currBack == item)
                {
                    CCGui.ToggleSVG(gui.backpacks[0], false);
                    CCGui.ToggleSVG(item.myButton, true);
                }
                else
                {
                    CCGui.ToggleSVG(item.myButton, false);
                }

            }
        }
        if (currGlass == null)
        {
            foreach (var item in glasses)
            {
                CCGui.ToggleSVG(gui.glasses[0], true);
                CCGui.ToggleSVG(item.myButton, false);
            }
        }
        else
        {
            foreach (var item in glasses)
            {

                if (currGlass == item)
                {
                    CCGui.ToggleSVG(gui.glasses[0], false);
                    CCGui.ToggleSVG(item.myButton, true);
                }
                else
                {
                    CCGui.ToggleSVG(item.myButton, false);
                }

            }
        }
        if (currHat == null)
        {
            CCGui.ToggleSVG(gui.hats[0], true);
            foreach (var item in hats)
            {
                CCGui.ToggleSVG(item.myButton, false);
            }
        }
        else
        {
            foreach (var item in hats)
            {

                if (currHat == item)
                {
                    CCGui.ToggleSVG(gui.hats[0], false);
                    CCGui.ToggleSVG(item.myButton, true);
                }
                else
                {
                    CCGui.ToggleSVG(item.myButton, false);
                }

            }
        }
        if (currMask == null)
        {
            CCGui.ToggleSVG(gui.masks[0], true);
            foreach (var item in masks)
            {
                CCGui.ToggleSVG(item.myButton, false);
            }
        }
        else
        {
            foreach (var item in masks)
            {

                if (currMask == item)
                {
                    CCGui.ToggleSVG(gui.masks[0], false);
                    CCGui.ToggleSVG(item.myButton, true);
                }
                else
                {
                    CCGui.ToggleSVG(item.myButton, false);
                }
            }

        }
    }

    void SaveGear()
    {
        PlayerPrefs.SetString("ubls", UnlockableDataString());
        PlayerPrefs.SetInt("bp", currBack.index);
        PlayerPrefs.SetInt("bt", currBelt.index);
        PlayerPrefs.SetInt("by", currBody.index);
        PlayerPrefs.SetInt("gs", currGlass.index);
        PlayerPrefs.SetInt("ht", currHat.index);
        PlayerPrefs.SetInt("hd", currHead.index);
        PlayerPrefs.SetInt("mk", currMask.index);
        PlayerPrefs.SetInt("pt", currPants.index);
        PlayerPrefs.SetInt("sh", currShoe.index);
    }
    void LoadGear()
    {
        if (PlayerPrefs.HasKey("ubls"))
            SetUnlockables(PlayerPrefs.GetString("ubls"));
        if (PlayerPrefs.HasKey("bp"))
            SetBackpack(PlayerPrefs.GetInt("bp"));
        if (PlayerPrefs.HasKey("bt"))
            SetBelt(PlayerPrefs.GetInt("bt"));
        if (PlayerPrefs.HasKey("by"))
            SetBody(PlayerPrefs.GetInt("by"));
        if (PlayerPrefs.HasKey("gs"))
            SetGlasses(PlayerPrefs.GetInt("gs"));
        if (PlayerPrefs.HasKey("ht"))
            SetHat(PlayerPrefs.GetInt("ht"));
        if (PlayerPrefs.HasKey("hd"))
            SetHead(PlayerPrefs.GetInt("hd"));
        if (PlayerPrefs.HasKey("mk"))
            SetMask(PlayerPrefs.GetInt("mk"));
        if (PlayerPrefs.HasKey("pt"))
            SetPants(PlayerPrefs.GetInt("pt"));
        if (PlayerPrefs.HasKey("sh"))
            SetShoes(PlayerPrefs.GetInt("sh"));

    }
}


