using UnityEngine;

public class HPCalcTwo : MonoBehaviour
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
        int lvlGain = 0; //how much hp is gained per level up
        if(stout) {lvlGain++;} //adds 1 to lvlGain
        if(tough) {lvlGain += 2;} //adds 2 to lvlGain
        Classes charaClass = new Classes(); //from classes file
        if(rollType == "rolled") {hp += charaClass.rand_hp(characterClass);} //if rolled get random hp
        else {hp += charaClass.average_hp(characterClass);} // if not rolled get average hp
        Race charaRace = new Race(); //from classes file
        lvlGain += charaRace.race_gain(race); //add race value to lvlGain
        hp += (lvlGain * level); //level hp
        //the following creates a string output based on variables given and feats added
        string output = ("My character " + CharacterName + " is a level " + level + " " + characterClass + " with a CON score of " + con + " and is of the " + race + " race");
        if(tough && stout) {output = output + " and has the Tough and Stout feats";}
        else if(tough) {output = output + " and has the Tough feat";}
        else if (stout) {output = output + " and has the Stout feat";}
        output = output + ". I had the HP " + rollType + " and got a total of " + hp + " HP.\n";
        Debug.LogFormat(output); //outputs the Output variable into the console.
        //NOTE: "NEW KEYWORD" ERROR WAS NOTICED AND IGNORED FOR THE PURPOSES OF THIS ASSIGNMENT, FUTURE WORKS WOULD USE UNITY'S BUILT-IN ADDCOMPONENT FUNCTIONALITY
    }
}