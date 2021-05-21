function solve(input) {
    let sum = 0;
    let inverseSum = 0;
    let concat = '';

    for (let i = 0; i < input.length; i++) {
        let element = input[i];
        sum += element;
        inverseSum += 1 / element;
        concat += element;
    }

    console.log(sum);
    console.log(inverseSum);
    console.log(concat);
}

solve([2,4,8,16]);