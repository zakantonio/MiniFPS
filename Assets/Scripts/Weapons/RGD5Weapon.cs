public class RGD5Weapon : Weapon
{

    public override void SetParameters()
    {
        weaponName = "RGD5";
        maxAmmo = 100;
        fireRate = 0.4f; // m/s
        damage = 15;
        distance = 50;
        reloadTime = 3;
    }
}
