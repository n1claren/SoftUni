class Stringer {
    constructor(innerString, innerLength) {
        this.innerString = innerString;
        this.innerLength = innerLength;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        this.innerLength = this.innerLength - length < 0 ? 0 : this.innerLength - length;
    }

    toString() {
        if (this.innerString.length > this.innerLength) {
            return this.innerString.substring(0, this.innerLength) + '...';
        } else if (this.innerLength == 0) {
            return '...';
        }

        return this.innerString;
    }
}

let test = new Stringer("Test", 5); 
console.log(test.toString()); 

test.decrease(3); 
console.log(test.toString());
 
test.decrease(5); 
console.log(test.toString());
 
test.increase(4);  
console.log(test.toString());