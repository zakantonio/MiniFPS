

public class M249Weapon : Weapon
{
    public override void SetParameters()
    {
        weaponName = "M249";
        maxAmmo = 20;
        fireRate = 0.5f; // m/s
        damage = 10;
        distance = 50;
        reloadTime = 2;
    }
}
