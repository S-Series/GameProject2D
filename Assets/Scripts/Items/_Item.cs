/* Default Item Class

//$ ItemID: 0001
public class ItemName : Item
{
    public override void ItemEffect()
    {
        base.ItemEffect();
    }
    public ItemName()
    {
        ItemID = 0001;
        ItemKey = "";

        coolDown = 0;
        quality = 0;
        isActive = false;
    }
}
*/

public class Item
{
    public short ItemID { get; set; }
    public string ItemKey { get; set; }

    public short coolDown { get; set; }
    public short quality { get; set; }
    public bool isActive { get; set; }

    public string[][] itemData = new string[4][]{
        new string[2]{"en", "kr"},  //$ Item Name
        new string[2]{"en", "kr"},  //$ Item Suptitle
        new string[2]{"en", "kr"},  //$ Item Description
        new string[2]{"en", "kr"}   //$ Item Effect
    };

    public virtual void ItemEffect() { throw new System.Exception("Item effect Undefined"); }
}


//$ ItemID: 0001
public class WitchWand : Item
{
    public override void ItemEffect()
    {
        base.ItemEffect();
    }
    public WitchWand()
    {
        ItemID = 0001;
        ItemKey = "WitchWand";

        coolDown = 0;
        quality = 0;
        isActive = false;
        itemData = new string[4][];
    }
}
//$ ItemID: 0002
public class WitchPendant : Item
{
    public override void ItemEffect()
    {
        base.ItemEffect();
    }
    public WitchPendant()
    {
        ItemID = 0002;
        ItemKey = "WitchPendant";

        coolDown = 0;
        quality = 0;
        isActive = false;
        itemData = new string[4][];
    }
}
//$ ItemID: 0003
public class Coupon : Item
{
    public override void ItemEffect()
    {
        base.ItemEffect();
    }
    public Coupon()
    {
        ItemID = 0003;
        ItemKey = "Coupon";

        coolDown = 0;
        quality = 0;
        isActive = false;
        itemData = new string[4][];
    }
}
//$ ItemID: 0004
public class BlacksComb : Item
{
    public override void ItemEffect()
    {
        base.ItemEffect();
    }
    public BlacksComb()
    {
        ItemID = 0004;
        ItemKey = "BlacksComb";

        coolDown = 0;
        quality = 0;
        isActive = false;
        itemData = new string[4][];
    }
}
//$ ItemID: 0005
public class BlacksBeak : Item
{
    public override void ItemEffect()
    {
        base.ItemEffect();
    }
    public BlacksBeak()
    {
        ItemID = 0005;
        ItemKey = "BlacksBeak";

        coolDown = 0;
        quality = 0;
        isActive = false;
        itemData = new string[4][];
    }
}
//$ ItemID: 0006
public class BlacksFeather : Item
{
    public override void ItemEffect()
    {
        base.ItemEffect();
    }
    public BlacksFeather()
    {
        ItemID = 0006;
        ItemKey = "BlacksFeather";

        coolDown = 0;
        quality = 0;
        isActive = false;
        itemData = new string[4][];
    }
}
//$ ItemID: 0007
public class Beer : Item
{
    public override void ItemEffect()
    {
        base.ItemEffect();
    }
    public Beer()
    {
        ItemID = 0007;
        ItemKey = "Beer";

        coolDown = 0;
        quality = 0;
        isActive = false;
        itemData = new string[4][];
    }
}

//$ ItemID: 1001
public class Snacks : Item
{
    public override void ItemEffect()
    {
        base.ItemEffect();
    }
    public Snacks()
    {
        ItemID = 1001;
        ItemKey = "Snacks";

        coolDown = 0;
        quality = 0;
        isActive = true;
        itemData = new string[4][];
    }
}
//$ ItemID: 1002
public class CheatCoin : Item
{
    public override void ItemEffect()
    {
        base.ItemEffect();
    }
    public CheatCoin()
    {
        ItemID = 1002;

        ItemKey = "CheatCoin";
        coolDown = 0;
        quality = 0;
        isActive = true;
        itemData = new string[4][];
    }
}
