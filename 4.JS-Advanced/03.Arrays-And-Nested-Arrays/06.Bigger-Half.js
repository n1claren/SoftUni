function solve(numbers = []) {
    let array = numbers.sort((a, b) => a - b);

    const midIndex = Math.floor(array.length / 2);
    const result = array.slice(midIndex);

    return result;
}

console.log(solve([4, 7, 2, 5, 8]));
console.log(solve([3, 19, 14, 7, 2, 19, 6]));