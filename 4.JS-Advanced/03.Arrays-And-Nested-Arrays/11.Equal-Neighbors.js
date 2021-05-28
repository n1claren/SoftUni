function equalNeighbors(input) {
    let counter = 0;
    for (let i = 0; i < input.length; i++) {
        for (let z = 0; z < input[i].length; z++) {
            if (CheckIndex(i - 1, z, input) && input[i][z] == input[i - 1][z]) {
                counter++;
            }
            if (CheckIndex(i , z + 1, input) && input[i][z] == input[i][z + 1]) {
                counter++;
            }
        }
    }
    
    function CheckIndex(rows, cols, input) {
        return rows >= 0 && rows < input.length && cols >= 0 && cols < input[rows].length;
    }

    return counter;
}

let resultOne = equalNeighbors([['2', '3', '4', '7', '0'],
['4', '0', '5', '3', '4'],
['2', '3', '5', '4', '2'],
['9', '8', '7', '5', '4']]);

let resultTwo = equalNeighbors([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]);

console.log(resultOne);
console.log(resultTwo);