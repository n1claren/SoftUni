function smalletsTwoNumbers(array) {
    array.sort((a, b) => a - b);
    array.length = 2;
    console.log(array.join(' '));
}

smalletsTwoNumbers([30, 15, 50, 5]);
smalletsTwoNumbers([3, 0, 10, 4, 7, 3]);