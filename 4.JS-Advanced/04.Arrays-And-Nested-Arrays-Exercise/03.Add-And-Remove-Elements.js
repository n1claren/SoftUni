function solve(inputArray) {
    let resultArray = [];
    let number = 1;

    for (let i = 0; i < inputArray.length; i++) {
        if (inputArray[i] == 'add') {
            resultArray.push(number);
        } else {
            resultArray.pop();
        }

        number++;
    }

    if (resultArray.length == 0) {
        console.log('Empty');
    } else {
        for (let i = 0; i < resultArray.length; i++) {
            console.log(resultArray[i]);
        }
    }
}

console.log('case one:');
solve(['add', 'add', 'add', 'add']);

console.log('case two:');
solve(['add', 'add', 'remove', 'add', 'add']);

console.log('case three:');
solve(['remove', 'remove', 'remove']);