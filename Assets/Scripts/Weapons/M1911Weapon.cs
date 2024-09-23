public class M1911Weapon : Weapon
{

    public override void SetParameters()
    {
        weaponName = "M1911";
        maxAmmo = 10;
        fireRate = 0.5f; // m/s
        damage = 5;
        range = 5;
        reloadTime = 2;
    }
}
