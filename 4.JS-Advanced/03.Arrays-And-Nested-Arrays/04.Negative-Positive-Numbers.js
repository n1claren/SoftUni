function solve(input) {
    let array = [];

    for (let i = 0; i < input.length; i++) {
        let currentElement = input[i];
        if (currentElement < 0) {
            array.unshift(currentElement);
        } else {
            array.push(currentElement);
        }
    }

    for (let i = 0; i < array.length; i++) {
        console.log(array[i]);
    }
}

solve([7, -2, 8, 9]);
solve([3, -2, 0, -1]);