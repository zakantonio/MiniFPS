

public class BennelliM4Weapon : Weapon
{

    public override void SetParameters()
    {
        weaponName = "Bennelli M4";
        maxAmmo = 100;
        fireRate = 0.4f; // m/s
        damage = 15;
        distance = 50;
        reloadTime = 3;
    }
}
