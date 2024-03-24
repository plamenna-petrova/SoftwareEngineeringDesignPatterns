import java.util.HashMap;
import java.util.Map;

abstract class Character {
    protected char symbol;
    protected int width;
    protected int height;
    protected int ascent;
    protected int descent;
    protected int pointSize;

    public abstract void display(int pointSize);
}

class CharacterA extends Character {
    public CharacterA() {
        symbol = 'A';
        height = 100;
        width = 120;
        ascent = 70;
        descent = 0;
    }

    @Override
    public void display(int pointSize) {
        this.pointSize = pointSize;
        System.out.println("symbol (point size " + this.pointSize + ")");
    }
}

class CharacterB extends Character {
    public CharacterB() {
        symbol = 'B';
        height = 100;
        width = 140;
        ascent = 72;
        descent = 0;
    }

    @Override
    public void display(int pointSize) {
        this.pointSize = pointSize;
        System.out.println("symbol (point size " + this.pointSize + ")");
    }
}

class CharacterZ extends Character {
    public CharacterZ() {
        symbol = 'Z';
        height = 100;
        width = 100;
        ascent = 68;
        descent = 0;
    }

    @Override
    public void display(int pointSize) {
        this.pointSize = pointSize;
        System.out.println("symbol (point size " + this.pointSize + ")");
    }
}

class CharacterFactory {
    private final Map<Character, Character> characters = new HashMap<>();

    public Character getCharacter(char key) {
        Character character = null;

        switch (key) {
            case 'A':
                character = new CharacterA();
                break;
            case 'B':
                character = new CharacterB();
                break;
            case 'Z':
                character = new CharacterZ();
                break;
        }

        if (!characters.containsKey(character)) {
            characters.put(character, character);
        }

        return character;
    }
}

public class Main {
    public static void main(String[] args) {
        String documentText = "AAZZBBZB";
        char[] documentTextCharacters = documentText.toCharArray();

        CharacterFactory characterFactory = new CharacterFactory();

        int pointSize = 10;

        for (char documentTextCharacter : documentTextCharacters) {
            pointSize++;
            Character character = characterFactory.getCharacter(documentTextCharacter);
            character.display(pointSize);
        }
    }
}