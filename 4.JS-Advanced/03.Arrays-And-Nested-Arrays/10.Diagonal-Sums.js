function diagonalsSum(input) {
    let firstDiagonal = 0;
    let secondDiagonal = 0;

    for (let i = 0; i < input.length; i++) {
        for (let z = 0; z < input[i].length; z++) {
            if(i == z) {
                firstDiagonal += input[i][z];
            }
            if(z == input[i].length - 1 - i) {
                secondDiagonal += input[i][z];
            }
        }
    }

    console.log(firstDiagonal, secondDiagonal);
}

diagonalsSum([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]
   );