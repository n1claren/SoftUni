function oddPositions(numbers) {
    let array = [];

    for (let i = 1; i < numbers.length; i += 2) {
        let currentNumber = numbers[i] * 2;
        array.unshift(currentNumber);
    }

    return array.join(' ');
}

let result = oddPositions([3, 0, 10, 4, 7, 3]);
console.log(result);