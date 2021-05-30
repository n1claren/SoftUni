function sort(array) {
    array.sort((a, b) => a - b);
    let resultArray = [];

    while(array.length > 0) {

        resultArray.push(array.shift());
        resultArray.push(array.pop());
    }

    return resultArray;
}

let result = sort([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);
console.log(result);