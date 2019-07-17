using UnityEngine;
using UnityEngine.UI;

public class inventoryManager : MonoBehaviour {

    public GameObject[] weapons;
    bool[] weaponAvailable;
    public Image weaponIcon;

    int currentWeapon;

	// Use this for initialization
	void Start () {
        weaponAvailable = new bool[weapons.Length];
        for (int i = 0; i < weapons.Length; i++) weaponAvailable[i] = false;
        currentWeapon = 0;
        weaponAvailable[currentWeapon] =true;
//      for (int i = 0; i < weapons.Length; i++) weaponAvailable[i] = true;

        deactivateWeapons();

        setWeaponActive(currentWeapon);
	}
	
	// Update is called once per frame
	void Update () {
        //toggle Weapon
        if (Input.GetButtonDown("Submit") || Input.GetKeyDown("e"))
        {
            int i;
            for(i=currentWeapon+1; i<weapons.Length; i++)
            {
                if(weaponAvailable[i] == true)
                {
                    currentWeapon = i;
                    setWeaponActive(currentWeapon);
                    return;
                }
            }
            for (i = 0; i < currentWeapon; i++)
            {
                if (weaponAvailable[i] == true)
                {
                    currentWeapon = i;
                    setWeaponActive(currentWeapon);
                    return;
                }
            }
        }
	}

    public void setWeaponActive(int whichWeapon)
    {
        if (!weaponAvailable[whichWeapon]) return;
        deactivateWeapons();
        weapons[whichWeapon].SetActive(true);
        weapons[whichWeapon].GetComponentInChildren<fireBullet>().initWeapon();
    }

    void deactivateWeapons()
    {
        for (int i = 0; i < weapons.Length; i++) weapons[i].SetActive(false);
    }

    public void activateWeapon(int whichWeapon)
    {
        weaponAvailable[whichWeapon] = true;
    }
}
