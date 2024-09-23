public class AK47Weapon : Weapon
{

    public override void SetParameters()
    {
        weaponName = "AK47";
        maxAmmo = 100;
        fireRate = 0.1f; // m/s
        damage = 15;
        range = 10;
        reloadTime = 3;
    }
}
