function firstLastElementSum(array) {
    let firstElement = Number(array.shift());
    let lastElement = Number(array.pop());
    let sum = firstElement + lastElement;

    return sum;
}

console.log(firstLastElementSum(['20', '30', '40']));
console.log(firstLastElementSum(['5', '10']));