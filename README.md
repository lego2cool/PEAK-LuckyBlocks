# Lucky Blocks

**Lucky Blocks** can be found around the map in various locations such as in trees, on bushes, or inside of luggage. Smash them open by throwing it at the ground, but be careful, or something bad might pop out!

If you come across any bugs or have feature suggestions, please post them in the thread posted on the mod-releases section on the [PEAK Modding discord server](https://discord.gg/SAw86z24rB).

## ✨ Features

* Adds a new Lucky Block item that breaks open similar to a coconut.
* Fully multiplayer compatible.
* 20+ different outcomes!

## ⚠️ Notes

* Everyone must have the mod installed for it to work properly.
* Please make sure you place the .peakbundle file in the same folder as the mod .dll file.

## 🛠️ Requirements

* [BepInEx](https://thunderstore.io/c/peak/p/BepInEx/BepInExPack_PEAK/)
* [PEAKLib_Items](https://thunderstore.io/c/peak/p/PEAKModding/PEAKLib_Items/) and its dependencies

## 📦 Installation

1. Download via [Thunderstore](https://thunderstore.io/c/peak/)
2. Extract the zip contents into: /PEAK/BepInEx/plugins/
3. Launch game

## 🎲 Outcomes (Spoilers)
<details> <summary><strong>Click to reveal all LuckyBlock outcomes</strong></summary>

### Good
* Luggage Spawn (Small, Big, Epic, and Ancient)
* Lucky Block Rain
* Berry Rain
* Backpacks Spawn
* Healing Cloud
* Equipment Rain
* Random Mythic Item Spawn
* Checkpoint Flag Spawn

### Bad
* Tornado Spawn
* Eruption Spawn
* Nana Peel Rain
* Explosion
* Scorpion Rain
* Scoutmaster Spawn
* Zombie Spawn

### Neutral
* Rope Spawn
* Anti-Rope Spawn
* Bounce Shroom Spawn
* Shelf Shroom Spawn
* Chaos Cloud
* Scout Cannon Spawn
* Portable Stove Spawn
* Sunscreen Cloud
</details>

## 🔧 Planned Features

* Config file

## How To Add Custom Outcomes
<details>
<summary><strong>Adding custom outcomes allows you to give Lucky Blocks your own unique effects. This can be done by creating a new mod that depends on Lucky Blocks and registers additional outcome methods.</strong></summary>

### Step 1: Set Up Your Mod Dependencies
Add **Lucky Blocks** as either a soft or hard dependency in your mod's manifest or configuration.

- **Soft dependency**: Your mod can work without Lucky Blocks, but gains extra functionality when it's present
- **Hard dependency**: Your mod requires Lucky Blocks to function at all

### Step 2: Create Your Outcome Method
Create a public static method that takes exactly two parameters in this order:
- `LuckyBreakable lb`: Represents the Lucky Blocks Breakable class. You can access properties like `lb.item` to get data from the Lucky Block item.
- `Collision coll`: Contains information about the collision, including contact points and normals.

The method should be static and return void. Here's an example:

```
public static void Enderpearl(LuckyBreakable lb, Collision coll)
{
    Vector3 targetPos = coll.contacts[0].point + new Vector3(0f,5f,0f);

    // Find the owner of this LuckyBlock
    Character owner = lb.item.lastThrownCharacter;
    if (owner != null)
    {
        // Teleport player
        owner.transform.position = targetPos;
    }
}
```
### Step 3: Register Your Outcome
Call `Outcomes.AddOutcome()` with your method and a weight value. The weight determines how likely this outcome is to occur relative to other outcomes. Defaults to 100 if nothing is entered

* Higher weight = more common
* Lower weight = rarer

Example:
```
Outcomes.AddOutcome(Enderpearl, 70) // 'Enderpearl' is the method name and '70' is the outcome weight
```
</details>

## Credits

* **Author:** distinctdonut
* If you use this mod in any videos please link the mod in the description.