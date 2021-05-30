// without Reduce
function noReduce(array) {
    let tempElement = 0;
    let resultArray = [];

    for (let i = 0; i < array.length; i++) {
         if (array[i] > tempElement) {
             resultArray.push(array[i]);
             tempElement = array[i];
         }
    }

    return resultArray;
}

result = noReduce([1, 3, 8, 4, 10, 12, 3, 2, 24]);
console.log(result);

// with Reduce
function reduce(array) {
    return array.reduce((acc, value) => {
        if (acc.length == 0 || acc[acc.length - 1] <= value) {
            acc.push(value);
        }
        
        return acc;
    }, []);
}

result = reduce([1, 3, 8, 4, 10, 12, 3, 2, 24]);
console.log(result);