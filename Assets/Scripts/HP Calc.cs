using UnityEngine;

public class HPCalc : MonoBehaviour
{
    public string race; //the character's race
    public string characterClass; //the character's class
    public string rollType; //type of roll for con stat
    public string CharacterName; //the character's name
    public int con; //the character's con stat
    public int level; //the character's level
    public bool stout; //if character has stout feat
    public bool tough; // if character has tough feat
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //convert all strings to lower just in case
        race = race.ToLower();
        characterClass = characterClass.ToLower();
        rollType = rollType.ToLower();
        int hp = ((con - 10) / 2); //Calculates hp based on con stat
        int lvlGain = 0; //initialize variable that determines how much hp is gained per level
        if(stout) {lvlGain++;} //adds 1 to lvlGain
        if(tough) {lvlGain += 2;} //adds 2 to lvlGain
        if(race == "dwarf") {lvlGain += 2;} //adds 2 to lvlGain
        if(race == "orc" || race == "goliath") {lvlGain++;} //adds 1 to lvlGain
        if(rollType == "rolled") { //actually rolls random dice based on class
            if(characterClass == "barbarian") {hp += Random.Range(1,13);} //max num is exclusive while min num is inclusive
            else if(characterClass == "fighter" || characterClass == "ranger" || characterClass == "paladin") {hp += Random.Range(1,11);}
            else if(characterClass == "wizard" || characterClass == "sorcerer") {hp += Random.Range(1,7);}
            else {hp += Random.Range(1,9);}
        }
        else{ // if it isn't rolled, default to average. Good for if input is mispelled 
            if(characterClass == "barbarian") {hp += 6;}
            else if(characterClass == "fighter" || characterClass == "ranger" || characterClass == "paladin") {hp += 5;}
            else if(characterClass == "wizard" || characterClass == "sorcerer") {hp += 3;}
            else {hp += 4;}
        }
    
        hp += (lvlGain * level); //adds level based hp gains
        //the following creates a string output based on variables given and feats added
        string output = ("My character " + CharacterName + " is a level " + level + " " + characterClass + " with a CON score of " + con + " and is of the " + race + " race");
        if(tough && stout) {output = output + " and has the Tough and Stout feats";}
        else if(tough) {output = output + " and has the Tough feat";}
        else if (stout) {output = output + " and has the Stout feat";}
        output = output + ". I had the HP " + rollType + " and got a total of " + hp + " HP.\n";
        Debug.LogFormat(output); //outputs the Output variable into the console.
    }
}
