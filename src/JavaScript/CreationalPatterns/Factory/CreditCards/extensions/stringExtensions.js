
const splitPascalCaseString = (pascalCaseString) => {
    const modifiedCharacters = pascalCaseString
        .split('')
        .flatMap((c, i) => i !== 0 && c === c.toUpperCase() && pascalCaseString[i - 1] !== c.toUpperCase()
            ? [' ', c]
            : [c]);

    return modifiedCharacters.join('');
}

module.exports = { splitPascalCaseString };