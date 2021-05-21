function square(number){
    let result = '';

    for (let i = number; i > 0; i--){
        result += '* ';
    }

    for (let i = number; i > 0; i--){
        console.log(result.trimEnd());
    }
}

square(5);