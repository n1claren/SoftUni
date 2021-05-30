function solve(array, number) {
    let resultArray = [];

    for (let i = 0; i < array.length; i++) {
        if (i % number == 0) {
            resultArray.push(array[i]);
        }
    }

    return resultArray;
}

result = solve(['5', '20', '31', '4', '20'], 2);

console.log(result);