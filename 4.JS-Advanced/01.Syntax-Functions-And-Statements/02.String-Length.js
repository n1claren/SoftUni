function solve(firstWord, secondWord, thirdWord) {
    let sumLength;
    let averageLength;

    let firstWordLength = firstWord.length;
    let secondWordLength = secondWord.length;
    let thirdWordLength = thirdWord.length;

    sumLength = firstWordLength + secondWordLength + thirdWordLength;
    averageLength = Math.floor(sumLength / 3);

    console.log(sumLength);
    console.log(averageLength);
}

solve('chocolate', 'ice cream', 'cake');