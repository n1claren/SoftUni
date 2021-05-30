function sort(array) {
    return array.sort((a, b) => {

        if (a.length == b.length) {
            return a.localeCompare(b);
        }

        return (a.length - b.length)

    }).join('\n');
}

result = sort(['test','Deny','omen','Default']);
console.log(result);