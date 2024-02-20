package Extensions;

import java.util.stream.Collectors;
import java.util.stream.Stream;

public class StringExtensions {
    public static String splitPascalCaseString(String pascalCaseString) {
        char[] modifiedCharacters = pascalCaseString
                .chars()
                .mapToObj(c -> (char) c)
                .flatMap(c -> {
                    if (c != ' ' && Character.isUpperCase(c)) {
                        return Stream.of(' ', c);
                    } else {
                        return Stream.of(c);
                    }
                })
                .map(Object::toString)
                .collect(Collectors.joining())
                .toCharArray();

        return new String(modifiedCharacters);
    }
}
