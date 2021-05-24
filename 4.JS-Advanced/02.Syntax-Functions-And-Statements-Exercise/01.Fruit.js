function solve(fruit, grams, costPerKG) {
    let weight = grams / 1000;
    let price = weight * costPerKG;
    return `I need $${price.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`;
}

console.log(solve('orange', 2500, 1.80));
console.log(solve('apple', 1563, 2.35));