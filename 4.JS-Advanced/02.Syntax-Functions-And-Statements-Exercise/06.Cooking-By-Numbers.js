function solve(numberString, paramOne, paramTwo, paramThree, paramFour, paramFive, paramSix) {
    let number = Number(numberString);

    function actionParam(param) {
        switch (param) {
            case 'chop': number = number / 2;
            console.log(number);
            break;
    
            case 'dice': number = Math.sqrt(number);
            console.log(number);
            break;
    
            case 'spice': number += 1;
            console.log(number);
            break;
    
            case 'bake': number *= 3;
            console.log(number);
            break;
    
            case 'fillet': number -= (number / 100) * 20;
            console.log(number);
            break;
        }
    }

    actionParam(paramOne);
    actionParam(paramTwo);
    actionParam(paramThree);
    actionParam(paramFour);
    actionParam(paramFive);
    actionParam(paramSix);
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');