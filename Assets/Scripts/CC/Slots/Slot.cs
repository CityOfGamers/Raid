using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public CharacterCustomizer.EquipLocation slotLocation;
    public int index;
    public bool unlocked;
    public Sprite gearImage;
    public Button myButton;
    SkinnedMeshRenderer rend;

    private void Awake()
    {
        rend = GetComponent<SkinnedMeshRenderer>();
    }
    public Slot Equip ()
    {
        rend.enabled = true;
        return this;

    }
    public void DeEquip()
    {
        rend.enabled = false;
    }
}
