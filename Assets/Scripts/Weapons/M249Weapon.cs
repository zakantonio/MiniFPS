

public class M249Weapon : Weapon
{
    public override void SetParameters()
    {
        weaponName = "M249";
        maxAmmo = 10;
        fireRate = 0.5f; // m/s
        damage = 5;
        range = 5;
        reloadTime = 2;
    }
}
