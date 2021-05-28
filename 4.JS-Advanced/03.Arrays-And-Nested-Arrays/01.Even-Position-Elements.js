function evenElements(array) {
    result = '';

    for (let i = 0; i < array.length; i++) {
        if (i % 2 == 0) {
            result += array[i] + ' ';
        }
    }

    console.log(result);
}

evenElements(['20', '30', '40', '50', '60']);
evenElements(['5', '10']);