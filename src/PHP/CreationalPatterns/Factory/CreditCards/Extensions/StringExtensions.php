<?php

namespace CreationalPatterns\Factory\CreditCards\Extensions;

class StringExtensions
{
    public static function splitPascalCaseString($pascalCaseString): string
    {
        $modifiedCharacters = array_reduce(
            str_split($pascalCaseString),
            function ($carry, $char) use (&$pascalCaseString) {
                // $carry variable is often used as an accumulator or array reduction operations
                $index = count($carry);
                if ($index !== 0 && ctype_upper($char) && !ctype_upper($pascalCaseString[$index - 1])) {
                    $carry[] = ' ';
                }
                $carry[] = $char;
                return $carry;
            },
            []
        );

        return implode('', $modifiedCharacters);
    }
}