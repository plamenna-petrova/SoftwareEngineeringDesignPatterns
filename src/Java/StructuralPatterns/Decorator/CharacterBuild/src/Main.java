import java.util.*;

abstract class CharacterBuild {
    protected int health;
    protected int stamina;
    protected int strength;
    protected int dexterity;
    protected int endurance;
    protected int attunement;

    public void showStats() {
        String stringBuilder = "Health: " + health + "\n" +
                "Stamina: " + stamina + "\n" +
                "Strength: " + strength + "\n" +
                "Dexterity: " + dexterity + "\n" +
                "Endurance: " + endurance + "\n" +
                "Attunement: " + attunement + "\n";

        System.out.println(stringBuilder);
    }
}

class Knight extends CharacterBuild {
    public Knight() {
        health = 120;
        stamina = 110;
        strength = 15;
        dexterity = 10;
        endurance = 12;
        attunement = 3;
    }
}

class Wanderer extends CharacterBuild {
    public Wanderer() {
        health = 100;
        stamina = 120;
        strength = 10;
        dexterity = 15;
        endurance = 12;
        attunement = 4;
    }
}

abstract class CharacterBuildDecorator extends CharacterBuild {
    protected CharacterBuild characterBuild;

    public CharacterBuildDecorator(CharacterBuild characterBuild) {
        this.characterBuild = characterBuild;
    }

    public void increaseHealth(int points) {
        characterBuild.health += points;
    }

    public void increaseStrength(int points) {
        characterBuild.strength += points;
    }

    public void increaseDexterity(int points) {
        characterBuild.dexterity += points;
    }

    public void increaseEndurance(int points) {
        characterBuild.endurance += points;
    }

    public void increaseAttunement(int points) {
        characterBuild.attunement += points;
    }

    @Override
    public void showStats() {
        characterBuild.showStats();
    }
}

class StrengthBuild extends CharacterBuildDecorator {
    public StrengthBuild(CharacterBuild characterBuild) {
        super(characterBuild);
        characterBuild.strength += 10;
        characterBuild.health -= 10;
    }
}

class DexterityBuild extends CharacterBuildDecorator {
    public DexterityBuild(CharacterBuild characterBuild) {
        super(characterBuild);
        characterBuild.dexterity += 10;
        characterBuild.strength -= 2;
    }
}

class MagicKnightBuild extends CharacterBuildDecorator {
    public MagicKnightBuild(CharacterBuild characterBuild) {
        super(characterBuild);
        if (characterBuild instanceof CharacterBuildDecorator) {
            ((CharacterBuildDecorator) characterBuild).increaseAttunement(15);
        } else {
            characterBuild.attunement += 15;
        }
    }
}

public class Main {
    public static void main(String[] args) {
        CharacterBuild knight = new Knight();
        System.out.println("Base Knight Stats:");
        knight.showStats();

        CharacterBuild strengthenedKnight = new StrengthBuild(knight);
        System.out.println("Knight Stats After Strength Build: ");
        strengthenedKnight.showStats();

        CharacterBuild wanderer = new Wanderer();
        System.out.println("Base Wanderer Stats: ");
        wanderer.showStats();

        CharacterBuild dexterousWanderer = new DexterityBuild(wanderer);
        System.out.println("Wanderer Stats After Dexterity Build: ");
        dexterousWanderer.showStats();

        CharacterBuild magicKnight = new MagicKnightBuild(strengthenedKnight);
        System.out.println("Strengthened Knight After Magic Build: ");
        magicKnight.showStats();
    }
}