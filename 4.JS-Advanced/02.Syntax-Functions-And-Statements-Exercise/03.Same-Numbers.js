function solve(number) {
    const string = number.toString();
    let isTheSame = true;
    let sum = 0;

    for (let i = 0; i < string.length; i++) {
        if (string[i] !== string[i+1] && string[i+1] !== undefined) {
            isTheSame = false;
        }
        
        sum += Number(string[i]);
    }

    console.log(isTheSame);
    console.log(sum);
}

solve(2222222);
solve(1234);