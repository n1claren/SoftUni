function pieceOfPie(array, firstPie, secondPie) {
    return array.slice(array.indexOf(firstPie), array.indexOf(secondPie) + 1);
}

let result = pieceOfPie(
['Apple Crisp',
'Mississippi Mud Pie',
'Pot Pie',
'Steak and Cheese Pie',
'Butter Chicken Pie',
'Smoked Fish Pie'],
'Pot Pie',
'Smoked Fish Pie'
);

console.log(result);