public class RGD5Weapon : Weapon
{

    public override void SetParameters()
    {
        weaponName = "RGD5";
        maxAmmo = 100;
        fireRate = 0.1f; // m/s
        damage = 15;
        range = 10;
        reloadTime = 3;
    }
}
