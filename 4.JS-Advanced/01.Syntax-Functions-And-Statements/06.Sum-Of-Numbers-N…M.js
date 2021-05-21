function sum(n, m) {
    let numberOne = Number(n);
    let numberTwo = Number(m);
    let result = 0;

    for (let i = numberOne; i <= numberTwo; i++){
        result += i;
    }

    console.log(result);
}

sum('1', '5');