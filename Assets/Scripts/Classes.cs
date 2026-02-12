using UnityEngine;

public class Classes : MonoBehaviour
{
    public int rolled_hp;
    public int avg_hp;

    public int rand_hp(string name) {
        if(name == "barbarian") {rolled_hp = Random.Range(1,13);}
        else if(name == "paladin" || name == "ranger" || name == "fighter") {rolled_hp = Random.Range(1,11);}
        else if(name == "wizard" || name == "sorcerer") {rolled_hp = Random.Range(1,7);}
        else {rolled_hp = Random.Range(1,9);}
        return rolled_hp;
    }
    public int average_hp(string name) {
        if(name == "barbarian") {avg_hp = 6;}
        else if(name == "paladin" || name == "ranger" || name == "fighter") {avg_hp = 5;}
        else if(name == "wizard" || name == "sorcerer") {avg_hp = 3;}
        else {avg_hp = 4;}
        return avg_hp;
    }
}
public class Race : MonoBehaviour
{
    public int lvl_gain;
    public int race_gain(string name) {
        if(name == "dwarf") {lvl_gain = 2;}
        else if(name == "orc" || name == "goliath") {lvl_gain = 1;}
        return lvl_gain;
    }
}