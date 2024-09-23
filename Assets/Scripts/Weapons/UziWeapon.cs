public class UziWeapon : Weapon
{

    public override void SetParameters()
    {
        weaponName = "Uzi";
        maxAmmo = 100;
        fireRate = 0.4f; // m/s
        damage = 15;
        distance = 50;
        reloadTime = 3;
    }
}
