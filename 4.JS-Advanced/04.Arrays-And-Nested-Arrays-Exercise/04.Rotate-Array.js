function rotate(array, number) {
    for (let i = 1; i <=  number; i++) {
        let temp = array.pop();
        array.unshift(temp);
    }

    console.log(array.join(' '));
}

console.log('case one:');
rotate(['1', '2', '3', '4'], 2);

console.log('case two:');
rotate(['Banana', 'Orange', 'Coconut', 'Apple'], 15);