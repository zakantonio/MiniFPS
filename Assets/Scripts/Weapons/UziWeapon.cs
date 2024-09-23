public class UziWeapon : Weapon
{

    public override void SetParameters()
    {
        weaponName = "Uzi";
        maxAmmo = 100;
        fireRate = 0.1f; // m/s
        damage = 15;
        range = 10;
        reloadTime = 3;
    }
}
