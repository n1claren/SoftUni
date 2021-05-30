// non-functional
function sort(array) {
    array.sort((a, b) => a.localeCompare(b));

    for (let i = 0; i < array.length; i++) {
        console.log(`${i+1}.${array[i]}`);
    }
}

sort(["John", "Bob", "Christina", "Ema"]);

// functional
function sortAdvanced(array) {
    return array
        .sort((a, b) => a.localeCompare(b))
        .map((value, index) => value = `${index + 1}.${value}`)
        .join('\n');
}

sortAdvanced(["John", "Bob", "Christina", "Ema"]);