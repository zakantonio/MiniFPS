using UnityEngine;

public class CityManagement : MonoBehaviour
{

    [SerializeField] BoxBehaviour[] chests;

    [SerializeField] FixedEnemy[] enemies;

    [SerializeField] CheckPoint checkPoint;

    int level = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetLevel(int level = 0)
    {
        this.level = level;

        BoxContent c = BoxContent.M1911;
        switch (level)
        {
            case 0:
                {
                    c = BoxContent.M1911;
                    break;
                }
            case 1:
                {
                    c = BoxContent.AK47;
                    break;
                }
            case 2:
                {
                    c = BoxContent.Bennelli;
                    break;
                }
            case 3:
                {
                    c = BoxContent.M249;
                    break;
                }
            case 4:
                {
                    c = BoxContent.Uzi;
                    break;
                }
        }

        chests[0].SetBoxContent(c);
        chests[1].SetBoxContent(BoxContent.Ammo);
        chests[2].SetBoxContent(BoxContent.Coin);

    }
}
