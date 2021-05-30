function magic(matrix) {
    let magicSum = 0;
    let isMagic = true;

    for (let rows = 0; rows < matrix.length; rows++) {
        let rowsSum = 0;
        let colsSum = 0;

        for (let cols = 0; cols < matrix[rows].length; cols++) {
            rowsSum += matrix[rows][cols];
            
            if(cols < matrix.length) {
                colsSum += matrix[cols][rows];
            }
        }
        
        if(magicSum === 0) {
            magicSum = rowsSum;
        }

        if(magicSum !== rowsSum || magicSum != colsSum) {
            isMagic = false;
            break;
        }
    }

    return isMagic;
}

result = (magic([[1, 0, 0],
                   [0, 0, 1],
                   [0, 1, 0]]));
                   
console.log(result);