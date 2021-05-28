function biggestElement(input) {
    let biggest = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < input.length; i++) {
        for (let z = 0; z < input[i].length; z++) {
            if(input[i][z] > biggest) {
                biggest = input[i][z];
            }
        }
    }
    return biggest;
}

result = biggestElement([[3, 5, 7, 12],
                [-1, 4, 33, 2],
                [8, 3, 0, 4]]);

console.log(result);