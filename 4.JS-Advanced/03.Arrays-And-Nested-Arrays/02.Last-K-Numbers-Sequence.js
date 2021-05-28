function solve(numberOne, numberTwo) {
    let array = [];
    array[0] = 1;

    for (let i = 1; i < numberOne; i++) {
        let sum = 0;
        for (let j = 1; j <= numberTwo; j++) {
            if (i - j >= 0) {
                sum += array[i - j];
            }
        }
        array[i] = sum;
    }

    return array;
}

console.log(solve(6, 3));
console.log(solve(8, 2));